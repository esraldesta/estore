using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estore.Services.ShoppingCartAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddShoppingCartTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_CartHeaders_CartHeaderID",
                table: "CartDetails");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "CartHeaders",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CartHeadersId",
                table: "CartHeaders",
                newName: "CartHeaderId");

            migrationBuilder.RenameColumn(
                name: "CartHeaderID",
                table: "CartDetails",
                newName: "CartHeaderId");

            migrationBuilder.RenameColumn(
                name: "CartDetailId",
                table: "CartDetails",
                newName: "CartDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_CartDetails_CartHeaderID",
                table: "CartDetails",
                newName: "IX_CartDetails_CartHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_CartHeaders_CartHeaderId",
                table: "CartDetails",
                column: "CartHeaderId",
                principalTable: "CartHeaders",
                principalColumn: "CartHeaderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_CartHeaders_CartHeaderId",
                table: "CartDetails");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CartHeaders",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "CartHeaderId",
                table: "CartHeaders",
                newName: "CartHeadersId");

            migrationBuilder.RenameColumn(
                name: "CartHeaderId",
                table: "CartDetails",
                newName: "CartHeaderID");

            migrationBuilder.RenameColumn(
                name: "CartDetailsId",
                table: "CartDetails",
                newName: "CartDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_CartDetails_CartHeaderId",
                table: "CartDetails",
                newName: "IX_CartDetails_CartHeaderID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_CartHeaders_CartHeaderID",
                table: "CartDetails",
                column: "CartHeaderID",
                principalTable: "CartHeaders",
                principalColumn: "CartHeadersId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
