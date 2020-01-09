using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1;

namespace ConverterPlugin
{
    class PressureUnits : UnitsContainer
    {
        private List<Unit> _units;
        public override string Name => "Cisnienie";

        public override List<Unit> _unitList { get { return _units; } set { _units = _unitList; } }

        public PressureUnits() {
            _units = new List<Unit> {
                new Unit(this.Name, "Pa", x => x , x => x),
                new Unit(this.Name, "hPa", x => x * 100 , x => x / 100),
                new Unit(this.Name, "Bar", x => x * 100000 , x => x / 100000),
                new Unit(this.Name, "N/mm2", x => x * 1000000, x => x / 1000000),
                new Unit(this.Name, "KG/m2", x => x * 9.80665, x => x * 0.1), 
                new Unit(this.Name, "at", x => x * 98066.5, x => x * 1.0197),
                new Unit(this.Name, "atm", x => x * 101325, x => x * 9.869),
                new Unit(this.Name, "Tr", x => x * 133.322, x => x * 0.008),
                new Unit(this.Name, "mmHg", x => x * 133.322, x => x * 0.008),
                new Unit(this.Name, "psi [lbf/in2]", x => x * 6894.76, x => x * 0.000145)
            };
        }

    }
}
