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
        public abstract List<Unit> _unitList { get; }

        public Unit GetUnit(string name)
        {
            return _unitList.Find(x => x.name == name);
        }

        public List<Unit> ToList() {
            return null;
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
            convertedValue = GetUnit(convertedType).fromBase(inBase);


            return true;
        }

    }
}
