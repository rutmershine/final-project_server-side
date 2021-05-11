using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Models
{
    public partial class DeliverPackagesDBContext : DbContext
    {
        public DeliverPackagesDBContext()
        {
        }

        public DeliverPackagesDBContext(DbContextOptions<DeliverPackagesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Constraints> Constraints { get; set; }
        public virtual DbSet<DriverConstraints> DriverConstraints { get; set; }
        public virtual DbSet<Drivers> Drivers { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<PackageConstraints> PackageConstraints { get; set; }
        public virtual DbSet<PackageDescription> PackageDescription { get; set; }
        public virtual DbSet<Sizes> Sizes { get; set; }
        public virtual DbSet<Travels> Travels { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database = DeliverPackagesDB; Trusted_Connection= True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.Lat)
                    .IsRequired()
                    .HasColumnName("lat");

                entity.Property(e => e.Lng)
                    .IsRequired()
                    .HasColumnName("lng");
            });

            modelBuilder.Entity<Constraints>(entity =>
            {
                entity.HasKey(e => e.ConstraintId)
                    .HasName("PK__constrai__CC3E7B3D811C72B9");

                entity.ToTable("constraints");

                entity.Property(e => e.ConstraintId).HasColumnName("constraint_id");

                entity.Property(e => e.ConstraintName)
                    .HasColumnName("constraint_name")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<DriverConstraints>(entity =>
            {
                entity.HasKey(e => new { e.DriverPhone, e.ConstraintId })
                    .HasName("PK__driverCo__387831C69873ECAB");

                entity.ToTable("driverConstraints");

                entity.Property(e => e.DriverPhone)
                    .HasColumnName("driver_phone")
                    .HasMaxLength(10);

                entity.Property(e => e.ConstraintId).HasColumnName("constraint_id");

                entity.HasOne(d => d.Constraint)
                    .WithMany(p => p.DriverConstraints)
                    .HasForeignKey(d => d.ConstraintId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_constraint_idD");

                entity.HasOne(d => d.DriverPhoneNavigation)
                    .WithMany(p => p.DriverConstraints)
                    .HasForeignKey(d => d.DriverPhone)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_driver_id");
            });

            modelBuilder.Entity<Drivers>(entity =>
            {
                entity.HasKey(e => e.DriverPhone)
                    .HasName("PK__drivers__F4BBD6757354C665");

                entity.ToTable("drivers");

                entity.Property(e => e.DriverPhone)
                    .HasColumnName("driver_phone")
                    .HasMaxLength(10);

                entity.Property(e => e.MaxDeviation).HasColumnName("max_deviation");

                entity.Property(e => e.MaxPackageNum).HasColumnName("max_package_num");

                entity.Property(e => e.MaxPackageSize).HasColumnName("max_package_size");

                entity.HasOne(d => d.DriverPhoneNavigation)
                    .WithOne(p => p.Drivers)
                    .HasForeignKey<Drivers>(d => d.DriverPhone)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_driver_phone");

                entity.HasOne(d => d.MaxPackageSizeNavigation)
                    .WithMany(p => p.Drivers)
                    .HasForeignKey(d => d.MaxPackageSize)
                    .HasConstraintName("FK_max_Package_size");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.ToTable("package");

                entity.Property(e => e.PackageId).HasColumnName("package_id");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("date_from")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTo)
                    .HasColumnName("date_to")
                    .HasColumnType("datetime");

                entity.Property(e => e.DestAddressId).HasColumnName("dest_address_id");

                entity.Property(e => e.DriveId).HasColumnName("drive_id");

                entity.Property(e => e.GetterPhone)
                    .HasColumnName("getter_phone")
                    .HasMaxLength(10);

                entity.Property(e => e.SenderPhone)
                    .HasColumnName("sender_phone")
                    .HasMaxLength(10);

                entity.Property(e => e.SourceAddressId).HasColumnName("source_address_id");

                entity.HasOne(d => d.DestAddress)
                    .WithMany(p => p.PackageDestAddress)
                    .HasForeignKey(d => d.DestAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dest_address_id");

                entity.HasOne(d => d.Drive)
                    .WithMany(p => p.Package)
                    .HasForeignKey(d => d.DriveId)
                    .HasConstraintName("FK_drive_id");

                entity.HasOne(d => d.SourceAddress)
                    .WithMany(p => p.PackageSourceAddress)
                    .HasForeignKey(d => d.SourceAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_source_address_id");
            });

            modelBuilder.Entity<PackageConstraints>(entity =>
            {
                entity.HasKey(e => new { e.PackageId, e.ConstraintId })
                    .HasName("PK__package___AF478D5B1A86A934");

                entity.ToTable("package_constraints");

                entity.Property(e => e.PackageId).HasColumnName("package_id");

                entity.Property(e => e.ConstraintId).HasColumnName("constraint_id");

                entity.HasOne(d => d.Constraint)
                    .WithMany(p => p.PackageConstraints)
                    .HasForeignKey(d => d.ConstraintId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_constraint_id");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.PackageConstraints)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_package_id");
            });

            modelBuilder.Entity<PackageDescription>(entity =>
            {
                entity.HasKey(e => e.PackDescId)
                    .HasName("PK__packageD__1AD60C08733EB283");

                entity.ToTable("packageDescription");

                entity.Property(e => e.PackDescId).HasColumnName("pack_desc_id");

                entity.Property(e => e.IisFood).HasColumnName("Iis_food");

                entity.Property(e => e.IsExpensive).HasColumnName("is_expensive");

                entity.Property(e => e.IsFragile).HasColumnName("is_fragile");

                entity.Property(e => e.SizeId).HasColumnName("size_id");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.PackageDescription)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_size_id");
            });

            modelBuilder.Entity<Sizes>(entity =>
            {
                entity.HasKey(e => e.SizeId)
                    .HasName("PK__sizes__0DCACE312D1906BF");

                entity.ToTable("sizes");

                entity.Property(e => e.SizeId).HasColumnName("size_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(100);

                entity.Property(e => e.SizeName)
                    .IsRequired()
                    .HasColumnName("size_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Travels>(entity =>
            {
                entity.HasKey(e => e.TravelId)
                    .HasName("PK__travels__BF088B5C7517F3E6");

                entity.ToTable("travels");

                entity.Property(e => e.TravelId).HasColumnName("travel_id");

                entity.Property(e => e.DestAddressId).HasColumnName("dest_address_id");

                entity.Property(e => e.DriverId).HasColumnName("driver_id");

                entity.Property(e => e.LeavingDate)
                    .HasColumnName("leaving_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceAddressId).HasColumnName("source_address_id");

                entity.HasOne(d => d.DestAddress)
                    .WithMany(p => p.TravelsDestAddress)
                    .HasForeignKey(d => d.DestAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dest_address");

                entity.HasOne(d => d.SourceAddress)
                    .WithMany(p => p.TravelsSourceAddress)
                    .HasForeignKey(d => d.SourceAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_source_address");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Phone)
                    .HasName("PK__users__B43B145E3A2BE0C2");

                entity.ToTable("users");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(10);

                entity.Property(e => e.EmailAdress)
                    .HasColumnName("email_adress")
                    .HasMaxLength(25);

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(15);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
