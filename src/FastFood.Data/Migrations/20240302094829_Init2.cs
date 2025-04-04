using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FastFood.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "Companies",
              columns: table => new
              {
                  Id = table.Column<long>(type: "bigint", nullable: false)
                      .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                  Name = table.Column<string>(type: "text", nullable: true),
                  UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                  DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                  IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                  CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                  UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                  DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                  CreatedBy = table.Column<long>(type: "bigint", nullable: true)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Companies", x => x.Id);
              });
            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6665));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6671));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6673));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6674));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6675));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6676));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6677));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6679));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6680));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6682));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6889));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6891));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6893));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6894));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6896));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6898));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6900));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6901));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6903));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6913));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6916));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 28, 703, DateTimeKind.Utc).AddTicks(6917));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 27, 401, DateTimeKind.Utc).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 27, 401, DateTimeKind.Utc).AddTicks(2511));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 27, 401, DateTimeKind.Utc).AddTicks(2513));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 27, 401, DateTimeKind.Utc).AddTicks(2514));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 48, 27, 401, DateTimeKind.Utc).AddTicks(2516));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 48, 27, 517, DateTimeKind.Utc).AddTicks(1890), "$2a$11$u1oLKdIo.h5c.q/2CfTBr.puK.HVqetEuVCfHpuE4lMzKT97wdwLe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 48, 27, 637, DateTimeKind.Utc).AddTicks(7858), "$2a$11$I7bGAmb1cqOPwik9nB/NJeu/lPhzj1dHQz6jzCtxXcbkpvgPfUBVe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 48, 27, 759, DateTimeKind.Utc).AddTicks(2249), "$2a$11$3r0NuN6UC84iKxfsk6L4QuwO2qNweWTtgX6H4WsimZgY6jD5376ka" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 48, 27, 878, DateTimeKind.Utc).AddTicks(2125), "$2a$11$prtV54bPFU/zLiSPPlnhUeRwEi8yaiwYXXyxxM6qZ4xpaQw0zO8Gi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 48, 27, 996, DateTimeKind.Utc).AddTicks(9368), "$2a$11$y8fYcn45OHNqXr/Q1DzgZu6XPxrWMez6JRnAUM6g45wYwEFOgnOgS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 48, 28, 114, DateTimeKind.Utc).AddTicks(5354), "$2a$11$Xstj8E6NpQHwqwGousHcC.WbzrCQkjew5iLKmfLj5Rn46TKfGykKa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 48, 28, 231, DateTimeKind.Utc).AddTicks(36), "$2a$11$NmeDPgy69s7YMhUqeYfnxeg1.K1bQo8oA0cs4sAaSUHjDkiXIv5ma" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 48, 28, 348, DateTimeKind.Utc).AddTicks(7431), "$2a$11$zXtbBubTtSOCyIwwJyt7n.yv77sw8MFfj8bZcifspu1anyvCGzASe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 48, 28, 466, DateTimeKind.Utc).AddTicks(4569), "$2a$11$Rs29ThqjeotjPCDpmkyPMuE9fgMoBmnjxw3GLEk5P7p69S4KGOzo." });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 48, 28, 584, DateTimeKind.Utc).AddTicks(2633), "$2a$11$5LNo8Tfn2ACKI2RWA6zDJ.eKI0BnyCKZCLrcqw6SV.f29fKK9cGOG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 48, 28, 584, DateTimeKind.Utc).AddTicks(2652), "$2a$11$6MKVgyS.aaG6lVbPWs8RTuZcB/DOFo3bm8gW5UxTIZOpIdg7AJ9sC" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(146));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(150));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(151));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(155));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(156));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(157));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(158));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(159));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(160));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(161));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(2537));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(2540));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(2541));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(2543));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(2544));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(2546));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(2548));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(2549));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(2551));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(2558));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(2560));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(2561));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 23, 926, DateTimeKind.Utc).AddTicks(2563));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 22, 569, DateTimeKind.Utc).AddTicks(881));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 22, 569, DateTimeKind.Utc).AddTicks(885));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 22, 569, DateTimeKind.Utc).AddTicks(887));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 22, 569, DateTimeKind.Utc).AddTicks(889));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 9, 45, 22, 569, DateTimeKind.Utc).AddTicks(890));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 45, 22, 686, DateTimeKind.Utc).AddTicks(8487), "$2a$11$E/TqPZRJTtMrIQluxmlZSezbEnZEdbWwHuSIBq3eNkeGJXvE/ZNZS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 45, 22, 807, DateTimeKind.Utc).AddTicks(1912), "$2a$11$en4g9WwrGQriLCWqqrc46ufexO288ev9UXy/JkICGY/UzDHSlDwyK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 45, 22, 966, DateTimeKind.Utc).AddTicks(5098), "$2a$11$UtmkSo43Id1wqqtggALMCeRIdHVc97OPIhed/fdbQxYW/2SORPYQa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 45, 23, 85, DateTimeKind.Utc).AddTicks(3612), "$2a$11$ZKdWnFVpuUymBs1f5IbtfeCgGwazCmDDiYhzKtfXKfM1jlEMhQb5q" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 45, 23, 206, DateTimeKind.Utc).AddTicks(1443), "$2a$11$GcD/FgmBTnaICY82/srkSOC.FsXRt5CGNCSgmrXfetp7PScfoyz4C" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 45, 23, 325, DateTimeKind.Utc).AddTicks(3184), "$2a$11$5vmng0oHV90Im.LLe7afz.YjqtS44kd5wGpkYHYJdR7fEzXNGXfRG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 45, 23, 446, DateTimeKind.Utc).AddTicks(6576), "$2a$11$5Ngjkm91qADmlkJFWp/h5Og6iUsHLQotXRN7huYTaGaM9Rlyp8BVS" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 45, 23, 569, DateTimeKind.Utc).AddTicks(286), "$2a$11$4Y5IJ5Bu9P1eBa4lETmBi.7ggyx3iC5rdC/y.oYUsWayG6mM11hva" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 45, 23, 689, DateTimeKind.Utc).AddTicks(1234), "$2a$11$vCrAfHsFutYu/gqbQzxZSu2jzjSRiws9S0q41dO0h5PDmnNG7fLyG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 45, 23, 805, DateTimeKind.Utc).AddTicks(1928), "$2a$11$guDFpJ1DeifPOFq3tD..r.bc2yDrmUP/4uO6ANa5mdOSrWyPHZhye" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "Password" },
                values: new object[] { new DateTime(2024, 3, 2, 9, 45, 23, 805, DateTimeKind.Utc).AddTicks(1947), "$2a$11$NnVNS1R9l957yONRKzOQNecFnZBGnEVd2fl7AhCyOqHj8oPF9c5WS" });
        }
    }
}
