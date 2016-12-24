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
    /// Логика взаимодействия для Create_vehicle.xaml
    /// </summary>
    public partial class Create_vehicle : UserControl
    {
        private MainWindow mainWind;
        public Create_vehicle(MainWindow mainWind)
        {
            InitializeComponent();
            this.mainWind = mainWind;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Vehicle veh = new Vehicle();
            veh.Brend = textBox1.Text;
            veh.Model = textBox2.Text;
            veh.Year = int.Parse(textBox3.Text);
            veh.Mark = textBox4.Text;
            mainWind.context.Vehicles.Add(veh);
            mainWind.context.SaveChanges();
            MessageBox.Show("Successfully added");
            mainWind.mainWind.Children.Clear();
            mainWind.mainWind.Children.Add(new BaseControlls(mainWind));
        }
    }
}
