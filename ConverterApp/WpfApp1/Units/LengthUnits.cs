using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Units
{
    class LengthUnits : UnitsContainer
    {

        private List<Unit> _units;
        public override string Name => "Dlugosc";

        public override List<Unit> _unitList => _units;

        public LengthUnits()
        {
            this._units = new List<Unit> {
                new Unit("Dlugosc", "m", (x) => x, (x) => x),
                new Unit("Dlugosc", "mm", (x) => x * 0.001, (x) => x * 1000),
                new Unit("Dlugosc", "cm", (x) => x * 0.01, (x) => x * 100),
                new Unit("Dlugosc", "dm", (x) => x * 0.1, (x) => x * 10),
                new Unit("Dlugosc", "km", (x) => x * 1000, (x) => x * 0.001),
                new Unit("Dlugosc", "cal", (x) => x * 0.0254, (x) => x * 39.37),
                new Unit("Dlugosc", "jard", (x) => x * 0.9144, (x) => x * 1.09),
                new Unit("Dlugosc", "stop", (x) => x * 0.30, (x) => x * 3.28),
                new Unit("Dlugosc", "mila", (x) => x * 1609.34, (x) => x * 0.000621371192),
                new Unit("Dlugosc", "kabel", (x) => x * 219.456, (x) => x * 0.00455672208),
                new Unit("Dlugosc", "mila morska", (x) => x * 1852, (x) => x * 0.000539956803)
            };

        }
    }
}
