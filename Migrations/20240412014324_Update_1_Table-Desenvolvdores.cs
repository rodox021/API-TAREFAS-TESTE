using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class Update_1_TableDesenvolvdores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tasks_DesenvolvedorId",
                table: "Tasks");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_DesenvolvedorId",
                table: "Tasks",
                column: "DesenvolvedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tasks_DesenvolvedorId",
                table: "Tasks");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_DesenvolvedorId",
                table: "Tasks",
                column: "DesenvolvedorId",
                unique: true);
        }
    }
}
