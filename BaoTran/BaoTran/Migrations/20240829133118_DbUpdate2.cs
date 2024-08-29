using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaoTran.Migrations
{
    public partial class DbUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PlayScheduals_StartDate_EndDate_DaysOfWeek_StartTime_EndTime",
                table: "PlayScheduals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PlayScheduals_StartDate_EndDate_DaysOfWeek_StartTime_EndTime",
                table: "PlayScheduals",
                columns: new[] { "StartDate", "EndDate", "DaysOfWeek", "StartTime", "EndTime" },
                unique: true);
        }
    }
}
