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
    /// Логика взаимодействия для Delete_vehicle.xaml
    /// </summary>
    public partial class Delete_vehicle : UserControl
    {
        private MainWindow mainWind;
        public Delete_vehicle(MainWindow mainWind)
        {
            InitializeComponent();
            this.mainWind = mainWind;
            var listOfVehicles = mainWind.context.Vehicles.ToList();
            for (int i = 0; i < listOfVehicles.Count; i++)
            {
                comboBox.Items.Add(listOfVehicles[i].Id);
            }
            richTextBox.Document.Blocks.Clear();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int val = int.Parse(comboBox.SelectedValue.ToString());
            mainWind.context.Vehicles.Remove(mainWind.context.Vehicles.Find(val));
            mainWind.context.SaveChanges();
            mainWind.mainWind.Children.Clear();
            MessageBox.Show("Successfully deleted");
            mainWind.mainWind.Children.Add(new Delete_vehicle(mainWind));
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            richTextBox.Document.Blocks.Clear();
            int val = int.Parse(comboBox.SelectedValue.ToString());
            richTextBox.Document.Blocks.Add(new Paragraph(new Run(mainWind.context.Vehicles.Find(val).ToString())));
        }
    }
}
