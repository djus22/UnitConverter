using Autofac;
using System.Collections.Generic;
using System.Linq;
using WpfApp1.Units;

namespace WpfApp1
{
    public class UnitManager
    {
        ILifetimeScope scope;


        public UnitManager(ILifetimeScope scope) {
            this.scope = scope;
        }

        public UnitManager() {
        }

        public List<UnitsContainer> GetContainers() {
            var containers = scope.Resolve<IEnumerable<UnitsContainer>>().ToList();
            return containers;
        }

    }
}