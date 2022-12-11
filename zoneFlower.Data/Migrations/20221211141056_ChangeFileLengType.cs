using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zoneFlower.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFileLengType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "551332d5-72b6-4117-80b5-a95933e4c790");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ef2419f2-47ee-4591-b36a-29d5db67d694", "AQAAAAEAACcQAAAAEMDdJOR7hiY2+/bPYBE168Sml95BrskjdfcKaXYNBmCwwGRTflcuWDw3H+W9e97iQA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 12, 11, 21, 10, 56, 167, DateTimeKind.Local).AddTicks(2465));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "755b2595-1944-4ef7-868e-7e6ea2b0b06d");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dcd908ef-f5d0-4869-97f5-41943967768e", "AQAAAAEAACcQAAAAELto0Xn3NjevGmk8WNJ24Nc3uP5EhtvNh8f7tMdF6tnuanxQ6ox5HVK0R8QoFQ+ZeQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 12, 9, 18, 37, 32, 755, DateTimeKind.Local).AddTicks(8821));
        }
    }
}
