using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACar.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_usercreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("822e044b-5656-4b44-ad0f-01d7761e2cbe"),
                column: "CreateDate",
                value: new DateTime(2024, 3, 27, 3, 22, 20, 519, DateTimeKind.Local).AddTicks(190));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "CreatedUser", "Decription", "EMailAddress", "FirstName", "IsActive", "LastName", "Password", "UpdatedDate", "UpdatedUser" },
                values: new object[] { new Guid("c326ee05-4878-4219-958d-ad3caefa4e11"), new DateTime(2024, 3, 27, 3, 22, 20, 519, DateTimeKind.Local).AddTicks(303), "Admin", null, "eagledenizcilik@outlook.com.tr", "Alican", true, "Kartal", "Eagle0204.", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c326ee05-4878-4219-958d-ad3caefa4e11"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("822e044b-5656-4b44-ad0f-01d7761e2cbe"),
                column: "CreateDate",
                value: new DateTime(2024, 3, 27, 3, 18, 49, 780, DateTimeKind.Local).AddTicks(6591));
        }
    }
}
