using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaFail.Web.Migrations
{
    public partial class TryFail22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Owners_OwnersId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_PetTypes_PetTypesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "PetTypesId",
                table: "Products",
                newName: "PetTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_PetTypesId",
                table: "Products",
                newName: "IX_Products_PetTypeId");

            migrationBuilder.RenameColumn(
                name: "OwnersId",
                table: "Orders",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OwnersId",
                table: "Orders",
                newName: "IX_Orders_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OwnerId",
                table: "Products",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OwnerId",
                table: "Orders",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Owners_OwnerId",
                table: "Orders",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Owners_OwnerId",
                table: "Products",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PetTypes_PetTypeId",
                table: "Products",
                column: "PetTypeId",
                principalTable: "PetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Owners_OwnerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Owners_OwnerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_PetTypes_PetTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OwnerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OwnerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "PetTypeId",
                table: "Products",
                newName: "PetTypesId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_PetTypeId",
                table: "Products",
                newName: "IX_Products_PetTypesId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Orders",
                newName: "OwnersId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                newName: "IX_Orders_OwnersId");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Orders",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Owners_OwnersId",
                table: "Orders",
                column: "OwnersId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PetTypes_PetTypesId",
                table: "Products",
                column: "PetTypesId",
                principalTable: "PetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
