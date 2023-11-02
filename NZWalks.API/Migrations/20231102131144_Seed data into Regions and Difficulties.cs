using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeeddataintoRegionsandDifficulties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("40fc60ab-745b-41ca-911e-f448d26aed2b"), "Hard" },
                    { new Guid("59b2d3a9-58c5-4097-8cd4-6ba2d3ec854a"), "Medium" },
                    { new Guid("c98811c2-8a75-4f21-9456-6631c26586c2"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("2cccdcad-19a4-4195-a2d6-3defdf1aad5e"), "A/R", "Ashanti Region", "https://...anyyyy" },
                    { new Guid("30ff8627-7e90-49c5-bd46-428164fee121"), "W/R", "Western Region", "https://...anyyyy" },
                    { new Guid("403ad540-e02a-4f58-b9ad-e0da81aa47cb"), "C/R", "Central Region", "https://...anyyyy" },
                    { new Guid("8a1cf8a6-eb83-4405-92f6-79308ba91497"), "C/R", "Central Region", "https://...anyyyy" },
                    { new Guid("ac9b24ef-2612-4f74-a543-2acd3720a04c"), "A/R", "Ashanti Region", "https://...anyyyy" },
                    { new Guid("c4da9f85-b783-41bc-995f-2f365c57fa13"), "W/R", "Western Region", "https://...anyyyy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("40fc60ab-745b-41ca-911e-f448d26aed2b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("59b2d3a9-58c5-4097-8cd4-6ba2d3ec854a"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c98811c2-8a75-4f21-9456-6631c26586c2"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2cccdcad-19a4-4195-a2d6-3defdf1aad5e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("30ff8627-7e90-49c5-bd46-428164fee121"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("403ad540-e02a-4f58-b9ad-e0da81aa47cb"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8a1cf8a6-eb83-4405-92f6-79308ba91497"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ac9b24ef-2612-4f74-a543-2acd3720a04c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c4da9f85-b783-41bc-995f-2f365c57fa13"));
        }
    }
}
