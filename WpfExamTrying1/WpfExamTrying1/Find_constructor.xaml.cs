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
    /// Логика взаимодействия для Find_constructor.xaml
    /// </summary>
    public partial class Find_constructor : UserControl
    {
        private MainWindow mainWind;
        public Find_constructor(MainWindow mainWind)
        {
            InitializeComponent();
            comboBox.Items.Add("Name");
            comboBox.Items.Add("Last name");
            comboBox.Items.Add("Country");
            comboBox.Items.Add("Year");
            comboBox.Items.Add("*");
            this.mainWind = mainWind;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Document.Blocks.Clear();
            int index = comboBox.SelectedIndex;
            List<Constructor1> constructors = new List<Constructor1>();
            switch (index)
            {
                case 0:
                    {
                        constructors = mainWind.context.findByName(textBox.Text);
                    } break;
                case 1:
                    {
                        constructors = mainWind.context.findByLastName(textBox.Text);
                    }
                    break;
                case 2:
                    {
                        constructors = mainWind.context.findByCountry(textBox.Text);
                    }
                    break;
                case 3:
                    {
                        constructors = mainWind.context.findByYear(int.Parse(textBox.Text));
                    }
                    break;
                default:
                    {
                        constructors = mainWind.context.Constructors1.ToList();
                    } break;
            }

            MessageBox.Show("Found " + constructors.Count + " constructors");

            for (int i = 0; i < constructors.Count; i++)
            {
                richTextBox.Document.Blocks.Add(new Paragraph(new Run(constructors[i].ToString())));
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedIndex == 4) textBox.IsReadOnly = true;
            else textBox.IsReadOnly = false;
        }
    }
}
