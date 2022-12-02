using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.DataAccess.Migrations
{
    public partial class core2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Duty_DutyId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Duty",
                table: "Duty");

            migrationBuilder.RenameTable(
                name: "Duty",
                newName: "Duties");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Notifications",
                newName: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Duties",
                table: "Duties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Duties_DutyId",
                table: "Employees",
                column: "DutyId",
                principalTable: "Duties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Duties_DutyId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Duties",
                table: "Duties");

            migrationBuilder.RenameTable(
                name: "Duties",
                newName: "Duty");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Notifications",
                newName: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Duty",
                table: "Duty",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Duty_DutyId",
                table: "Employees",
                column: "DutyId",
                principalTable: "Duty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
