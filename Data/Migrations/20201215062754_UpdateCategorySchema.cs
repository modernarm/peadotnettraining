using Microsoft.EntityFrameworkCore.Migrations;

namespace PEADotNetTraining.Data.Migrations
{
    public partial class UpdateCategorySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase(
                collation: "THAI_CI_AS");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "category",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "category");

            migrationBuilder.AlterDatabase(
                oldCollation: "THAI_CI_AS");
        }
    }
}
