using Microsoft.EntityFrameworkCore.Migrations;

namespace IWantMyMummy.Migrations.Mummy
{
    public partial class changingsomefloatthings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "west_to_head",
                table: "Burial",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "west_to_feet",
                table: "Burial",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "south_to_head",
                table: "Burial",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "south_to_feet",
                table: "Burial",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "length_of_remains",
                table: "Burial",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "burial_depth",
                table: "Burial",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "west_to_head",
                table: "Burial",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "west_to_feet",
                table: "Burial",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "south_to_head",
                table: "Burial",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "south_to_feet",
                table: "Burial",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "length_of_remains",
                table: "Burial",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "burial_depth",
                table: "Burial",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
