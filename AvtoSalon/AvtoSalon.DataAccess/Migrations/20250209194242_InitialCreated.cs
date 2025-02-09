using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvtoSalon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvtoSalon",
                columns: table => new
                {
                    SalonId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalonName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RelasedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvtoSalon", x => x.SalonId);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SalonId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Car_AvtoSalon_SalonId",
                        column: x => x.SalonId,
                        principalTable: "AvtoSalon",
                        principalColumn: "SalonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvtoSalon_SalonName",
                table: "AvtoSalon",
                column: "SalonName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarName",
                table: "Car",
                column: "CarName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_SalonId",
                table: "Car",
                column: "SalonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "AvtoSalon");
        }
    }
}
