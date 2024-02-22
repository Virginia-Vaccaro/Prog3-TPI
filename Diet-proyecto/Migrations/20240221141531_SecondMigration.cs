using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diet_proyecto.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DNI", "Email", "LastName", "Name", "Password", "PhoneNumber", "UserName" },
                values: new object[] { 11333444, "lr@gmail.com", "Ramon", "Lucy", "123LR", 11223366, "Lura" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserType",
                value: "Admin");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "DNI", "Email", "LastName", "Name", "Password", "PhoneNumber", "UserName", "UserType" },
                values: new object[] { 3, "calle 456", 11333222, "facu@gmail.com", "Bargut", "Facundo", "123facu", 11223355, "Facu", "Salesman" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DNI", "Email", "LastName", "Name", "Password", "PhoneNumber", "UserName" },
                values: new object[] { 11333222, "facu@gmail.com", "Bargut", "Facundo", "123facu", 11223344, "Facu" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "DNI", "Email", "LastName", "Name", "Password", "PhoneNumber", "UserName", "UserType" },
                values: new object[] { 1, "calle 123", 35131301, "vir.vaccaro@gmail.com", "Vaccaro", "Virginia", "123vir", 11223344, "Vir", "Salesman" });
        }
    }
}
