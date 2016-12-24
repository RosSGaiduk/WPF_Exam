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
    /// Логика взаимодействия для Create_constructor.xaml
    /// </summary>
    public partial class Create_constructor : UserControl
    {
        private MainWindow mainWind;
        public Create_constructor(MainWindow mainWind)
        {
            InitializeComponent();
            this.mainWind = mainWind;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Constructor1 constructor = new Constructor1();
            constructor.Name = textBox1.Text;
            constructor.LastName = textBox2.Text;
            constructor.Country = textBox3.Text;
            constructor.Year = int.Parse(textBox4.Text);
            mainWind.context.Constructors1.Add(constructor);
            mainWind.context.SaveChanges();
            MessageBox.Show("Successfully added");
            mainWind.mainWind.Children.Clear();
            mainWind.mainWind.Children.Add(new BaseControlls(mainWind));
        }
    }
}
