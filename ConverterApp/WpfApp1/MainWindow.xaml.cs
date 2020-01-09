using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static WpfApp1.ContainersApi;
//using WpfApp1.Units;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UnitsContainer currentContainer;
        string unitType = null;
        string baseType = null;
        double baseVal = 0;
        string convertedType = null;
        double convertedVal = 0;


        //private istatisticsrepository repo;
        private ContainersApi containers;

        //List<UnitsContainer> unitsContainers;

        //public MainWindow(IStatisticsRepository repo, UnitManager manager)
        public MainWindow(ContainersApi containers)
        {
            InitializeComponent();
            //this.repo = repo;
            //this.unitsContainers = manager.GetContainers();
            //this.UnitTypeComboBox.ItemsSource = this.unitsContainers;
            //UsageStatisticsGrid.ItemsSource = this.repo.GetAllStatistics();

            this.containers = containers;
            this.UnitTypeComboBox.ItemsSource = containers.GetContainers();
            UsageStatisticsGrid.ItemsSource = containers.GetAllStatistics();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Double.TryParse(this.baseValTextBox.Text, out baseVal);
        }

        private void convertedValTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Double.TryParse(this.convertedValTextBox.Text, out convertedVal);
        }

        private void CountButtonClicked(object sender, RoutedEventArgs e)
        {
            double score;

            getProperties();

            

            if (currentContainer.Convert(baseType, baseVal, convertedType, out score))
            {
                this.convertedValTextBox.Text = score.ToString();
            }
            //this.repo.AddSingleStatistic(new StatisticDTO() {
            //    Type = unitType,
            //    BaseUnit = baseType,
            //    BaseValue = baseVal,
            //    ConvertedUnit = convertedType,
            //    ConvertedValue = convertedVal,
            //    Time = DateTime.Now
            //});

            //UsageStatisticsGrid.ItemsSource = this.repo.GetAllStatistics();
            UsageStatisticsGrid.ItemsSource = containers.GetAllStatistics();

        }

        private void getProperties()
        {
            var baseUnit = (Unit)BaseValueTypeComboBox.SelectedItem;
            baseType = baseUnit.name;

            var convertedUnit = (Unit)ConvertedValueTypeComboBox.SelectedItem;
            convertedType = convertedUnit.name;

            Double.TryParse(baseValTextBox.Text, out baseVal);
        }

        private void UnitTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            currentContainer = (UnitsContainer)UnitTypeComboBox.SelectedValue;
            unitType = currentContainer.Name;

            List<Unit> units = currentContainer._unitList;
            this.ConvertedValueTypeComboBox.ItemsSource = units;
            this.BaseValueTypeComboBox.ItemsSource = units;
        }


    }
}
