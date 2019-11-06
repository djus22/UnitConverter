using System.Collections.Generic;

namespace WpfApp1
{
    internal class UnitManager
    {
        private List<Unit> _unitList;

        public UnitManager() {
            _unitList = new List<Unit> {
                new Unit("Temperatura", "Celcjusz", (x) => x, (x) => x),
                new Unit("Temperatura", "Farenheit",  (x) => ((x - 32) / 1.8), (x) => (x * 1.8) + 32 ),
                new Unit("Temperatura", "Kelvin", (x) => x - 273.15, (x) => x + 273.15),
                new Unit("Temperatura", "Rankine", (x) => (x - 491.67) * 5/9, (x) => (x + 273.15) * 9/5),
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
                new Unit("Dlugosc", "mila morska", (x) => x * 1852, (x) => x * 0.000539956803),
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


        public List<Unit> GetAllUnits()
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

        public Unit GetUnit(string name) {
            return _unitList.Find(x => x.name == name);
        }


    }
}