using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Units
{
    public class TemperatureUnits : UnitsContainer
    {
        private List<Unit> _units;
        public override string Name => "Temperatura";

        public override List<Unit> _unitList { get { return _units; } set { _units = _unitList; } }

        public TemperatureUnits()
        {
            this._units = new List<Unit> {
            new Unit("Temperatura", "Celcjusz", (x) => x, (x) => x),
            new Unit("Temperatura", "Farenheit",  (x) => ((x - 32) / 1.8), (x) => (x * 1.8) + 32 ),
            new Unit("Temperatura", "Kelvin", (x) => x - 273.15, (x) => x + 273.15),
            new Unit("Temperatura", "Rankine", (x) => (x - 491.67) * 5/9, (x) => (x + 273.15) * 9/5)
            };

        }
    }
}
