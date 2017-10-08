using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChM_Methods.Models
{
    public interface IMethodStrategy
    {
        double A { get; }
        double B { get; }
        double Eps { get; }
        Tuple<double, int> Evaluate(Func func);
    }
}
