using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial1SM.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModelMaker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BrandName = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    ModelMakerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelMaker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelKit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Pieces = table.Column<int>(type: "INTEGER", nullable: false),
                    Finished = table.Column<bool>(type: "INTEGER", nullable: false),
                    ModelMakerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelKit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelKit_ModelMaker_ModelMakerId",
                        column: x => x.ModelMakerId,
                        principalTable: "ModelMaker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModelKit_ModelMakerId",
                table: "ModelKit",
                column: "ModelMakerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelKit");

            migrationBuilder.DropTable(
                name: "ModelMaker");
        }
    }
}
