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
    public partial class MainWindow : Window
    {
        public Model1 context = new Model1();
        public MainWindow()
        {
            InitializeComponent();
            mainWind.Children.Add(new EditConstructor(this));
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Document.Blocks.Clear();
            Model1 context = new Model1();
            List<Constructor1> constructors = context.Constructors1.ToList();
            for (int i = 0; i < constructors.Count; i++)
            {
                richTextBox.Document.Blocks.Add(new Paragraph(new Run("Name: "+constructors[i].Name+",last name: "+constructors[i].LastName+",country: "+constructors[i].Country+",year: "+constructors[i].Year)));
            }
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainWind.Children.Clear();
            mainWind.Children.Add(new Create_constructor(this));
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            mainWind.Children.Clear();
            mainWind.Children.Add(new Delete_constructor(this));
        }
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
        }
        private void MenuItem_Click3(object sender, RoutedEventArgs e)
        {
            mainWind.Children.Clear();
            mainWind.Children.Add(new Create_vehicle(this));
        }
        private void MenuItem_Click4(object sender, RoutedEventArgs e)
        {
            mainWind.Children.Clear();
            mainWind.Children.Add(new Delete_vehicle(this));
        }
        private void MenuItem_Click5(object sender, RoutedEventArgs e)
        {
        }
    }
}
