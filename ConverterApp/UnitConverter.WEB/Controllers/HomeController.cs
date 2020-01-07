using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WpfApp1;
using WpfApp1.Units;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UnitConverter.WEB.Controllers
{
    public class HomeController : Controller
    {
        private IStatisticsRepository repo;

        UnitManager manager;
        private ILifetimeScope scope;

        public HomeController() { }

        public HomeController(ILifetimeScope scope, IStatisticsRepository repo, UnitManager manager)
        {
            this.manager = manager;
            this.scope = scope;
            this.repo = repo;
        }

        public ActionResult Index()
        {
            var containers = this.manager.GetContainers();
            
            return View(containers);
        }

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

        public ActionResult History()
        {

            return View(repo.GetAllStatistics());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}