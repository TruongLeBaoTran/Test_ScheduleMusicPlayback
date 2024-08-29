using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaoTran.Migrations
{
    public partial class DbNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileTypes",
                columns: table => new
                {
                    IdFileType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTypes", x => x.IdFileType);
                });

            migrationBuilder.CreateTable(
                name: "MediaFiles",
                columns: table => new
                {
                    IdMediaFile = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Singer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Musician = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileFormat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdFileType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaFiles", x => x.IdMediaFile);
                    table.ForeignKey(
                        name: "FK_MediaFiles_FileTypes_IdFileType",
                        column: x => x.IdFileType,
                        principalTable: "FileTypes",
                        principalColumn: "IdFileType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayScheduals",
                columns: table => new
                {
                    IdPlaySchedual = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaysOfWeek = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdMediaFile = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayScheduals", x => x.IdPlaySchedual);
                    table.ForeignKey(
                        name: "FK_PlayScheduals_MediaFiles_IdMediaFile",
                        column: x => x.IdMediaFile,
                        principalTable: "MediaFiles",
                        principalColumn: "IdMediaFile",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_IdFileType",
                table: "MediaFiles",
                column: "IdFileType");

            migrationBuilder.CreateIndex(
                name: "IX_PlayScheduals_IdMediaFile",
                table: "PlayScheduals",
                column: "IdMediaFile");

            migrationBuilder.CreateIndex(
                name: "IX_PlayScheduals_StartDate_EndDate_DaysOfWeek_StartTime_EndTime",
                table: "PlayScheduals",
                columns: new[] { "StartDate", "EndDate", "DaysOfWeek", "StartTime", "EndTime" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayScheduals");

            migrationBuilder.DropTable(
                name: "MediaFiles");

            migrationBuilder.DropTable(
                name: "FileTypes");
        }
    }
}
