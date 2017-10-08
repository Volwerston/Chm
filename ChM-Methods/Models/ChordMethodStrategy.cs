using System;
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

            double x0 = 0;
            double c = 0;
            double r = 0;
            double xp = x0;
            int n = 0;


            if(d1.Evaluate(A)*d2.Evaluate(B) < 0)
            {
                x0 = A;
                c = B;
            }
            else
            {
                x0 = B;
                c = A;
            }

            do
            {
                n++;

                double xn = xp - func.Evaluate(xp) * (c - xp) / (func.Evaluate(c) - func.Evaluate(xp));
                r = xn - xp;
                xp = xn;
            }
            while (Math.Abs(r) > Eps);

            return new Tuple<double, int>(xp, n);
        }
    }
}
