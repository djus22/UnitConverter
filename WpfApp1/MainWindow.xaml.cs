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

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string unitType = null;
        string baseType = null;
        double baseVal = 0;
        string convertedType = null;
        double convertedVal = 0;

        private IStatisticsRepository repo;

        UnitManager unitManager = new UnitManager();


        public MainWindow(IStatisticsRepository repo)
        {
            InitializeComponent();

            this.repo = repo;
            this.UnitTypeComboBox.ItemsSource = unitManager.GetTypes();
            UsageStatisticsGrid.ItemsSource = this.repo.GetAllStatistics();
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
            Converter converter = new Converter();
            double score;

            getProperties();

            if (converter.convert(baseType, baseVal, convertedType, out score))
            {
                this.convertedValTextBox.Text = score.ToString();
            }

            this.repo.AddSingleStatistic(new StatisticDTO() {
                Type = unitType,
                BaseUnit = baseType,
                BaseValue = baseVal,
                ConvertedUnit = convertedType,
                ConvertedValue = convertedVal,
                Time = DateTime.Now
            });

            UsageStatisticsGrid.ItemsSource = this.repo.GetAllStatistics();
        }

        private void getProperties()
        {
            baseType = BaseValueTypeComboBox.Text;
            convertedType = ConvertedValueTypeComboBox.Text;

            Double.TryParse(baseValTextBox.Text, out baseVal);
        }

        private void UnitTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            unitType = UnitTypeComboBox.SelectedValue.ToString();
            List<string> units = unitManager.GetUnitsNamesByType(unitType);
            this.BaseValueTypeComboBox.ItemsSource = units;
            this.ConvertedValueTypeComboBox.ItemsSource = units;
        }


    }
}
