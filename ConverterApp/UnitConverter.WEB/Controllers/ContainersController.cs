using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WpfApp1;

namespace UnitConverter.WEB.Controllers
{
    public class ContainersController : ApiController
    {
        private IStatisticsRepository repo;

        UnitManager manager;
        private ILifetimeScope scope;

        public ContainersController (ILifetimeScope scope, IStatisticsRepository repo, UnitManager manager)
        {
            this.manager = manager;
            this.scope = scope;
            this.repo = repo;
        }

        public List<UnitsContainer> GetContainers()
        {
            var containers = this.manager.GetContainers();
            return containers;
        }

        [Route("api/containers/convert")]
        [HttpGet]
        public double Convert(string baseType, string convertedType, string baseVal,
            string containerType)
        {
            var containersList = this.manager.GetContainers();
            UnitsContainer container = containersList.Find(m => m.Name == containerType) as UnitsContainer;

            double score;
            double baseValue = double.Parse(baseVal);

            container.convert(baseType, baseValue, convertedType, out score);

            this.repo.AddSingleStatistic(new StatisticDTO()
            {
                Type = containerType,
                BaseUnit = baseType,
                BaseValue = baseValue,
                ConvertedUnit = convertedType,
                ConvertedValue = score,
                Time = DateTime.Now
            });


            return score;
        }

        [Route("api/containers/getallstatistics")]
        [HttpGet]
        public IEnumerable<StatisticDTO> GetAllStatistics()
        {
            return repo.GetAllStatistics();
        }
    }
}