using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IUSTConvocation.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class payment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GownAllocations");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "AppOrders",
                newName: "GownBookingId");

            migrationBuilder.CreateTable(
                name: "GownBookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GownId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GownStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GownBookings", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                columns: new[] { "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("3d992083-03c9-43b1-b25d-54fd1e862254"), new DateTimeOffset(new DateTime(2023, 10, 25, 12, 47, 3, 627, DateTimeKind.Unspecified).AddTicks(8306), new TimeSpan(0, 5, 30, 0, 0)), new Guid("a379e688-68e8-4271-92aa-a80b65d45efa"), new DateTimeOffset(new DateTime(2023, 10, 25, 12, 47, 3, 627, DateTimeKind.Unspecified).AddTicks(8317), new TimeSpan(0, 5, 30, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GownBookings");

            migrationBuilder.RenameColumn(
                name: "GownBookingId",
                table: "AppOrders",
                newName: "AppointmentId");

            migrationBuilder.CreateTable(
                name: "GownAllocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GownId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GownStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    TrailDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GownAllocations", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                columns: new[] { "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("d6790fa8-3f81-4e8e-aca8-47c6857748cd"), new DateTimeOffset(new DateTime(2023, 10, 24, 20, 20, 56, 977, DateTimeKind.Unspecified).AddTicks(8858), new TimeSpan(0, 5, 30, 0, 0)), new Guid("82c9d0ff-c22c-4209-9e8d-fe24e27049ea"), new DateTimeOffset(new DateTime(2023, 10, 24, 20, 20, 56, 977, DateTimeKind.Unspecified).AddTicks(8869), new TimeSpan(0, 5, 30, 0, 0)) });
        }
    }
}
