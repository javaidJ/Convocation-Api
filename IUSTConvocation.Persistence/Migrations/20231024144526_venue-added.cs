using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IUSTConvocation.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class venueadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Convocations_IUSTConvocationId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "JobRole",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TotalSeats",
                table: "Convocations");

            migrationBuilder.RenameColumn(
                name: "IUSTConvocationId",
                table: "Seats",
                newName: "VenueId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_IUSTConvocationId",
                table: "Seats",
                newName: "IX_Seats_VenueId");

            migrationBuilder.RenameColumn(
                name: "Venue",
                table: "Convocations",
                newName: "Name");

            migrationBuilder.AddColumn<Guid>(
                name: "ConvocationId",
                table: "SeatAllocations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Convocations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VenueId",
                table: "Convocations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalSeats = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                columns: new[] { "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("70937008-d2fc-4890-9a0f-6ee3c825e1b4"), new DateTimeOffset(new DateTime(2023, 10, 24, 20, 15, 26, 574, DateTimeKind.Unspecified).AddTicks(493), new TimeSpan(0, 5, 30, 0, 0)), new Guid("08cf6918-1553-4f88-8505-40bb1a1c0c6f"), new DateTimeOffset(new DateTime(2023, 10, 24, 20, 15, 26, 574, DateTimeKind.Unspecified).AddTicks(504), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_SeatAllocations_ConvocationId",
                table: "SeatAllocations",
                column: "ConvocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Convocations_VenueId",
                table: "Convocations",
                column: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Convocations_Venue_VenueId",
                table: "Convocations",
                column: "VenueId",
                principalTable: "Venue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SeatAllocations_Convocations_ConvocationId",
                table: "SeatAllocations",
                column: "ConvocationId",
                principalTable: "Convocations",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convocations_Venue_VenueId",
                table: "Convocations");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatAllocations_Convocations_ConvocationId",
                table: "SeatAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Venue_VenueId",
                table: "Seats");

            migrationBuilder.DropTable(
                name: "Venue");

            migrationBuilder.DropIndex(
                name: "IX_SeatAllocations_ConvocationId",
                table: "SeatAllocations");

            migrationBuilder.DropIndex(
                name: "IX_Convocations_VenueId",
                table: "Convocations");

            migrationBuilder.DropColumn(
                name: "ConvocationId",
                table: "SeatAllocations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Convocations");

            migrationBuilder.DropColumn(
                name: "VenueId",
                table: "Convocations");

            migrationBuilder.RenameColumn(
                name: "VenueId",
                table: "Seats",
                newName: "IUSTConvocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_VenueId",
                table: "Seats",
                newName: "IX_Seats_IUSTConvocationId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Convocations",
                newName: "Venue");

            migrationBuilder.AddColumn<byte>(
                name: "JobRole",
                table: "Employees",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalSeats",
                table: "Convocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                columns: new[] { "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("adbd5590-7d07-44a9-a3fa-62fc0660fb42"), new DateTimeOffset(new DateTime(2023, 10, 24, 12, 10, 30, 629, DateTimeKind.Unspecified).AddTicks(7714), new TimeSpan(0, 5, 30, 0, 0)), new Guid("d0559874-beb7-4cab-a763-38b46ffc852f"), new DateTimeOffset(new DateTime(2023, 10, 24, 12, 10, 30, 629, DateTimeKind.Unspecified).AddTicks(7725), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Convocations_IUSTConvocationId",
                table: "Seats",
                column: "IUSTConvocationId",
                principalTable: "Convocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
