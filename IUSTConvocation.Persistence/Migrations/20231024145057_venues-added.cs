using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IUSTConvocation.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class venuesadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convocations_Venue_VenueId",
                table: "Convocations");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Venue_VenueId",
                table: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venue",
                table: "Venue");

            migrationBuilder.RenameTable(
                name: "Venue",
                newName: "Venues");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Venues",
                table: "Venues",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                columns: new[] { "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("d6790fa8-3f81-4e8e-aca8-47c6857748cd"), new DateTimeOffset(new DateTime(2023, 10, 24, 20, 20, 56, 977, DateTimeKind.Unspecified).AddTicks(8858), new TimeSpan(0, 5, 30, 0, 0)), new Guid("82c9d0ff-c22c-4209-9e8d-fe24e27049ea"), new DateTimeOffset(new DateTime(2023, 10, 24, 20, 20, 56, 977, DateTimeKind.Unspecified).AddTicks(8869), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_Convocations_Venues_VenueId",
                table: "Convocations",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Venues_VenueId",
                table: "Seats",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convocations_Venues_VenueId",
                table: "Convocations");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Venues_VenueId",
                table: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venues",
                table: "Venues");

            migrationBuilder.RenameTable(
                name: "Venues",
                newName: "Venue");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Venue",
                table: "Venue",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                columns: new[] { "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("70937008-d2fc-4890-9a0f-6ee3c825e1b4"), new DateTimeOffset(new DateTime(2023, 10, 24, 20, 15, 26, 574, DateTimeKind.Unspecified).AddTicks(493), new TimeSpan(0, 5, 30, 0, 0)), new Guid("08cf6918-1553-4f88-8505-40bb1a1c0c6f"), new DateTimeOffset(new DateTime(2023, 10, 24, 20, 15, 26, 574, DateTimeKind.Unspecified).AddTicks(504), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_Convocations_Venue_VenueId",
                table: "Convocations",
                column: "VenueId",
                principalTable: "Venue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Venue_VenueId",
                table: "Seats",
                column: "VenueId",
                principalTable: "Venue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
