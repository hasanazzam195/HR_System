using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_System.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_departmentID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_departmentID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "departmentID",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "Department_id",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Department_id",
                table: "Employees",
                column: "Department_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_Department_id",
                table: "Employees",
                column: "Department_id",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_Department_id",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Department_id",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Department_id",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "departmentID",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_departmentID",
                table: "Employees",
                column: "departmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_departmentID",
                table: "Employees",
                column: "departmentID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
