using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
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
            this.MainWindow.Show();
        }

        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "Azure")
            {
                builder.RegisterType<StatisticsAzureRepository>().As<IStatisticsRepository>();
            }
            else
            {
                builder.RegisterType<StatisticsLocalDBRepository>().As<IStatisticsRepository>();
            }

            builder.RegisterType<MainWindow>();

            return builder.Build();
        }
    }
}
