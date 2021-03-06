﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChM_Methods.Models
{
    class ChordMethodStrategy : IMethodStrategy
    {

        public ChordMethodStrategy(double _a, double _b, double _eps)
        {
            this.A = _a;
            this.B = _b;
            this.Eps = _eps;
        }

        public double A
        {
            get;
        }

        public double B
        {
            get;
        }

        public double Eps
        {
            get;
        }

        public Tuple<double, int> Evaluate(Func func)
        {
            Func d1 = func.Derivative();
            Func d2 = d1.Derivative();

            double prev = 0;
            double next = 0;
            int n = 0;


            if(d1.Evaluate(A)*d2.Evaluate(A) < 0)
            {
                prev = B;
                next = A;
            }
            else
            {
                prev = A;
                next = B;
            }

            do
            {
                n++;

                double buf = next - func.Evaluate(next) *((prev-next) / (double)(func.Evaluate(prev) - func.Evaluate(next)));

                prev = next;
                next = buf;
            }
            while (Math.Abs(func.Evaluate(next)) > Eps);

            return new Tuple<double, int>(next, n);
        }
    }
}
