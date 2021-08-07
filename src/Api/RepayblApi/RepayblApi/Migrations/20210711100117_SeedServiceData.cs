using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepayblApi.Migrations
{
    public partial class SeedServiceData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Created", "CreatedBy", "IsDeleted", "Modified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("2d7c093e-09bf-418d-8edb-14d61f96c850"), new DateTimeOffset(new DateTime(2021, 7, 11, 15, 31, 16, 940, DateTimeKind.Unspecified).AddTicks(7677), new TimeSpan(0, 5, 30, 0, 0)), "Admin", false, null, null, "Rent" },
                    { new Guid("e61172c4-4c15-477e-8853-e942bac90e90"), new DateTimeOffset(new DateTime(2021, 7, 11, 15, 31, 16, 946, DateTimeKind.Unspecified).AddTicks(2765), new TimeSpan(0, 5, 30, 0, 0)), "Admin", false, null, null, "Electricity" },
                    { new Guid("922022ba-47fd-4000-ae31-8cfd9ffa1a8b"), new DateTimeOffset(new DateTime(2021, 7, 11, 15, 31, 16, 946, DateTimeKind.Unspecified).AddTicks(2818), new TimeSpan(0, 5, 30, 0, 0)), "Admin", false, null, null, "Water" },
                    { new Guid("7d9577a3-72bf-45e5-a219-a9a48c298a12"), new DateTimeOffset(new DateTime(2021, 7, 11, 15, 31, 16, 946, DateTimeKind.Unspecified).AddTicks(2823), new TimeSpan(0, 5, 30, 0, 0)), "Admin", false, null, null, "Cable" },
                    { new Guid("db24aed2-6cfa-46ea-bbdc-f6bd5b641cef"), new DateTimeOffset(new DateTime(2021, 7, 11, 15, 31, 16, 946, DateTimeKind.Unspecified).AddTicks(2826), new TimeSpan(0, 5, 30, 0, 0)), "Admin", false, null, null, "Internet" },
                    { new Guid("1917ab7d-e85d-4f58-989d-cb109531805a"), new DateTimeOffset(new DateTime(2021, 7, 11, 15, 31, 16, 946, DateTimeKind.Unspecified).AddTicks(2847), new TimeSpan(0, 5, 30, 0, 0)), "Admin", false, null, null, "Gas" },
                    { new Guid("3acd3d8b-6e18-4516-a4b8-29e26eb633a6"), new DateTimeOffset(new DateTime(2021, 7, 11, 15, 31, 16, 946, DateTimeKind.Unspecified).AddTicks(2850), new TimeSpan(0, 5, 30, 0, 0)), "Admin", false, null, null, "Trash" },
                    { new Guid("3363d1b3-e8b5-4c99-8240-7c5262720d5b"), new DateTimeOffset(new DateTime(2021, 7, 11, 15, 31, 16, 946, DateTimeKind.Unspecified).AddTicks(2853), new TimeSpan(0, 5, 30, 0, 0)), "Admin", false, null, null, "Miscellaneous" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("1917ab7d-e85d-4f58-989d-cb109531805a"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("2d7c093e-09bf-418d-8edb-14d61f96c850"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("3363d1b3-e8b5-4c99-8240-7c5262720d5b"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("3acd3d8b-6e18-4516-a4b8-29e26eb633a6"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("7d9577a3-72bf-45e5-a219-a9a48c298a12"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("922022ba-47fd-4000-ae31-8cfd9ffa1a8b"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("db24aed2-6cfa-46ea-bbdc-f6bd5b641cef"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("e61172c4-4c15-477e-8853-e942bac90e90"));
        }
    }
}
