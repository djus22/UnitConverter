namespace WpfApp1
{
    class Converter
    {
        private UnitManager unitManager = new UnitManager();

        public bool convert(string rawType, double rawValue, string convertedType, out double convertedValue) {
            if (rawType == convertedType) {
                convertedValue = rawValue;
                return true;
            }

            // convert to base value
            double inBase = unitManager.GetUnit(rawType).toBase(rawValue);

            // convert from base value
            convertedValue = unitManager.GetUnit(convertedType).fromBase(inBase);
            

            return true;
        }

        
    }
}
