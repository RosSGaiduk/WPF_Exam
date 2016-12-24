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

namespace WpfExamTrying1
{
    /// <summary>
    /// Логика взаимодействия для FindVehicle.xaml
    /// </summary>
    public partial class FindVehicle : UserControl
    {
        private MainWindow mainWind;
        public FindVehicle(MainWindow mainWind)
        {
            InitializeComponent();
            comboBox.Items.Add("Brend");
            comboBox.Items.Add("Model");
            comboBox.Items.Add("Year");
            comboBox.Items.Add("Mark");
            comboBox.Items.Add("*");
            this.mainWind = mainWind;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedIndex == 4) textBox.IsReadOnly = true;
            else textBox.IsReadOnly = false;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Document.Blocks.Clear();
            int index = comboBox.SelectedIndex;
            List<Vehicle> vehicles = new List<Vehicle>();
            switch (index)
            {
                case 0:
                    {
                        vehicles = mainWind.context.findByBrend(textBox.Text);
                    }
                    break;
                case 1:
                    {
                        vehicles = mainWind.context.findByModel(textBox.Text);
                    }
                    break;
                case 2:
                    {
                        vehicles = mainWind.context.findByYearVehicle(int.Parse(textBox.Text));
                    }
                    break;
                case 3:
                    {
                        vehicles = mainWind.context.findByMark(textBox.Text);
                    }
                    break;
                default:
                    {
                        vehicles = mainWind.context.Vehicles.ToList();
                    }
                    break;
            }

            MessageBox.Show("Found " + vehicles.Count + " constructors");

            for (int i = 0; i < vehicles.Count; i++)
            {
                richTextBox.Document.Blocks.Add(new Paragraph(new Run(vehicles[i].ToString())));
            }
        }
    }
}
