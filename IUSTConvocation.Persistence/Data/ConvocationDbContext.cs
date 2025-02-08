using IUSTConvocation.Domain.Entities;
using IUSTConvocation.Persistence.Data;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace IUSTConvocation.Persistence;

public class ConvocationDbContext : DbContext
{
    public ConvocationDbContext(DbContextOptions<ConvocationDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationShip in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
        {
            relationShip.DeleteBehavior = DeleteBehavior.Restrict;
        }

        modelBuilder.SeedUsers();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<TimeOnly>()
            .HaveConversion<CustTimeOnlyConverter>()
            .HaveColumnType("time");
        SqlMapper.AddTypeHandler(new SqlTimeOnlyTypeHandler());

        builder.Properties<DateOnly>()
           .HaveConversion<CustDateOnlyConverter>()
           .HaveColumnType("date");
        SqlMapper.AddTypeHandler(new SqlTimeOnlyTypeHandler());

        base.ConfigureConventions(builder);
    }
    public DbSet<User> Users { get; set; }

    public DbSet<Student> Students { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Guest> Guests { get; set; }

    public DbSet<Address> Addresses { get; set; }

    public DbSet<AppFile> AppFiles { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<Convocation> Convocations { get; set; }

    public DbSet<Registration> Registrations { get; set; }

    public DbSet<Gown> Gowns { get; set; }

    public DbSet<GownBooking> GownBookings { get; set; }

    public DbSet<Seat> Seats { get; set; }

    public DbSet<SeatAllocation> SeatAllocations { get; set; }

    public DbSet<Pass> Passes { get; set; }

    public DbSet<AppOrder> AppOrders  { get; set; }

    public DbSet<AppPayment> AppPayments  { get; set; }
    public DbSet<Venue> Venues  { get; set; }
    public DbSet<Contact> Contacts  { get; set; }
}

#region seed data
public static class ModelBuilderExtentions
{
    public static void SeedUsers(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = Guid.Parse("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
            Username = "admin",
            Password = "$2a$11$TYYBxfFaSET3Oizd0CXEleNVtkdE7FEE.p60NpoAT13WT38X2OP5q",
            Salt = "$2a$11$TYYBxfFaSET3Oizd0CXEle",
            Email = "samiaullah1@gmail.com",
            ContactNo = "8828084050",
            Gender = Domain.Enums.Gender.Male,
            UserRole = Domain.Enums.UserRole.Admin,
            UserStatus = Domain.Enums.UserStatus.Active,
            IsEmailVerified=true,
            ResetCode = "",
            CreatedBy = Guid.NewGuid(),
            UpdatedBy = Guid.NewGuid(),
            CreatedOn = DateTime.Now,
            UpdatedOn = DateTime.Now,
        });
    }
}

#endregion