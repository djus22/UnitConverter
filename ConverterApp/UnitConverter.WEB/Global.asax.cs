﻿using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WpfApp1;

namespace UnitConverter.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IContainer container = CreateContainer();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "Azure")
            {
                builder.RegisterType<StatisticsAzureRepository>().As<IStatisticsRepository>();
            }
            else
            {
                builder.RegisterType<StatisticsLocalDBRepository>().As<IStatisticsRepository>();
            }

            builder.RegisterType<UnitManager>();


            var assembly = typeof(UnitManager).Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("Units")).AsImplementedInterfaces().AsSelf();

            RegisterPlugins(builder);

            return builder.Build();
        }

        private static void RegisterPlugins(ContainerBuilder builder)
        {
            string pluginDir = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin");

            var assemblies = Directory.GetFiles(pluginDir, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();

            foreach (Assembly ass in assemblies)
            {
                builder.RegisterAssemblyTypes(ass).Where(x => x.Name.EndsWith("Units")).AsImplementedInterfaces().AsSelf();
            }

        }
    }
}