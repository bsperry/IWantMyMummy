using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IWantMyMummy.Migrations.Mummy
{
    public partial class BurialModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Burial_Quadrant",
                columns: table => new
                {
                    burial_square_id = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    burial_subplot = table.Column<string>(unicode: false, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUADRANT", x => new { x.burial_subplot, x.burial_square_id });
                });

            migrationBuilder.CreateTable(
                name: "Burial_Square",
                columns: table => new
                {
                    burial_square_id = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    burial_location_NS = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    burial_location_EW = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    low_pair_NS = table.Column<int>(nullable: false),
                    high_pair_NS = table.Column<int>(nullable: false),
                    low_pair_EW = table.Column<int>(nullable: false),
                    high_pair_EW = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burial_Square", x => x.burial_square_id);
                });

            migrationBuilder.CreateTable(
                name: "Burial",
                columns: table => new
                {
                    burial_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    burial_number = table.Column<int>(nullable: false),
                    burial_subplot = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    burial_square_id = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    burial_depth = table.Column<int>(nullable: false),
                    south_to_head = table.Column<int>(nullable: false),
                    south_to_feet = table.Column<int>(nullable: false),
                    west_to_head = table.Column<int>(nullable: false),
                    west_to_feet = table.Column<int>(nullable: false),
                    burial_situation = table.Column<string>(unicode: false, maxLength: 5000, nullable: true),
                    burial_wrapping = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    burial_wrapping_material = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    burial_adult = table.Column<bool>(nullable: true),
                    length_of_remains = table.Column<int>(nullable: false),
                    sample_number = table.Column<int>(nullable: true),
                    gender_GE = table.Column<string>(unicode: false, maxLength: 1, nullable: false),
                    sex_method_skull = table.Column<bool>(nullable: false),
                    GE_function_total = table.Column<double>(nullable: true),
                    gender_body_col = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    head_direction = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    basilar_suture = table.Column<bool>(nullable: true),
                    ventral_arc = table.Column<int>(nullable: true),
                    subpubic_angle = table.Column<int>(nullable: true),
                    sciatic_notch = table.Column<int>(nullable: true),
                    pubic_bone = table.Column<int>(nullable: true),
                    preaur_sulcus = table.Column<int>(nullable: true),
                    medial_IP_ramus = table.Column<int>(nullable: true),
                    dorsal_pitting = table.Column<int>(nullable: true),
                    foreman_magnum = table.Column<double>(nullable: true),
                    femur_head = table.Column<double>(nullable: true),
                    humerus_head = table.Column<double>(nullable: true),
                    osteophytosis = table.Column<int>(nullable: true),
                    pubic_symphysis = table.Column<int>(nullable: true),
                    femur_length = table.Column<double>(nullable: true),
                    humerus_length = table.Column<double>(nullable: true),
                    tibia_length = table.Column<double>(nullable: true),
                    robust = table.Column<int>(nullable: true),
                    supraorbital_ridges = table.Column<int>(nullable: true),
                    orbit_edge = table.Column<int>(nullable: true),
                    parietal_bossing = table.Column<int>(nullable: true),
                    gonian = table.Column<int>(nullable: true),
                    nuchal_crest = table.Column<int>(nullable: true),
                    zygomatic_crest = table.Column<int>(nullable: true),
                    cranial_suture = table.Column<string>(unicode: false, maxLength: 13, nullable: true),
                    maximum_cranial_length = table.Column<double>(nullable: true),
                    maximum_cranial_breadth = table.Column<double>(nullable: true),
                    basion_bregma_height = table.Column<double>(nullable: true),
                    basion_nasion = table.Column<double>(nullable: true),
                    basion_prosthion_length = table.Column<double>(nullable: true),
                    bizygomatic_diameter = table.Column<double>(nullable: true),
                    nasion_prosthion = table.Column<double>(nullable: true),
                    maximum_nasal_breadth = table.Column<double>(nullable: true),
                    interorbital_breadth = table.Column<double>(nullable: true),
                    artifacts_description = table.Column<string>(unicode: false, maxLength: 5000, nullable: true),
                    hair_color = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    preservation_index = table.Column<int>(nullable: true),
                    hair_taken = table.Column<bool>(nullable: true),
                    soft_tissue_taken = table.Column<bool>(nullable: true),
                    bone_taken = table.Column<bool>(nullable: true),
                    tooth_taken = table.Column<bool>(nullable: true),
                    textile_taken = table.Column<bool>(nullable: true),
                    description_of_taken = table.Column<string>(unicode: false, maxLength: 5000, nullable: true),
                    artifact_found = table.Column<bool>(nullable: true),
                    estimate_age = table.Column<double>(nullable: true),
                    estimate_living_stature = table.Column<double>(nullable: true),
                    tooth_attrition = table.Column<int>(nullable: true),
                    tooth_eruption = table.Column<string>(unicode: false, maxLength: 5000, nullable: true),
                    pathology_anomalies = table.Column<string>(unicode: false, maxLength: 5000, nullable: true),
                    epiphyseal_union = table.Column<bool>(nullable: true),
                    date_found = table.Column<DateTime>(type: "datetime", nullable: true),
                    age_at_death = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    age_method_skull = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burial", x => x.burial_id);
                    table.ForeignKey(
                        name: "FK__Burial__burial_s__5070F446",
                        column: x => x.burial_square_id,
                        principalTable: "Burial_Square",
                        principalColumn: "burial_square_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QUADRANT",
                        columns: x => new { x.burial_subplot, x.burial_square_id },
                        principalTable: "Burial_Quadrant",
                        principalColumns: new[] { "burial_subplot", "burial_square_id" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rack_Sample",
                columns: table => new
                {
                    rack_shelf = table.Column<string>(unicode: false, maxLength: 2, nullable: false),
                    rack_number = table.Column<string>(unicode: false, maxLength: 3, nullable: false),
                    is_bag = table.Column<bool>(nullable: false),
                    burial_id = table.Column<int>(nullable: false),
                    tube_number = table.Column<int>(nullable: true),
                    rank_description = table.Column<string>(unicode: false, maxLength: 5000, nullable: true),
                    ml_size = table.Column<int>(nullable: false),
                    foci = table.Column<int>(nullable: false),
                    location_notes = table.Column<string>(unicode: false, maxLength: 2000, nullable: true),
                    questions = table.Column<string>(unicode: false, maxLength: 2000, nullable: true),
                    conventional_14c_age_BP = table.Column<int>(nullable: false),
                    _14c_calendar_day = table.Column<int>(name: "14c_calendar_day", nullable: false),
                    calibrated_95_calendar_date_MAX = table.Column<int>(nullable: false),
                    calibrated_95_calendar_date_MIN = table.Column<int>(nullable: false),
                    calibrated_95_calendar_date_SPAN = table.Column<int>(nullable: true, computedColumnSql: "(abs([calibrated_95_calendar_date_MAX]-[calibrated_95_calendar_date_MIN]))"),
                    calibrated_95_calendar_date_AVG = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    category = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    notes = table.Column<string>(unicode: false, maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RACK", x => new { x.rack_shelf, x.rack_number });
                    table.ForeignKey(
                        name: "FK_BURIAL",
                        column: x => x.burial_id,
                        principalTable: "Burial",
                        principalColumn: "burial_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cranial_Sample",
                columns: table => new
                {
                    cranial_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    burial_id = table.Column<int>(nullable: false),
                    sample_number = table.Column<int>(nullable: true),
                    rack_shelf = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    rack_number = table.Column<string>(unicode: false, maxLength: 3, nullable: true),
                    max_cranial_length = table.Column<double>(nullable: true),
                    max_cranial_breadth = table.Column<double>(nullable: true),
                    basion_bregma_height = table.Column<double>(nullable: true),
                    basion_nasion = table.Column<double>(nullable: true),
                    basion_prosthion_length = table.Column<double>(nullable: true),
                    bizgomatic_diameter = table.Column<double>(nullable: true),
                    nasion_prosthion = table.Column<double>(nullable: true),
                    max_nasal_breadth = table.Column<double>(nullable: true),
                    interobital_breadth = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cranial___88D8C19A8797E05D", x => x.cranial_id);
                    table.ForeignKey(
                        name: "FK_BURIAL2",
                        column: x => x.burial_id,
                        principalTable: "Burial",
                        principalColumn: "burial_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RACK",
                        columns: x => new { x.rack_shelf, x.rack_number },
                        principalTable: "Rack_Sample",
                        principalColumns: new[] { "rack_shelf", "rack_number" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    image_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    burial_id = table.Column<int>(nullable: true),
                    burial_square_id = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    burial_subplot = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    cranial_id = table.Column<int>(nullable: true),
                    image = table.Column<byte[]>(type: "image", nullable: true),
                    image_description = table.Column<string>(unicode: false, maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.image_id);
                    table.ForeignKey(
                        name: "FK_BURIAL3",
                        column: x => x.burial_id,
                        principalTable: "Burial",
                        principalColumn: "burial_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SQUARE",
                        column: x => x.burial_square_id,
                        principalTable: "Burial_Square",
                        principalColumn: "burial_square_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CRANIAL",
                        column: x => x.cranial_id,
                        principalTable: "Cranial_Sample",
                        principalColumn: "cranial_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QUADRANT2",
                        columns: x => new { x.burial_subplot, x.burial_square_id },
                        principalTable: "Burial_Quadrant",
                        principalColumns: new[] { "burial_subplot", "burial_square_id" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Burial_burial_square_id",
                table: "Burial",
                column: "burial_square_id");

            migrationBuilder.CreateIndex(
                name: "IX_Burial_burial_subplot_burial_square_id",
                table: "Burial",
                columns: new[] { "burial_subplot", "burial_square_id" });

            migrationBuilder.CreateIndex(
                name: "IX_Cranial_Sample_burial_id",
                table: "Cranial_Sample",
                column: "burial_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cranial_Sample_rack_shelf_rack_number",
                table: "Cranial_Sample",
                columns: new[] { "rack_shelf", "rack_number" });

            migrationBuilder.CreateIndex(
                name: "IX_Image_burial_id",
                table: "Image",
                column: "burial_id");

            migrationBuilder.CreateIndex(
                name: "IX_Image_burial_square_id",
                table: "Image",
                column: "burial_square_id");

            migrationBuilder.CreateIndex(
                name: "IX_Image_cranial_id",
                table: "Image",
                column: "cranial_id");

            migrationBuilder.CreateIndex(
                name: "IX_Image_burial_subplot_burial_square_id",
                table: "Image",
                columns: new[] { "burial_subplot", "burial_square_id" });

            migrationBuilder.CreateIndex(
                name: "IX_Rack_Sample_burial_id",
                table: "Rack_Sample",
                column: "burial_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Cranial_Sample");

            migrationBuilder.DropTable(
                name: "Rack_Sample");

            migrationBuilder.DropTable(
                name: "Burial");

            migrationBuilder.DropTable(
                name: "Burial_Square");

            migrationBuilder.DropTable(
                name: "Burial_Quadrant");
        }
    }
}
