using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChM_Methods.Models
{
    public static class MethodManager
    {
        public static IMethodStrategy GetStrategy(string type, double _a, double _b, double _eps)
        {
            if (type == "Метод декомпозиції") return new DecompositionMethodStrategy(_a, _b, _eps);
            if (type == "Метод хорд") return new ChordMethodStrategy(_a, _b, _eps);

            throw new Exception("Не знайдено підходящого методу");
        }
    }
}
