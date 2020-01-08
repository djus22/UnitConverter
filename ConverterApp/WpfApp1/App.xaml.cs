using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using IContainer = Autofac.IContainer;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IContainer container = CreateContainer();

            this.MainWindow = container.Resolve<MainWindow>();
            //container.Resolve<UnitManager>();
            this.MainWindow.Show();
        }

        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            //if (ConfigurationManager.AppSettings["StatisticsRepository"] == "Azure")
            //{
            //    builder.RegisterType<StatisticsAzureRepository>().As<IStatisticsRepository>();
            //}
            //else
            //{
            //    builder.RegisterType<StatisticsLocalDBRepository>().As<IStatisticsRepository>();
            //}

            builder.RegisterType<MainWindow>();
            //builder.RegisterType<UnitManager>();

            //var assembly = typeof(UnitManager).Assembly;
            //builder.RegisterAssemblyTypes(assembly)
            //    .Where(x => x.Name.EndsWith("Units")).As<UnitsContainer>();

            //RegisterPlugins(builder);

            builder.RegisterType<ContainersApi>();

            return builder.Build();
        }

        //private static void RegisterPlugins(ContainerBuilder builder)
        //{
        //    string assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //    string pluginDir = Path.Combine(assemblyDir, "plugins");

        //    var assemblies = Directory.GetFiles(pluginDir, "*Plugin.dll").Select(Assembly.LoadFrom).ToList();

        //    foreach (Assembly ass in assemblies) {
        //        builder.RegisterAssemblyTypes(ass).Where(x => x.Name.EndsWith("Units")).As<UnitsContainer>();
        //    }
            
        //}
    }
}
