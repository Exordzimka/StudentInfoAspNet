using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace StudentInfoAspNet.Migrations
{
    public partial class addedaveragescore3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "''"),
                    curator_family = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "''"),
                    title_direction = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "''"),
                    average_score = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "'0'"),
                    second_name = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "'0'"),
                    last_name = table.Column<string>(maxLength: 20, nullable: false, defaultValueSql: "'0'"),
                    group_id = table.Column<int>(type: "int(11)", nullable: false),
                    average_score = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                    table.ForeignKey(
                        name: "FK1",
                        column: x => x.group_id,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "FK1",
                table: "students",
                column: "group_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "groups");
        }
    }
}
