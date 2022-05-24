using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaFail.Web.Migrations
{
    public partial class CompleteTryFail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_PetTypes_PetTypeId",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_PetTypes_ServiceTypes_ServiceTypeId",
                table: "PetTypes");

            migrationBuilder.DropIndex(
                name: "IX_Owners_PetTypeId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "Empleado",
                table: "ServiceTypes");

            migrationBuilder.DropColumn(
                name: "Local",
                table: "PetTypes");

            migrationBuilder.DropColumn(
                name: "PetTypeId",
                table: "Owners");

            migrationBuilder.RenameColumn(
                name: "ServiceTypeId",
                table: "PetTypes",
                newName: "PetTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_PetTypes_ServiceTypeId",
                table: "PetTypes",
                newName: "IX_PetTypes_PetTypeId");

            migrationBuilder.AddColumn<int>(
                name: "PetTypeId",
                table: "ServiceTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ServiceTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PetTypesId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PetTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnersId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PetTypesId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypes_PetTypeId",
                table: "ServiceTypes",
                column: "PetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypes_UserId",
                table: "ServiceTypes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PetTypesId",
                table: "Products",
                column: "PetTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_PetTypes_UserId",
                table: "PetTypes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OwnersId",
                table: "Orders",
                column: "OwnersId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PetTypesId",
                table: "Orders",
                column: "PetTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Owners_OwnersId",
                table: "Orders",
                column: "OwnersId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PetTypes_PetTypesId",
                table: "Orders",
                column: "PetTypesId",
                principalTable: "PetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PetTypes_PetTypes_PetTypeId",
                table: "PetTypes",
                column: "PetTypeId",
                principalTable: "PetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PetTypes_AspNetUsers_UserId",
                table: "PetTypes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PetTypes_PetTypesId",
                table: "Products",
                column: "PetTypesId",
                principalTable: "PetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTypes_PetTypes_PetTypeId",
                table: "ServiceTypes",
                column: "PetTypeId",
                principalTable: "PetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTypes_AspNetUsers_UserId",
                table: "ServiceTypes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Owners_OwnersId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PetTypes_PetTypesId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_PetTypes_PetTypes_PetTypeId",
                table: "PetTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_PetTypes_AspNetUsers_UserId",
                table: "PetTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_PetTypes_PetTypesId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTypes_PetTypes_PetTypeId",
                table: "ServiceTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTypes_AspNetUsers_UserId",
                table: "ServiceTypes");

            migrationBuilder.DropIndex(
                name: "IX_ServiceTypes_PetTypeId",
                table: "ServiceTypes");

            migrationBuilder.DropIndex(
                name: "IX_ServiceTypes_UserId",
                table: "ServiceTypes");

            migrationBuilder.DropIndex(
                name: "IX_Products_PetTypesId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_PetTypes_UserId",
                table: "PetTypes");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OwnersId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PetTypesId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PetTypeId",
                table: "ServiceTypes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ServiceTypes");

            migrationBuilder.DropColumn(
                name: "PetTypesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PetTypes");

            migrationBuilder.DropColumn(
                name: "OwnersId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PetTypesId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "PetTypeId",
                table: "PetTypes",
                newName: "ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_PetTypes_PetTypeId",
                table: "PetTypes",
                newName: "IX_PetTypes_ServiceTypeId");

            migrationBuilder.AddColumn<string>(
                name: "Empleado",
                table: "ServiceTypes",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Local",
                table: "PetTypes",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PetTypeId",
                table: "Owners",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_PetTypeId",
                table: "Owners",
                column: "PetTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_PetTypes_PetTypeId",
                table: "Owners",
                column: "PetTypeId",
                principalTable: "PetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PetTypes_ServiceTypes_ServiceTypeId",
                table: "PetTypes",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
