using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.DataAccess.Migrations
{
    public partial class AddReward : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComeWorkTime",
                table: "Vacations");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Vacations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VacationType",
                table: "Vacations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PreviousExperienceMonth",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PreviousExperienceYear",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ContractStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_EmployeeId1",
                table: "Contracts",
                column: "EmployeeId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "VacationType",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "PreviousExperienceMonth",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PreviousExperienceYear",
                table: "Employees");

            migrationBuilder.AddColumn<DateTime>(
                name: "ComeWorkTime",
                table: "Vacations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
