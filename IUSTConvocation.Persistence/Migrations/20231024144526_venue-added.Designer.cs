﻿// <auto-generated />
using System;
using IUSTConvocation.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IUSTConvocation.Persistence.Migrations
{
    [DbContext(typeof(ConvocationDbContext))]
    [Migration("20231024144526_venue-added")]
    partial class venueadded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressLine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Module")
                        .HasColumnType("tinyint");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.AppFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Module")
                        .HasColumnType("tinyint");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("AppFiles");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.AppOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AmountDue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("AppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CreatedAt")
                        .HasColumnType("int");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPartial")
                        .HasColumnType("bit");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<string>("Receipt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppOrders");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.AppPayment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("AppPaymentStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<string>("RpOrderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("AppPayments");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.Convocation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("ConvocationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("End")
                        .HasColumnType("time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("VenueId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("Convocations");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("DepartemntId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte?>("Designation")
                        .HasColumnType("tinyint");

                    b.Property<string>("EmpCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("DepartemntId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.Gown", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Charges")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<byte>("Size")
                        .HasColumnType("tinyint");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Gowns");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.GownAllocation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GownId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("GownStatus")
                        .HasColumnType("tinyint");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("TrailDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("GownAllocations");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.Guest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<string>("GuestArrivedFrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOutSider")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ConvocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("JobRole")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Module")
                        .HasColumnType("tinyint");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("ConvocationId");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.Pass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IUSTConvocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PassNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("VehicleNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IUSTConvocationId");

                    b.ToTable("Passes");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.Registration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConvocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Module")
                        .HasColumnType("tinyint");

                    b.Property<byte>("ParticipantRole")
                        .HasColumnType("tinyint");

                    b.Property<byte>("RegistrationStatus")
                        .HasColumnType("tinyint");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("ConvocationId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.Seat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.Property<string>("SeatNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("SeatSection")
                        .HasColumnType("tinyint");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("VenueId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.SeatAllocation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConvocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SeatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("ConvocationId");

                    b.HasIndex("SeatId");

                    b.ToTable("SeatAllocations");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Batch")
                        .HasColumnType("int");

                    b.Property<byte>("Course")
                        .HasColumnType("tinyint");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("DepartemntId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parentage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Percentage")
                        .HasColumnType("float");

                    b.Property<byte>("Position")
                        .HasColumnType("tinyint");

                    b.Property<string>("RegNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("DepartemntId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConfirmationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResetCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<byte>("UserRole")
                        .HasColumnType("tinyint");

                    b.Property<byte>("UserStatus")
                        .HasColumnType("tinyint");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                            ConfirmationCode = "",
                            ContactNo = "8828084050",
                            CreatedBy = new Guid("70937008-d2fc-4890-9a0f-6ee3c825e1b4"),
                            CreatedOn = new DateTimeOffset(new DateTime(2023, 10, 24, 20, 15, 26, 574, DateTimeKind.Unspecified).AddTicks(493), new TimeSpan(0, 5, 30, 0, 0)),
                            Email = "samiaullah1@gmail.com",
                            Gender = (byte)1,
                            IsEmailVerified = true,
                            Password = "$2a$11$TYYBxfFaSET3Oizd0CXEleNVtkdE7FEE.p60NpoAT13WT38X2OP5q",
                            ResetCode = "",
                            Salt = "$2a$11$TYYBxfFaSET3Oizd0CXEle",
                            UpdatedBy = new Guid("08cf6918-1553-4f88-8505-40bb1a1c0c6f"),
                            UpdatedOn = new DateTimeOffset(new DateTime(2023, 10, 24, 20, 15, 26, 574, DateTimeKind.Unspecified).AddTicks(504), new TimeSpan(0, 5, 30, 0, 0)),
                            UserRole = (byte)1,
                            UserStatus = (byte)1,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.Venue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Venue");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.AppPayment", b =>
                {
                    b.HasOne("IUSTConvocation.Domain.Entities.AppOrder", "Order")
                        .WithMany("Payments")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.Convocation", b =>
                {
                    b.HasOne("IUSTConvocation.Domain.Entities.Venue", "Venue")
                        .WithMany("Convocations")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.Employee", b =>
                {
                    b.HasOne("IUSTConvocation.Domain.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartemntId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IUSTConvocation.Domain.Entities.User", "User")
                        .WithOne("Employee")
                        .HasForeignKey("IUSTConvocation.Domain.Entities.Employee", "Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.Member", b =>
                {
                    b.HasOne("IUSTConvocation.Domain.Entities.Convocation", "Convocation")
                        .WithMany("Members")
                        .HasForeignKey("ConvocationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Convocation");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.Pass", b =>
                {
                    b.HasOne("IUSTConvocation.Domain.Entities.Convocation", "IUSTConvocation")
                        .WithMany()
                        .HasForeignKey("IUSTConvocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("IUSTConvocation");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.Registration", b =>
                {
                    b.HasOne("IUSTConvocation.Domain.Entities.Convocation", "Convocation")
                        .WithMany("Registrations")
                        .HasForeignKey("ConvocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Convocation");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.Seat", b =>
                {
                    b.HasOne("IUSTConvocation.Domain.Entities.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.SeatAllocation", b =>
                {
                    b.HasOne("IUSTConvocation.Domain.Entities.Convocation", "Convocation")
                        .WithMany()
                        .HasForeignKey("ConvocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IUSTConvocation.Domain.Entities.Seat", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Convocation");

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.Student", b =>
                {
                    b.HasOne("IUSTConvocation.Domain.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartemntId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IUSTConvocation.Domain.Entities.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("IUSTConvocation.Domain.Entities.Student", "Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.AppOrder", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.Convocation", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Registrations");
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.User", b =>
                {
                    b.Navigation("Employee")
                        .IsRequired();

                    b.Navigation("Student")
                        .IsRequired();
                });

            modelBuilder.Entity("IUSTConvocation.Domain.Entities.Venue", b =>
                {
                    b.Navigation("Convocations");
                });
#pragma warning restore 612, 618
        }
    }
}
