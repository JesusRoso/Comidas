using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comidas.Server.Migrations
{
    public partial class RolAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "89086180-b978-4f90-9dbd-a7040bc93f41", "0cf75cc5-9d87-451b-b3e2-fc6c99cb02fe", "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89086180-b978-4f90-9dbd-a7040bc93f41");
        }
    }
}
