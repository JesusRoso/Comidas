using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comidas.Server.Migrations
{
    public partial class Notificacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "89086180-b978-4f90-9dbd-a7040bc93f41", "cf5fae49-64dc-4da9-8757-52f1e5664c29" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf5fae49-64dc-4da9-8757-52f1e5664c29");

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    P256dh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Auth = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89086180-b978-4f90-9dbd-a7040bc93f41",
                column: "ConcurrencyStamp",
                value: "a3507df9-d053-4596-b3fe-7b77a75452fc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notificaciones");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89086180-b978-4f90-9dbd-a7040bc93f41",
                column: "ConcurrencyStamp",
                value: "c4002263-bf83-4da5-bbcb-535773f21366");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cf5fae49-64dc-4da9-8757-52f1e5664c29", 0, "c7fc5e16-0f5e-4cf5-be84-85cb85c68d58", "jdrosof@gmail.com", true, false, null, "jdrosof@gmail.com", "jdrosof@gmail.com", "AQAAAAEAACcQAAAAEKCQgzkN75DihSWMnSrjeVlqYogvPdM+HiFwawzEOzDmHkmxjdlONrlqFWkHErtu1g==", null, false, "ba36395f-b341-472c-b4f8-aacdf1504db2", false, "jdrosof@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "89086180-b978-4f90-9dbd-a7040bc93f41", "cf5fae49-64dc-4da9-8757-52f1e5664c29" });
        }
    }
}
