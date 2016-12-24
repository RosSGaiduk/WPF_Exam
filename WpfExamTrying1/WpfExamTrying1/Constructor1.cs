namespace WpfExamTrying1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class Constructor1
    {
        public Constructor1() {
            Vehicles = new List<Vehicle>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Year { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }

        public override string ToString()
        {
            return "Name: " + Name + ", last name: " + LastName + ", country: " + Country + ", year: " + Year;
        }
    }
}
