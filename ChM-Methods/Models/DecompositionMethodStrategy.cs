using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChM_Methods.Models
{
    class DecompositionMethodStrategy : IMethodStrategy
    {
        public double A { get; }

        public double B { get; }

        public double Eps { get; }

        public DecompositionMethodStrategy(double _a, double _b, double _eps)
        {
            A = _a;
            B = _b;
            Eps = _eps;
        }

        public Tuple<double, int> Evaluate(Func func)
        {
            
        }
    }
}
