using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public interface IUnitsContainer
    {
        string Name { get; }
        List<IUnits> UnitsList { get; }
    }
}
