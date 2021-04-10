using Microsoft.EntityFrameworkCore.Migrations;

namespace IWantMyMummy.Migrations.Mummy
{
    public partial class BurialModels5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Image",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Image");
        }
    }
}
