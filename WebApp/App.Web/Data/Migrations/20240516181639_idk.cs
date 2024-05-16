using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Web.Data.Migrations
{
    public partial class idk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInShoppingCarts_ShoppingCarts_ProductId",
                table: "ProductInShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInShoppingCarts_Products_ShoppingCartId",
                table: "ProductInShoppingCarts");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInShoppingCarts_Products_ProductId",
                table: "ProductInShoppingCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInShoppingCarts_ShoppingCarts_ShoppingCartId",
                table: "ProductInShoppingCarts",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInShoppingCarts_Products_ProductId",
                table: "ProductInShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInShoppingCarts_ShoppingCarts_ShoppingCartId",
                table: "ProductInShoppingCarts");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInShoppingCarts_ShoppingCarts_ProductId",
                table: "ProductInShoppingCarts",
                column: "ProductId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInShoppingCarts_Products_ShoppingCartId",
                table: "ProductInShoppingCarts",
                column: "ShoppingCartId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
