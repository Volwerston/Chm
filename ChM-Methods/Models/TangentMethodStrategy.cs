using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChM_Methods.Models
{
    class TangentMethodStrategy : IMethodStrategy
    {
        public TangentMethodStrategy(double _a, double _b, double _eps)
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
            Func d2 = func.Derivative();


            double prev = A;
            int n = 1;

            if(func.Evaluate(B)*d2.Evaluate(B) > 0)
            {
                prev = B;
            }

            double next = prev - func.Evaluate(prev) / d1.Evaluate(prev);

            while (Math.Abs(next - prev) > Eps) 
            {
                n++;

                double buf = next - func.Evaluate(next) / d1.Evaluate(next);

                prev = next;
                next = buf;
            }
            
            return new Tuple<double, int>(next, n);
        }
    }
}
