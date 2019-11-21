using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Units
{
    class WeightUnits : IUnitsContainer
    {
        public string Name => "Masa";

        public List<IUnits> UnitsList => new List<IUnits> {
            new Unit("Masa", "kg", (x) => x, (x) => x),
            new Unit("Masa", "mg", (x) => x * 0.000001, (x) => x * 1000000),
            new Unit("Masa", "g", (x) => x * 0.001, (x) => x * 1000),
            new Unit("Masa", "dkg", (x) => x * 0.01, (x) => x * 100),
            new Unit("Masa", "T", (x) => x * 1000, (x) => x * 0.001),
            new Unit("Masa", "uncja", (x) => x * 0.0283495231, (x) => x * 35.2739619),
            new Unit("Masa", "funt", (x) => x * 0.45359237, (x) => x * 2.20462262),
            new Unit("Masa", "karat", (x) => x * 0.0002, (x) => x * 5000),
            new Unit("Masa", "kwintal", (x) => x * 100 , (x) => x * 0.01)
        };
    }
}
