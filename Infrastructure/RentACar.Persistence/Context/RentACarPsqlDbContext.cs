using Microsoft.EntityFrameworkCore;
using RentACar.Domain.Mappings;
using RentACar.Domain.Models;
using RentACar.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Context
{
    public class RentACarPsqlDbContext:DbContext
    {
        public RentACarPsqlDbContext(DbContextOptions<RentACarPsqlDbContext> options):base(options)
        {
            
        }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarLocation> CarLocations { get; set; }
        public virtual DbSet<CarOption> CarOptions { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<ReservationOption> ReservationOptions { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<About> Abouts { get; set; }

        private void Seed(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.Parse("822E044B-5656-4B44-AD0F-01D7761E2CBE"),
                CreateDate = DateTime.Now,
                CreatedUser = "Admin",
                EMailAddress = "icb1742@gmail.com",
                Password = "17421742",
                FirstName = "Süper",
                LastName = "Admin",
                IsActive = true,

            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.Parse("C326EE05-4878-4219-958D-AD3CAEFA4E11"),
                CreateDate = DateTime.Now,
                CreatedUser = "Admin",
                EMailAddress = "eagledenizcilik@outlook.com.tr",
                Password = "Eagle0204.",
                FirstName = "Alican",
                LastName = "Kartal",
                IsActive = true,

            });

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Car Location İlişkiler
            modelBuilder.Entity<CarLocation>().HasOne(c => c.Car).WithMany(c => c.CarLocations).HasForeignKey(c => c.CarId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<CarLocation>().HasOne(c => c.Location).WithMany(c => c.CarLocations).HasForeignKey(c => c.LocationId).OnDelete(DeleteBehavior.NoAction);
            //Car Option İlişkileri
            modelBuilder.Entity<CarOption>().HasOne(c => c.Car).WithMany(c => c.CarOptions).HasForeignKey(c => c.CarId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<CarOption>().HasOne(c => c.Option).WithMany(c => c.CarOptions).HasForeignKey(c => c.OptionId).OnDelete(DeleteBehavior.NoAction);
            //Reservation ilişkileri
            modelBuilder.Entity<Reservation>().HasOne(c => c.Car).WithMany(c => c.Reservations).HasForeignKey(c => c.CarId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Reservation>().HasOne(c => c.EndLocation).WithMany(c => c.EndLocations).HasForeignKey(c => c.EndLocationId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Reservation>().HasOne(c => c.StartLocation).WithMany(c => c.StartLocations).HasForeignKey(c => c.StartLocationId).OnDelete(DeleteBehavior.NoAction);
            //ReservationOption İlişkileri
            modelBuilder.Entity<ReservationOption>().HasOne(c => c.Reservation).WithMany(c => c.ReservationOptions).HasForeignKey(c => c.ReservationId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ReservationOption>().HasOne(c => c.Option).WithMany(c => c.ReservationOptions).HasForeignKey(c => c.OptionId).OnDelete(DeleteBehavior.NoAction);



            modelBuilder.Entity<BaseModel>().UseTpcMappingStrategy();
            modelBuilder.ApplyConfiguration(new CarMap());
            modelBuilder.ApplyConfiguration(new CarLocationMap());
            modelBuilder.ApplyConfiguration(new CarOptionMap());
            modelBuilder.ApplyConfiguration(new LocationMap());
            modelBuilder.ApplyConfiguration(new OptionMap());
            modelBuilder.ApplyConfiguration(new ReservationMap());
            modelBuilder.ApplyConfiguration(new ReservationOptionMap());
            modelBuilder.ApplyConfiguration(new ServiceMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PartnerMap());
            modelBuilder.ApplyConfiguration(new AboutMap());
            Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
