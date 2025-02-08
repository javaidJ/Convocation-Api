using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IUSTConvocation.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class appOrderModfied : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountDue",
                table: "AppOrders");

            migrationBuilder.DropColumn(
                name: "AmountPaid",
                table: "AppOrders");

            migrationBuilder.DropColumn(
                name: "IsPartial",
                table: "AppOrders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                columns: new[] { "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("d18991a1-baaf-4509-877a-ab05934348bd"), new DateTimeOffset(new DateTime(2023, 12, 4, 13, 4, 4, 101, DateTimeKind.Unspecified).AddTicks(6358), new TimeSpan(0, 5, 30, 0, 0)), new Guid("5ac50b96-5d2e-462b-8732-7593f83bacc4"), new DateTimeOffset(new DateTime(2023, 12, 4, 13, 4, 4, 101, DateTimeKind.Unspecified).AddTicks(6371), new TimeSpan(0, 5, 30, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AmountDue",
                table: "AppOrders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountPaid",
                table: "AppOrders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsPartial",
                table: "AppOrders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                columns: new[] { "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("3d992083-03c9-43b1-b25d-54fd1e862254"), new DateTimeOffset(new DateTime(2023, 10, 25, 12, 47, 3, 627, DateTimeKind.Unspecified).AddTicks(8306), new TimeSpan(0, 5, 30, 0, 0)), new Guid("a379e688-68e8-4271-92aa-a80b65d45efa"), new DateTimeOffset(new DateTime(2023, 10, 25, 12, 47, 3, 627, DateTimeKind.Unspecified).AddTicks(8317), new TimeSpan(0, 5, 30, 0, 0)) });
        }
    }
}
