using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zoneFlower.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFileLengType2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "09e09667-2c2e-49a4-ba65-02c5fbd6d69a");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fb870c49-abef-419a-a93e-70debf2172d9", "AQAAAAEAACcQAAAAENSE9cxlpx1qDvSbG0rk9vvSS+lrIv6mUdieWiOHdc3ZQDRO4pFh+XYg8t54kcYAMw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 12, 11, 21, 16, 46, 563, DateTimeKind.Local).AddTicks(688));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
