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

        //UnitManager manager;
        List<UnitsContainer> containers;
        
        private ILifetimeScope scope;

        public ContainersController (IStatisticsRepository repo, UnitManager manager)
        {
            this.containers = manager.GetContainers();
            //this.scope = scope;
            this.repo = repo;
        }

        [Route("api/containers")]
        [HttpGet]
        public List<UnitsContainer> GetContainers()
        {
            //var containers = this.manager.GetContainers();
            return containers;
        }

        [Route("api/containers/convert")]
        [HttpGet]
        public double Convert(string baseType, string convertedType, string baseVal,
            string containerType)
        {
            //var containersList = this.manager.GetContainers();
            UnitsContainer container = containers.Find(m => m.Name == containerType) as UnitsContainer;

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

        [Route("api/containers/addUnit")]
        [HttpGet]
        public void AddUnit(string containerType, string ratio, string newType)
        {
            //var containersList = this.manager.GetContainers();
            UnitsContainer container = this.containers.Find(m => m.Name == containerType) as UnitsContainer;

            container.AddUnit(ratio, newType);
        }

        [Route("api/containers/deleteLastConvert")]
        [HttpGet]
        public string deleteLastConvert()
        {
            repo.RemoveLastRow();
            return "Removed";
        }

    }
}