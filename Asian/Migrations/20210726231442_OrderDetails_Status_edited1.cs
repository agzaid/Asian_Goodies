using Microsoft.EntityFrameworkCore.Migrations;

namespace Asian.Migrations
{
    public partial class OrderDetails_Status_edited1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "OrderDetails");
        }
    }
}
