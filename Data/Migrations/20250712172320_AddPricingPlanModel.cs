using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingSlot.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPricingPlanModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PricingPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HourlyPricing = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyPricing = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinimumHours = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricingPlans", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PricingPlans");
        }
    }
}
