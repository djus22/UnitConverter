using System.Collections.Generic;
using WpfApp1.Units;

namespace WpfApp1
{
    internal class UnitManager
    {
        private List<IUnits> _unitList = new List<IUnits>();

        public UnitManager() {
            addUnits(new TemperatureUnits().UnitsList);
            addUnits(new LengthUnits().UnitsList);
            addUnits(new WeightUnits().UnitsList);
        }

        public void addUnits(List<IUnits> units) {
            _unitList.AddRange(units);
        }

        public List<IUnits> GetAllUnits()
        {
            return _unitList;
        }

        public List<string> GetTypes() {
            List<string> ret = new List<string>();
            foreach (Unit unit in _unitList) {
                if (!ret.Contains(unit.type)) {
                    ret.Add(unit.type);
                }
            }
            return ret;
        }

        public List<Unit> GetUnitsByType(string type) {
            List<Unit> ret = new List<Unit>();
            foreach (Unit unit in _unitList)
            {
                if (unit.type == type) {
                    ret.Add(unit);
                }
            }
            return ret;
        }

        public List<string> GetUnitsNamesByType(string type)
        {
            List<string> ret = new List<string>();
            foreach (Unit unit in _unitList)
            {
                if (unit.type == type)
                {
                    ret.Add(unit.name);
                }
            }
            return ret;
        }

        public IUnits GetUnit(string name) {
            return _unitList.Find(x => x.name == name);
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