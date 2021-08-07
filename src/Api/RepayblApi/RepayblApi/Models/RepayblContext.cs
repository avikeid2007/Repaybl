using System;

using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RepayblApi.Models
{
    public partial class RepayblContext : DbContext
    {
        public RepayblContext()
        {
        }

        public RepayblContext(DbContextOptions<RepayblContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FamilyDetail> FamilyDetails { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<RentTransaction> RentTransactions { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<TenantDocument> TenantDocuments { get; set; }
        public virtual DbSet<TenantOutstanding> TenantOutstandings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<TenantService> TenantServices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<FamilyDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Relationship).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.FamilyDetails)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_79");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_150");
            });

            modelBuilder.Entity<RentTransaction>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BillNo).IsUnicode(false);

                entity.HasOne(d => d.PaidByNavigation)
                    .WithMany(p => p.RentTransactions)
                    .HasForeignKey(d => d.PaidBy)
                    .HasConstraintName("FK_100");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RentTransactions)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_103");
                entity.HasIndex(x => x.BillNo).IsUnique();
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RoomNo).IsUnicode(false);

                entity.HasOne(d => d.CurrentTenant)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.CurrentTenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_52");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_37");
                entity.HasIndex(x => x.RoomNo).IsUnique();
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);
                entity.HasIndex(x => x.Email).IsUnique();
                entity.HasIndex(x => x.Phone).IsUnique();

            });

            modelBuilder.Entity<TenantDocument>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FileExtension).IsUnicode(false);

                entity.Property(e => e.MimeType).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.TenantDocuments)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_117");
            });

            modelBuilder.Entity<TenantOutstanding>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.TenantOutstandings)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_144");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.HasIndex(x => x.Email).IsUnique();
                entity.HasIndex(x => x.Phone).IsUnique();
            });
            modelBuilder.Entity<Service>().HasData(new Service
            {
                Id = Guid.NewGuid(),
                Created = DateTimeOffset.Now,
                CreatedBy = "Admin",
                Name = "Rent"
            }, new Service
            {
                Id = Guid.NewGuid(),
                Created = DateTimeOffset.Now,
                CreatedBy = "Admin",
                Name = "Electricity"
            }, new Service
            {
                Id = Guid.NewGuid(),
                Created = DateTimeOffset.Now,
                CreatedBy = "Admin",
                Name = "Water"
            }, new Service
            {
                Id = Guid.NewGuid(),
                Created = DateTimeOffset.Now,
                CreatedBy = "Admin",
                Name = "Cable"
            }, new Service
            {
                Id = Guid.NewGuid(),
                Created = DateTimeOffset.Now,
                CreatedBy = "Admin",
                Name = "Internet"
            }, new Service
            {
                Id = Guid.NewGuid(),
                Created = DateTimeOffset.Now,
                CreatedBy = "Admin",
                Name = "Gas"
            }, new Service
            {
                Id = Guid.NewGuid(),
                Created = DateTimeOffset.Now,
                CreatedBy = "Admin",
                Name = "Trash"
            }, new Service
            {
                Id = Guid.NewGuid(),
                Created = DateTimeOffset.Now,
                CreatedBy = "Admin",
                Name = "Miscellaneous"
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
