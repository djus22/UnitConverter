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

        UsageStatisticsModel db = new UsageStatisticsModel();

        //List<Unit> unitList = Unit.GetAllUnits();

        UnitManager unitManager = new UnitManager();

        


        public MainWindow()
        {
            InitializeComponent();

            this.UnitTypeComboBox.ItemsSource = unitManager.GetTypes();
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

            UsageStatistics item = new UsageStatistics();

            item.Type = unitType;
            item.BaseUnit = baseType;
            item.BaseValue = baseVal;
            item.ConvertedUnit = convertedType;
            item.ConvertedValue = convertedVal;
            item.Time = DateTime.Now;


            db.UsageStatistics.Add(item);
            db.SaveChanges();

            UsageStatisticsGrid.ItemsSource = db.UsageStatistics.ToList();
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
