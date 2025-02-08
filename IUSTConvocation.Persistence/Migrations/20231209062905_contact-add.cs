using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IUSTConvocation.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class contactadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                columns: new[] { "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("41079267-fc63-488d-b849-c8475336df47"), new DateTimeOffset(new DateTime(2023, 12, 9, 11, 59, 5, 565, DateTimeKind.Unspecified).AddTicks(9505), new TimeSpan(0, 5, 30, 0, 0)), new Guid("1e44953c-80ba-426a-95e7-f5dd76f9a938"), new DateTimeOffset(new DateTime(2023, 12, 9, 11, 59, 5, 565, DateTimeKind.Unspecified).AddTicks(9516), new TimeSpan(0, 5, 30, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                columns: new[] { "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("f081b904-ecdb-4099-99ac-2060957ab741"), new DateTimeOffset(new DateTime(2023, 12, 6, 12, 14, 44, 214, DateTimeKind.Unspecified).AddTicks(5286), new TimeSpan(0, 5, 30, 0, 0)), new Guid("ff304138-8fdf-466f-9246-24559249395d"), new DateTimeOffset(new DateTime(2023, 12, 6, 12, 14, 44, 214, DateTimeKind.Unspecified).AddTicks(5297), new TimeSpan(0, 5, 30, 0, 0)) });
        }
    }
}
