using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACar.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_usercreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "CreatedUser", "Decription", "EMailAddress", "FirstName", "IsActive", "LastName", "Password", "UpdatedDate", "UpdatedUser" },
                values: new object[] { new Guid("822e044b-5656-4b44-ad0f-01d7761e2cbe"), new DateTime(2024, 3, 27, 3, 18, 49, 780, DateTimeKind.Local).AddTicks(6591), "Admin", null, "icb1742@gmail.com", "Süper", true, "Admin", "17421742", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("822e044b-5656-4b44-ad0f-01d7761e2cbe"));
        }
    }
}
