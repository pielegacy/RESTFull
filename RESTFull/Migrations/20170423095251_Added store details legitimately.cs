using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RESTFull.Migrations
{
    public partial class Addedstoredetailslegitimately : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComboItems_Combos_ComboId",
                table: "ComboItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ComboItems_MenuItems_MenuItemId",
                table: "ComboItems");

            migrationBuilder.CreateTable(
                name: "StoreDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ABN = table.Column<string>(nullable: true),
                    AddressCity = table.Column<string>(nullable: true),
                    AddressCountry = table.Column<string>(nullable: true),
                    AddressPostCode = table.Column<string>(nullable: true),
                    AddressState = table.Column<string>(nullable: true),
                    AddressStreet = table.Column<string>(nullable: true),
                    AddressSuburb = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Proprietor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_ComboItems_Combos_ComboId",
                table: "ComboItems",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "ComboId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComboItems_MenuItems_MenuItemId",
                table: "ComboItems",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
