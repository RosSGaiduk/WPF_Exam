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
    /// Логика взаимодействия для BaseControlls.xaml
    /// </summary>
    public partial class BaseControlls : UserControl
    {
        private MainWindow mainWind;
        public BaseControlls(MainWindow maiWind)
        {
            InitializeComponent();
            this.mainWind = maiWind;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWind.mainWind.Children.Clear();
            mainWind.mainWind.Children.Add(new Create_constructor(mainWind));
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            mainWind.mainWind.Children.Clear();
            mainWind.mainWind.Children.Add(new Delete_constructor(mainWind));
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            mainWind.mainWind.Children.Clear();
            mainWind.mainWind.Children.Add(new Find_constructor(mainWind));
        }

        private void MenuItem_Click3(object sender, RoutedEventArgs e)
        {

            mainWind.mainWind.Children.Clear();
            mainWind.mainWind.Children.Add(new Create_vehicle(mainWind));
        }

        private void MenuItem_Click4(object sender, RoutedEventArgs e)
        {
            mainWind.mainWind.Children.Clear();
            mainWind.mainWind.Children.Add(new Delete_vehicle(mainWind));
        }

        private void MenuItem_Click5(object sender, RoutedEventArgs e)
        {
            mainWind.mainWind.Children.Clear();
            mainWind.mainWind.Children.Add(new FindVehicle(mainWind));
        }

       
    }
}
