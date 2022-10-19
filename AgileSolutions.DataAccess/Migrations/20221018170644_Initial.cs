using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgileSolutions.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "State", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2022, 10, 18, 21, 6, 44, 128, DateTimeKind.Local).AddTicks(631), false, "Information Technology", true, null });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "State", "UpdatedDate" },
                values: new object[] { 2, new DateTime(2022, 10, 18, 21, 6, 44, 128, DateTimeKind.Local).AddTicks(653), false, "Human Resource", true, null });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "CreatedDate", "DepartmentId", "Email", "IsDeleted", "Name", "State", "Surname", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2022, 10, 18, 21, 6, 44, 128, DateTimeKind.Local).AddTicks(831), 1, "ruslan.galandarli@gmail.com", false, "Ruslan", true, "Galandarli", null });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "CreatedDate", "DepartmentId", "Email", "IsDeleted", "Name", "State", "Surname", "UpdatedDate" },
                values: new object[] { 2, new DateTime(2022, 10, 18, 21, 6, 44, 128, DateTimeKind.Local).AddTicks(834), 2, "aslan.musayev@gmail.com", false, "Aslan", true, "Musayev", null });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
