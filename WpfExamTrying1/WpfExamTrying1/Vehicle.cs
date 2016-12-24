using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExamTrying1
{
    public partial class Vehicle
    {
        public Vehicle() {
            Constructors = new List<Constructor1>();
        }
        public int Id { get; set; }
        public string Brend { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Mark { get; set; }
        public virtual ICollection<Constructor1> Constructors { get; set; }
        public override string ToString(){
            return "Brend: " + Brend + ", model: " + Model + ", year: " + Year + ", mark: " + Mark;
        }
    }
}
