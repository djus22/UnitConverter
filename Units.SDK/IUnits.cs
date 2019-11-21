using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public interface IUnits
    {
        string type { get; set; }
        string name { get; set; }
        Func<double, double> toBase { get; set; }
        Func<double, double> fromBase { get; set; }

    }
}
