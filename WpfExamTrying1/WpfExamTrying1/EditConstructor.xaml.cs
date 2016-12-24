using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public partial class EditConstructor : UserControl
    {
        private MainWindow mainWind;
        private int count = 0;
        public EditConstructor(MainWindow mainWind)
        {
            InitializeComponent();
            this.mainWind = mainWind;
            List<Constructor1> constructors = mainWind.context.Constructors1.ToList();
            for (int i = 0; i < constructors.Count; i++){
                comboBox.Items.Add(constructors[i].ID);
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Constructor1 constructor = mainWind.context.Constructors1.Find(int.Parse(comboBox.SelectedValue.ToString()));
            richTextBox.Document.Blocks.Add(new Paragraph(new Run(""+constructor.ToString())));
            List<Vehicle> vehicles = mainWind.context.findByConstructorId(constructor.ID);
            for (int i = 0; i < vehicles.Count; i++)
            {
                richTextBox.Document.Blocks.Add(new Paragraph(new Run("" + vehicles[i].ToString())));
            }
            richTextBox.Document.Blocks.Add(new Paragraph(new Run(vehicles.Count+"")));
        }
        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            int idCnstructor = int.Parse(comboBox.SelectedValue.ToString());
            int idVehicle = int.Parse(textBox.Text);
            using (var context = new Model1())
            {
                var constructor = mainWind.context.Constructors1.Single(u => u.ID == idCnstructor);
                var role = mainWind.context.Vehicles.Single(r => r.Id == idVehicle);
                constructor.Vehicles.Add(role);
                context.SaveChanges();
            }
        }
        private void button_Copy_Click1(object sender, RoutedEventArgs e)
        {
            mainWind.mainWind.Children.Clear();
            mainWind.mainWind.Children.Add(new BaseControlls(mainWind));
        }
    }
}
