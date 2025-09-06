using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class addPID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ApprovedProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ApprovedProducts_ProductId",
                table: "ApprovedProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovedProducts_Products_ProductId",
                table: "ApprovedProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovedProducts_Products_ProductId",
                table: "ApprovedProducts");

            migrationBuilder.DropIndex(
                name: "IX_ApprovedProducts_ProductId",
                table: "ApprovedProducts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ApprovedProducts");
        }
    }
}
