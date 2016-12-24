namespace WpfExamTrying1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public List<Constructor1> findByName(string name)
        {
            var query = from constructor in Constructors1 where constructor.Name == name select constructor;
            return query.ToList();
        }

        public List<Constructor1> findByLastName(string lastName)
        {
            var query = from constructor in Constructors1 where constructor.LastName == lastName select constructor;
            return query.ToList();
        }

        public List<Constructor1> findByYear(int year)
        {
            var query = from constructor in Constructors1 where constructor.Year == year select constructor;
            return query.ToList();
        }

        public List<Constructor1> findByCountry(string country)
        {
            var query = from constructor in Constructors1 where constructor.Country == country select constructor;
            return query.ToList();
        }

        public List<Vehicle> findByBrend(string brend)
        {
            var query = from vehicle in Vehicles where vehicle.Brend == brend select vehicle;
            return query.ToList();
        }

        public List<Vehicle> findByYearVehicle(int year)
        {
            var query = from vehicle in Vehicles where vehicle.Year == year select vehicle;
            return query.ToList();
        }

        public List<Vehicle> findByModel(string model)
        {
            var query = from vehicle in Vehicles where vehicle.Model == model select vehicle;
            return query.ToList();
        }

        public List<Vehicle> findByMark(string mark)
        {
            var query = from vehicle in Vehicles where vehicle.Mark == mark select vehicle;
            return query.ToList();
        }

        public List<Vehicle> findByConstructorId(int id)
        {
            var query = from vehicle in Vehicles
                        join vehId in ManyToManyRel_Veh_Constr on vehicle.Id equals vehId.Vehicle_Id
                        where vehId.Constructor1_ID == id
                        select vehicle;
            return query.ToList();
        }

        public List<Constructor1> findByVehicleId(int id)
        {
            var query = from constructor in Constructors1
                        join vehId in ManyToManyRel_Veh_Constr on constructor.ID equals vehId.Constructor1_ID
                        where vehId.Vehicle_Id == id
                        select constructor;
            return query.ToList();
        }


        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Constructor1> Constructors1 { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        public virtual DbSet<VehicleConstructor1> ManyToManyRel_Veh_Constr{ get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
