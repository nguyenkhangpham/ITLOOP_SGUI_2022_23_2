using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ITLOOP_HFT_2021221.Models;


namespace ITLOOP_HFT_2021221.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<CarStore> CarStores { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Renting> Rentings { get; set; }
        public AppDbContext()
        {
            this.Database.EnsureCreated();
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=ITLOOP_HFT_2021221.Data\Database1.mdf;Integrated Security=True");
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluent syntax/api
            //setting up one-to-one, one-to-many, connections
            modelBuilder.Entity<Car>(entity =>
            {
                entity
                    .HasOne(car => car.CarStore)
                    .WithMany(carstore => carstore.Cars)
                    .HasForeignKey(car => car.CarID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Renting>(entity =>
            {
                entity
                    .HasOne(renting => renting.Car)
                    .WithMany(car => car.Rentings)
                    .HasForeignKey(renting => renting.CarID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            CarStore cs0 = new CarStore() { CarStoreID = 1, Category = "Electric", Infor = "Rental Electric car", ViewCount = 275 };
            CarStore cs1 = new CarStore() { CarStoreID = 2, Category = "Gasoline", Infor = "Rental Gasoline car", ViewCount = 123 };
            CarStore cs2 = new CarStore() { CarStoreID = 3, Category = "Sport", Infor = "Rental Sport car", ViewCount = 750 };
            CarStore cs3 = new CarStore() { CarStoreID = 4, Category = "Festival", Infor = "Rental Festival car", ViewCount = 100 };
            CarStore cs4 = new CarStore() { CarStoreID = 5, Category = "Supercar", Infor = "Rental Supercar", ViewCount = 30 };
            //CarStore cs5 = new CarStore() { CarStoreID = 6, Category = "Touring Car", Title = "Rental Touring car", ViewCount = 1130 };

            Car c0 = new Car() { CarID = 1, CarName = "Lamborgini" };
            Car c1 = new Car() { CarID = 1, CarName = "Honda" };
            Car c2 = new Car() { CarID = 1, CarName = "Hyundai" };
            Car c3 = new Car() { CarID = 1, CarName = "Ferrari" };
            Car c4 = new Car() { CarID = 1, CarName = "Roll-Royce" };
            Car c5 = new Car() { CarID = 1, CarName = "Tesla" };
            Car c6 = new Car() { CarID = 1, CarName = "Porche" };
            Car c7 = new Car() { CarID = 1, CarName = "Ford" };
            Car c8 = new Car() { CarID = 1, CarName = "BMW" };
            Car c9 = new Car() { CarID = 1, CarName = "Audi" };
            //Car c10 = new Car() { CarID = 1, CarName = "Chevrolet" };

            Renting r0 = new Renting() { RentID = 1, RenterName = "Stan Smith", Amount = 350 };
            Renting r1 = new Renting() { RentID = 2, RenterName = "John Barnaby", Amount = 1220 };
            Renting r2 = new Renting() { RentID = 3, RenterName = "Annette Batchelor", Amount = 120 };
            Renting r3 = new Renting() { RentID = 4, RenterName = "Bill Bradbury", Amount = 2600 };
            Renting r4 = new Renting() { RentID = 5, RenterName = "Rachel Brennan", Amount = 570 };
            Renting r5 = new Renting() { RentID = 6, RenterName = "Russell Cartwright", Amount = 3150 };
            Renting r6 = new Renting() { RentID = 7, RenterName = "Roshan Chaudhry", Amount = 120 };
            Renting r7 = new Renting() { RentID = 8, RenterName = "Soran David", Amount = 480 };
            Renting r8 = new Renting() { RentID = 9, RenterName = "Judith Dawson", Amount = 54000 };
            Renting r9 = new Renting() { RentID = 10, RenterName = "Georgina Driver", Amount = 640 };
            Renting r10 = new Renting() { RentID = 11, RenterName = "Bethany Dyson", Amount = 2300 };
            Renting r11= new Renting() { RentID = 12, RenterName = "Mark Flynn", Amount = 1535 };
            Renting r12 = new Renting() { RentID = 13, RenterName = "Daniel Gidney", Amount = 7984 };
            Renting r13 = new Renting() { RentID = 14, RenterName = "Winifred Gorman", Amount = 486 };
            Renting r14 = new Renting() { RentID = 15, RenterName = "Gabriella Green", Amount = 4651 };
            Renting r15 = new Renting() { RentID = 16, RenterName = "Darren Gregory", Amount = 879 };
            Renting r16 = new Renting() { RentID = 17, RenterName = "Philip Hamp", Amount = 200 };
            Renting r17 = new Renting() { RentID = 18, RenterName = "David Hill", Amount = 502 };
            Renting r18 = new Renting() { RentID = 19, RenterName = "Michael Lodge", Amount = 45189 };
            Renting r19 = new Renting() { RentID = 20, RenterName = "Andrew Miller", Amount = 38650 };

            c0.CarStoreID = cs0.CarStoreID;
            c1.CarStoreID = cs0.CarStoreID;
            c2.CarStoreID = cs1.CarStoreID;
            c3.CarStoreID = cs1.CarStoreID;
            c4.CarStoreID = cs2.CarStoreID;
            c5.CarStoreID = cs2.CarStoreID;
            c6.CarStoreID = cs3.CarStoreID;
            c7.CarStoreID = cs3.CarStoreID;
            c8.CarStoreID = cs4.CarStoreID;
            c9.CarStoreID = cs4.CarStoreID;

            r0.CarID = c0.CarID;
            r1.CarID = c1.CarID;
            r2.CarID = c2.CarID;
            r3.CarID = c3.CarID;
            r4.CarID = c4.CarID;
            r5.CarID = c5.CarID;
            r6.CarID = c6.CarID;
            r7.CarID = c7.CarID;
            r8.CarID = c8.CarID;
            r9.CarID = c9.CarID;
            r10.CarID = c0.CarID;
            r11.CarID = c1.CarID;
            r12.CarID = c2.CarID;
            r13.CarID = c3.CarID;
            r14.CarID = c4.CarID;
            r15.CarID = c5.CarID;
            r16.CarID = c6.CarID;
            r17.CarID = c7.CarID;
            r18.CarID = c8.CarID;
            r19.CarID = c9.CarID;

            modelBuilder.Entity<CarStore>().HasData(cs0, cs1, cs2, cs3, cs4);
            modelBuilder.Entity<Car>().HasData(c0, c1, c2, c3, c4, c5, c6, c7, c8, c9);
            modelBuilder.Entity<Renting>().HasData(r0, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16, r17, r18, r19);

        }
    }
}
