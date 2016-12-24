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
    /// <summary>
    /// Логика взаимодействия для EditVehicle.xaml
    /// </summary>
    public partial class EditVehicle : UserControl
    {
        private MainWindow mainWind;
        public EditVehicle(MainWindow mainWind)
        {
            InitializeComponent();
            this.mainWind = mainWind;
            List<Vehicle> vehicles = mainWind.context.Vehicles.ToList();
            for (int i = 0; i < vehicles.Count; i++)
                comboBox.Items.Add(vehicles[i].Id);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Vehicle vehicle = mainWind.context.Vehicles.Find(int.Parse(comboBox.SelectedValue.ToString()));
            richTextBox.Document.Blocks.Add(new Paragraph(new Run(vehicle.ToString())));
            List<Constructor1> constructors = mainWind.context.findByVehicleId(vehicle.Id);
            for (int i = 0; i < constructors.Count; i++)
                richTextBox.Document.Blocks.Add(new Paragraph(new Run(constructors[i].ToString())));
            richTextBox.Document.Blocks.Add(new Paragraph(new Run(""+constructors.Count)));
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            int idVehicle = int.Parse(comboBox.SelectedValue.ToString());
            int idCnstructor = int.Parse(textBox.Text);
            using (var context = new Model1())
            {
                var constructor = mainWind.context.Constructors1.Single(u => u.ID == idCnstructor);
                var vehicle = mainWind.context.Vehicles.Single(r => r.Id == idVehicle);
                vehicle.Constructors.Add(constructor);
                VehicleConstructor1 veh = new VehicleConstructor1();
                veh.Vehicle_Id = vehicle.Id;
                veh.Constructor1_ID = constructor.ID;
                context.ManyToManyRel_Veh_Constr.Add(veh);
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
