﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepayblApi.Models;

namespace RepayblApi.Migrations
{
    [DbContext(typeof(RepayblContext))]
    [Migration("20210608135347_AddUserID")]
    partial class AddUserID
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RepayblApi.Models.FamilyDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTimeOffset?>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Relationship")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("State")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Zip")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "TenantId" }, "fkIdx_79");

                    b.ToTable("FamilyDetails");
                });

            modelBuilder.Entity("RepayblApi.Models.Property", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FloorCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Remarks")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("State")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Zip")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "fkIdx_151");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("RepayblApi.Models.RentTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BillDate")
                        .HasColumnType("datetime");

                    b.Property<int>("BillMonth")
                        .HasColumnType("int");

                    b.Property<string>("BillNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("BillYear")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CurrentReading")
                        .HasColumnType("int");

                    b.Property<decimal>("ElectricityBillAmount")
                        .HasColumnType("numeric(8,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PaidAmount")
                        .HasColumnType("numeric(8,2)");

                    b.Property<Guid?>("PaidBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("PaidDate")
                        .HasColumnType("datetime");

                    b.Property<int>("PreviousReading")
                        .HasColumnType("int");

                    b.Property<decimal>("RentAmount")
                        .HasColumnType("numeric(8,2)");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric(8,2)");

                    b.Property<int>("TotalPaybleMonth")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BillNo")
                        .IsUnique();

                    b.HasIndex(new[] { "PaidBy" }, "fkIdx_100");

                    b.HasIndex(new[] { "RoomId" }, "fkIdx_103");

                    b.ToTable("RentTransactions");
                });

            modelBuilder.Entity("RepayblApi.Models.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CurrentTenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastBillPaidDate")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("LastPaidBillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("RoomFloorNo")
                        .HasColumnType("int");

                    b.Property<string>("RoomNo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("RoomNo")
                        .IsUnique();

                    b.HasIndex(new[] { "LastPaidBillId" }, "fkIdx_134");

                    b.HasIndex(new[] { "PropertyId" }, "fkIdx_37");

                    b.HasIndex(new[] { "CurrentTenantId" }, "fkIdx_52");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("RepayblApi.Models.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("RepayblApi.Models.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DOJ")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("FamilyMamberCount")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTimeOffset?>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("State")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Zip")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("RepayblApi.Models.TenantDocument", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTimeOffset?>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Payload")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "TenantId" }, "fkIdx_117");

                    b.ToTable("TenantDocuments");
                });

            modelBuilder.Entity("RepayblApi.Models.TenantOutstanding", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("TotalAdvance")
                        .HasColumnType("numeric(8,2)");

                    b.Property<decimal?>("TotalPending")
                        .HasColumnType("numeric(8,2)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "TenantId" }, "fkIdx_144");

                    b.ToTable("TenantOutstandings");
                });

            modelBuilder.Entity("RepayblApi.Models.TenantService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BillType")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("FixedAmount")
                        .HasColumnType("numeric(8,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RatePerUnit")
                        .HasColumnType("numeric(8,2)");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.HasIndex("TenantId");

                    b.ToTable("TenantServices");
                });

            modelBuilder.Entity("RepayblApi.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsAuth")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPropertyOwner")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTimeOffset?>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("State")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("Zip")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("Phone")
                        .IsUnique()
                        .HasFilter("[Phone] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RepayblApi.Models.FamilyDetail", b =>
                {
                    b.HasOne("RepayblApi.Models.Tenant", "Tenant")
                        .WithMany("FamilyDetails")
                        .HasForeignKey("TenantId")
                        .HasConstraintName("FK_79")
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("RepayblApi.Models.Property", b =>
                {
                    b.HasOne("RepayblApi.Models.User", "User")
                        .WithMany("Properties")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_150")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RepayblApi.Models.RentTransaction", b =>
                {
                    b.HasOne("RepayblApi.Models.Tenant", "PaidByNavigation")
                        .WithMany("RentTransactions")
                        .HasForeignKey("PaidBy")
                        .HasConstraintName("FK_100");

                    b.HasOne("RepayblApi.Models.Room", "Room")
                        .WithMany("RentTransactions")
                        .HasForeignKey("RoomId")
                        .HasConstraintName("FK_103")
                        .IsRequired();

                    b.Navigation("PaidByNavigation");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("RepayblApi.Models.Room", b =>
                {
                    b.HasOne("RepayblApi.Models.Tenant", "CurrentTenant")
                        .WithMany("Rooms")
                        .HasForeignKey("CurrentTenantId")
                        .HasConstraintName("FK_52");

                    b.HasOne("RepayblApi.Models.Property", "Property")
                        .WithMany("Rooms")
                        .HasForeignKey("PropertyId")
                        .HasConstraintName("FK_37")
                        .IsRequired();

                    b.Navigation("CurrentTenant");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("RepayblApi.Models.Tenant", b =>
                {
                    b.HasOne("RepayblApi.Models.User", "User")
                        .WithMany("Tenants")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RepayblApi.Models.TenantDocument", b =>
                {
                    b.HasOne("RepayblApi.Models.Tenant", "Tenant")
                        .WithMany("TenantDocuments")
                        .HasForeignKey("TenantId")
                        .HasConstraintName("FK_117")
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("RepayblApi.Models.TenantOutstanding", b =>
                {
                    b.HasOne("RepayblApi.Models.Tenant", "Tenant")
                        .WithMany("TenantOutstandings")
                        .HasForeignKey("TenantId")
                        .HasConstraintName("FK_144")
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("RepayblApi.Models.TenantService", b =>
                {
                    b.HasOne("RepayblApi.Models.Service", "Service")
                        .WithMany("TenantServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepayblApi.Models.Tenant", "Tenant")
                        .WithMany("TenantServices")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("RepayblApi.Models.Property", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("RepayblApi.Models.Room", b =>
                {
                    b.Navigation("RentTransactions");
                });

            modelBuilder.Entity("RepayblApi.Models.Service", b =>
                {
                    b.Navigation("TenantServices");
                });

            modelBuilder.Entity("RepayblApi.Models.Tenant", b =>
                {
                    b.Navigation("FamilyDetails");

                    b.Navigation("RentTransactions");

                    b.Navigation("Rooms");

                    b.Navigation("TenantDocuments");

                    b.Navigation("TenantOutstandings");

                    b.Navigation("TenantServices");
                });

            modelBuilder.Entity("RepayblApi.Models.User", b =>
                {
                    b.Navigation("Properties");

                    b.Navigation("Tenants");
                });
#pragma warning restore 612, 618
        }
    }
}
