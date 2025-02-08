using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IUSTConvocation.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class convocationId_In_Gownbooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ConvocationId",
                table: "GownBookings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                columns: new[] { "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("f081b904-ecdb-4099-99ac-2060957ab741"), new DateTimeOffset(new DateTime(2023, 12, 6, 12, 14, 44, 214, DateTimeKind.Unspecified).AddTicks(5286), new TimeSpan(0, 5, 30, 0, 0)), new Guid("ff304138-8fdf-466f-9246-24559249395d"), new DateTimeOffset(new DateTime(2023, 12, 6, 12, 14, 44, 214, DateTimeKind.Unspecified).AddTicks(5297), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_GownBookings_ConvocationId",
                table: "GownBookings",
                column: "ConvocationId");

            migrationBuilder.CreateIndex(
                name: "IX_GownBookings_GownId",
                table: "GownBookings",
                column: "GownId");

            migrationBuilder.AddForeignKey(
                name: "FK_GownBookings_Convocations_ConvocationId",
                table: "GownBookings",
                column: "ConvocationId",
                principalTable: "Convocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GownBookings_Gowns_GownId",
                table: "GownBookings",
                column: "GownId",
                principalTable: "Gowns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GownBookings_Convocations_ConvocationId",
                table: "GownBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_GownBookings_Gowns_GownId",
                table: "GownBookings");

            migrationBuilder.DropIndex(
                name: "IX_GownBookings_ConvocationId",
                table: "GownBookings");

            migrationBuilder.DropIndex(
                name: "IX_GownBookings_GownId",
                table: "GownBookings");

            migrationBuilder.DropColumn(
                name: "ConvocationId",
                table: "GownBookings");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                columns: new[] { "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("d18991a1-baaf-4509-877a-ab05934348bd"), new DateTimeOffset(new DateTime(2023, 12, 4, 13, 4, 4, 101, DateTimeKind.Unspecified).AddTicks(6358), new TimeSpan(0, 5, 30, 0, 0)), new Guid("5ac50b96-5d2e-462b-8732-7593f83bacc4"), new DateTimeOffset(new DateTime(2023, 12, 4, 13, 4, 4, 101, DateTimeKind.Unspecified).AddTicks(6371), new TimeSpan(0, 5, 30, 0, 0)) });
        }
    }
}
