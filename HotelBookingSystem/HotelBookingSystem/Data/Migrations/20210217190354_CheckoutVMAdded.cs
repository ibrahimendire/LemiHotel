using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelBookingSystem.Data.Migrations
{
    public partial class CheckoutVMAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Checkout",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Checkout");
        }
    }
}
