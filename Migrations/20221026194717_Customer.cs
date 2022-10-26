using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Homepage.Migrations
{
    public partial class Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreOwner",
                table: "StoreOwner");

            migrationBuilder.RenameTable(
                name: "StoreOwner",
                newName: "StoreOwners");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreOwners",
                table: "StoreOwners",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CGender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    CBirthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPhone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CUsername = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CAvatar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreOwners",
                table: "StoreOwners");

            migrationBuilder.RenameTable(
                name: "StoreOwners",
                newName: "StoreOwner");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreOwner",
                table: "StoreOwner",
                column: "Id");
        }
    }
}
