using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public abstract class UnitsContainer
    {
        public abstract string Name { get; }
        public abstract List<Unit> _unitList { get; set; }

        public Unit GetUnit(string name)
        {
            return _unitList.Find(x => x.name == name);
        }

        public List<Unit> ToList() {
            return null;
        }

        public List<string> getNames(string type) {

            var ret = new List<string>();

            foreach (Unit unit in _unitList)
            {
                if (unit.type == type)
                {
                    ret.Add(unit.name);
                }
            }

            return ret;
        }

        public bool convert(string rawType, double rawValue, string convertedType, out double convertedValue)
        {
            if (rawType == convertedType)
            {
                convertedValue = rawValue;
                return true;
            }

            // convert to base value
            double inBase = GetUnit(rawType).toBase(rawValue);

            // convert from base value
            convertedValue = Math.Round(GetUnit(convertedType).fromBase(inBase), 2);


            return true;
        }

        public bool AddUnit(string ratio, string newType)
        {
            if (_unitList.Exists(x => x.name == newType))
            {
                return false;
            }

            double ratio_num = double.Parse(ratio);

            _unitList.Add(new Unit(Name, newType, x => x * ratio_num, x => x / ratio_num));

            return true;
        }
    }
}
