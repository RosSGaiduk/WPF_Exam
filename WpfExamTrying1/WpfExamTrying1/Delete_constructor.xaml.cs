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
    /// Логика взаимодействия для Delete_constructor.xaml
    /// </summary>
    public partial class Delete_constructor : UserControl
    {
        private MainWindow wind;
        public Delete_constructor(MainWindow maiWind)
        {
            InitializeComponent();
            this.wind = maiWind;

            var listOfConstructors = wind.context.Constructors1.ToList();
            for (int i = 0; i < listOfConstructors.Count; i++)
            {
                comboBox.Items.Add(listOfConstructors[i].ID);
            }
            richTextBox.Document.Blocks.Clear();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            int val = int.Parse(comboBox.SelectedValue.ToString());
            wind.context.Constructors1.Remove(wind.context.Constructors1.Find(val));
            wind.context.SaveChanges();
            wind.mainWind.Children.Clear();
            MessageBox.Show("Successfully deleted");
            wind.mainWind.Children.Add(new Delete_constructor(wind));
        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            richTextBox.Document.Blocks.Clear();
            int val = int.Parse(comboBox.SelectedValue.ToString());
            richTextBox.Document.Blocks.Add(new Paragraph(new Run(wind.context.Constructors1.Find(val).ToString())));
        }
    }
}
