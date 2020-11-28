using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Car_Rental_WH.Models;

#nullable disable

namespace Car_Rental_WH.Data
{
    public partial class Car_RentalContext : DbContext
    {
        public Car_RentalContext()
        {
        }

        public Car_RentalContext(DbContextOptions<Car_RentalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarBrand> CarBrands { get; set; }
        public virtual DbSet<ComplementaryService> ComplementaryServices { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Hire> Hires { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<staff> staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //   optionsBuilder.UseSqlite("Data Source=D:\\Documents\\Car_Rental.db");
                optionsBuilder.UseSqlServer("Data Source=MORPHEX\\SQLEXPRESS;Initial Catalog=Car_Rental.db;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.VehicleCode);

                entity.Property(e => e.VehicleCode)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Vehicle_code");

                entity.Property(e => e.BodyNumber)
                    .HasColumnType("INT")
                    .HasColumnName("Body_number");

                entity.Property(e => e.CarPrice)
                    .HasColumnType("FLOAT")
                    .HasColumnName("Car_price");

                entity.Property(e => e.EngineNumber)
                    .HasColumnType("INT")
                    .HasColumnName("Engine_number");

                entity.Property(e => e.LastToDate)
                    .IsRequired()
                    .HasColumnType("DATE")
                    .HasColumnName("Last_TO_date");

                entity.Property(e => e.PriceOfTheRentalDay)
                    .HasColumnType("FLOAT")
                    .HasColumnName("Price_of_the_rental_day");

                entity.Property(e => e.RefundMark)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("Refund_mark");

                entity.Property(e => e.RegistrationNumber)
                    .HasColumnType("INT")
                    .HasColumnName("Registration_number");

                entity.Property(e => e.Run).HasColumnType("INT");

                entity.Property(e => e.SpecialMark)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("Special_mark");

                entity.Property(e => e.TheCodeOfTheEmployee)
                    .HasColumnType("INT")
                    .HasColumnName("The_code_of_the_employee");

                entity.Property(e => e.YearOfManufacture)
                    .IsRequired()
                    .HasColumnType("DATE")
                    .HasColumnName("Year_of_manufacture");

                entity.HasOne(d => d.TheCodeOfTheEmployeeNavigation)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.TheCodeOfTheEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<CarBrand>(entity =>
            {
                entity.HasKey(e => e.BrandCode);

                entity.ToTable("Car_brand");

                entity.Property(e => e.BrandCode)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Brand_code");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("VARCHAR(150)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.TechnicalParameters)
                    .IsRequired()
                    .HasColumnType("VARCHAR(150)")
                    .HasColumnName("Technical_parameters");

                entity.Property(e => e.VehicleCode)
                    .HasColumnType("INT")
                    .HasColumnName("Vehicle_code");

                entity.HasOne(d => d.VehicleCodeNavigation)
                    .WithMany(p => p.CarBrands)
                    .HasForeignKey(d => d.VehicleCode);
            });

            modelBuilder.Entity<ComplementaryService>(entity =>
            {
                entity.HasKey(e => e.ServiceCode);

                entity.ToTable("Complementary_services");

                entity.Property(e => e.ServiceCode)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Service_code");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("VARCHAR(150)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Price).HasColumnType("FLOAT");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.ClientCode);

                entity.Property(e => e.ClientCode)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Client_code");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("VARCHAR(150)");

                entity.Property(e => e.DateOfBirth)
                    .IsRequired()
                    .HasColumnType("DATE")
                    .HasColumnName("Date_of_birth");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("Full_name");

                entity.Property(e => e.PassportData)
                    .IsRequired()
                    .HasColumnType("VARCHAR(100)")
                    .HasColumnName("Passport_data");

                entity.Property(e => e.Paul)
                    .IsRequired()
                    .HasColumnType("CHAR(5)");

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasColumnType("CHAR(11)");
            });

            modelBuilder.Entity<Hire>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Hire");

                entity.Property(e => e.ClientCode)
                    .HasColumnType("INT")
                    .HasColumnName("Client_code");

                entity.Property(e => e.DateOfIssue)
                    .IsRequired()
                    .HasColumnType("DATE")
                    .HasColumnName("Date_of_issue");

                entity.Property(e => e.RentalPeriod)
                    .IsRequired()
                    .HasColumnType("DATE")
                    .HasColumnName("Rental_period");

                entity.Property(e => e.ReturnDate)
                    .IsRequired()
                    .HasColumnType("DATE")
                    .HasColumnName("Return_date");

                entity.Property(e => e.ServiceCode)
                    .HasColumnType("INT")
                    .HasColumnName("Service_code");

                entity.Property(e => e.VehicleCode)
                    .HasColumnType("INT")
                    .HasColumnName("Vehicle_code");

                entity.HasOne(d => d.ClientCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ClientCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ServiceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.VehicleCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.VehicleCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.PositionCode);

                entity.Property(e => e.PositionCode)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Position_code");

                entity.Property(e => e.Requirements)
                    .IsRequired()
                    .HasColumnType("VARCHAR(150)");

                entity.Property(e => e.Responsibilities)
                    .IsRequired()
                    .HasColumnType("VARCHAR(150)");

                entity.Property(e => e.Salary).HasColumnType("FLOAT");

                entity.Property(e => e.TheNameOfThePosition)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("The_name_of_the_position");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.HasKey(e => e.StaffCode);

                entity.ToTable("Staff");

                entity.Property(e => e.StaffCode)
                    .HasColumnType("INT")
                    .ValueGeneratedNever()
                    .HasColumnName("Staff_code");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.Age)
                    .IsRequired()
                    .HasColumnType("CHAR(5)");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnType("VARCHAR(50)")
                    .HasColumnName("Full_name");

                entity.Property(e => e.PassportData)
                    .IsRequired()
                    .HasColumnType("VARCHAR(100)")
                    .HasColumnName("Passport_data");

                entity.Property(e => e.Paul)
                    .IsRequired()
                    .HasColumnType("CHAR(5)");

                entity.Property(e => e.PositionCode)
                    .HasColumnType("INT")
                    .HasColumnName("Position_code");

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasColumnType("CHAR(11)");

                entity.HasOne(d => d.PositionCodeNavigation)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.PositionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
