using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChM_Methods.Models
{
    class CombinedMethodStrategy : IMethodStrategy
    {
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

        public CombinedMethodStrategy(double _a, double _b, double _eps)
        {
            this.A = _a;
            this.B = _b;
            this.Eps = _eps;
        }

        public Tuple<double, int> Evaluate(Func func)
        {
            double a = A;
            double b = B;
            int n = 1;

            Func d1 = func.Derivative();
            Func d2 = d1.Derivative();

            while (Math.Abs(b - a) > Eps)
            {
                n++;

                if(func.Evaluate(a)*d2.Evaluate(a) < 0)
                {
                    a = a - func.Evaluate(a) * (a - b) / (func.Evaluate(a) - func.Evaluate(b));
                }
                else
                {
                    a = a - func.Evaluate(a) / d1.Evaluate(a);
                }

                if (func.Evaluate(b) * d2.Evaluate(b) < 0)
                {
                    b = b - func.Evaluate(b) * (b - a) / (func.Evaluate(b) - func.Evaluate(a));
                }
                else
                {
                    b = b - func.Evaluate(b) / d1.Evaluate(b);
                }
            }

            return new Tuple<double, int>((a + b) / 2, n);
        }
    }
}
