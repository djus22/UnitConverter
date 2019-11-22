using System;
using System.Collections;
using System.Collections.Generic;


namespace WpfApp1
{
    public class Unit
    {

        public string type { get; set; }
        public string name { get; set; }
        public Func<double, double> toBase { get; set; }
        public Func<double, double> fromBase { get; set; }

        public Unit(string type, string name, Func<double, double> toBase, Func<double, double> fromBase) {
            this.type = type;
            this.name = name;
            this.toBase = toBase;
            this.fromBase= fromBase;
        }

        public Unit()
        {
        }
        
    }
}