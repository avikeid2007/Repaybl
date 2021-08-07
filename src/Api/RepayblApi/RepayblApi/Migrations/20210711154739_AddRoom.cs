using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepayblApi.Migrations
{
    public partial class AddRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "TenantServices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Created", "CreatedBy", "IsDeleted", "Modified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("6aec5377-a350-4de1-8dbe-fe6ae7f9b4e6"), new DateTimeOffset(new DateTime(2021, 7, 11, 21, 17, 38, 716, DateTimeKind.Unspecified).AddTicks(4769), new TimeSpan(0, 5, 30, 0, 0)), "Admin", false, null, null, "Rent" },
                    { new Guid("558cefef-ba31-4c31-ad3b-fc8df99a586a"), new DateTimeOffset(new DateTime(2021, 7, 11, 21, 17, 38, 721, DateTimeKind.Unspecified).AddTicks(3235), new TimeSpan(0, 5, 30, 0, 0)), "Admin", false, null, null, "Electricity" },
                    { new Guid("264ba007-5717-4c66-8e9f-b1a151a52b0c"), new DateTimeOffset(new DateTime(2021, 7, 11, 21, 17, 38, 721, DateTimeKind.Unspecified).AddTicks(3285), new TimeSpan(0, 5, 30, 0, 0)), "Admin", false, null, null, "Water" },
                    { new Guid("ea728387-fbac-45d0-9cc6-27e5db6cf9ea"), new DateTimeOffset(new DateTime(2021, 7, 11, 21, 17, 38, 721, DateTimeKind.Unspecified).AddTicks(3289), new TimeSpan(0, 5, 30, 0, 0)), "Admin", false, null, null, "Cable" },
                    { new Guid("7f290c9a-71be-465b-a0c7-d7fd30b2b48f"), new DateTimeOffset(new DateTime(2021, 7, 11, 21, 17, 38, 721, DateTimeKind.Unspecified).AddTicks(3293), new TimeSpan(0, 5, 30, 0, 0)), "Admin", false, null, null, "Internet" },
                    { new Guid("82456d79-f0f0-4837-b259-1a58a910a1ba"), new DateTimeOffset(new DateTime(2021, 7, 11, 21, 17, 38, 721, DateTimeKind.Unspecified).AddTicks(3296), new TimeSpan(0, 5, 30, 0, 0)), "Admin", false, null, null, "Gas" },
                    { new Guid("069ea96b-98de-4710-a247-5f104c5434a8"), new DateTimeOffset(new DateTime(2021, 7, 11, 21, 17, 38, 721, DateTimeKind.Unspecified).AddTicks(3299), new TimeSpan(0, 5, 30, 0, 0)), "Admin", false, null, null, "Trash" },
                    { new Guid("d621f6f8-734c-4a88-8308-82e3af75ebde"), new DateTimeOffset(new DateTime(2021, 7, 11, 21, 17, 38, 721, DateTimeKind.Unspecified).AddTicks(3322), new TimeSpan(0, 5, 30, 0, 0)), "Admin", false, null, null, "Miscellaneous" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenantServices_RoomId",
                table: "TenantServices",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantServices_Rooms_RoomId",
                table: "TenantServices",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenantServices_Rooms_RoomId",
                table: "TenantServices");

            migrationBuilder.DropIndex(
                name: "IX_TenantServices_RoomId",
                table: "TenantServices");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("069ea96b-98de-4710-a247-5f104c5434a8"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("264ba007-5717-4c66-8e9f-b1a151a52b0c"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("558cefef-ba31-4c31-ad3b-fc8df99a586a"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("6aec5377-a350-4de1-8dbe-fe6ae7f9b4e6"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("7f290c9a-71be-465b-a0c7-d7fd30b2b48f"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("82456d79-f0f0-4837-b259-1a58a910a1ba"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("d621f6f8-734c-4a88-8308-82e3af75ebde"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("ea728387-fbac-45d0-9cc6-27e5db6cf9ea"));

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "TenantServices");

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
    }
}
