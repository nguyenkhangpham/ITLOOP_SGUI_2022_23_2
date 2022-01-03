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
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
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
                    .HasForeignKey(car => car.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Renting>(entity =>
            {
                entity
                    .HasOne(renting => renting.Car)
                    .WithMany(car => car.Rentings)
                    .HasForeignKey(renting => renting.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            CarStore cs0 = new CarStore() { Id = 1, Name = "Store1", Category = "Electric", Infor = "Rental Electric car"};
            CarStore cs1 = new CarStore() { Id = 2, Name = "Store2", Category = "Gasoline", Infor = "Rental Gasoline car" };
            CarStore cs2 = new CarStore() { Id = 3, Name = "Store3", Category = "Sport", Infor = "Rental Sport car"};
            CarStore cs3 = new CarStore() { Id = 4, Name = "Store4", Category = "Festival", Infor = "Rental Festival car"};
            CarStore cs4 = new CarStore() { Id = 5, Name = "Store5", Category = "Supercar", Infor = "Rental Supercar"};

            Car c0 = new Car() { Id = 1, CarStoreID=cs0.Id, CarName = "Lamborgini", SellingPrice = 100000 };
            Car c1 = new Car() { Id = 2, CarStoreID = cs1.Id, CarName = "Honda", SellingPrice = 5000 };
            Car c2 = new Car() { Id = 3, CarStoreID = cs2.Id, CarName = "Hyundai", SellingPrice = 27300 };
            Car c3 = new Car() { Id = 4, CarStoreID = cs3.Id, CarName = "Ferrari", SellingPrice =65500 };
            Car c4 = new Car() { Id = 5, CarStoreID = cs4.Id, CarName = "Roll-Royce", SellingPrice = 50000 };

            Renting r0 = new Renting() { Id = 1, CarId = c0.Id, RenterName = "Stan Smith", Amount = 350 };
            Renting r1 = new Renting() { Id = 2, CarId = c1.Id, RenterName = "John Barnaby", Amount = 1220 };
            Renting r2 = new Renting() { Id = 3, CarId = c2.Id, RenterName = "Annette Batchelor", Amount = 120 };
            Renting r3 = new Renting() { Id = 4, CarId = c3.Id, RenterName = "Bill Bradbury", Amount = 2600 };
            Renting r4 = new Renting() { Id = 5, CarId = c4.Id, RenterName = "Rachel Brennan", Amount = 570 };

            modelBuilder.Entity<CarStore>().HasData(cs0, cs1, cs2, cs3, cs4);
            modelBuilder.Entity<Car>().HasData(c0, c1, c2, c3, c4);
            modelBuilder.Entity<Renting>().HasData(r0, r1, r2, r3, r4);

        }
    }
}
