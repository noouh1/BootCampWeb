using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
migrationBuilder.DropForeignKey(
        name: "FK_Carts_AspNetUsers_UserId",
        table: "Carts");

    migrationBuilder.DropForeignKey(
        name: "FK_Carts_Products_ProductId1",
        table: "Carts");

    migrationBuilder.DropIndex(
        name: "IX_Carts_ProductId1",
        table: "Carts");

    migrationBuilder.DropColumn(
        name: "ProductId1",
        table: "Carts");

    migrationBuilder.AddColumn<string>(
        name: "imageUrl",
        table: "Products",
        type: "nvarchar(max)",
        nullable: false,
        defaultValue: "default-image-url");

    migrationBuilder.AlterColumn<string>(
        name: "UserId",
        table: "Carts",
        type: "nvarchar(450)",
        nullable: false,
        defaultValue: "",
        oldClrType: typeof(string),
        oldType: "nvarchar(450)",
        oldNullable: true);

    migrationBuilder.AlterColumn<int>(
        name: "ProductId",
        table: "Carts",
        type: "int",
        nullable: false,
        oldClrType: typeof(string),
        oldType: "nvarchar(max)");

    // Drop the primary key constraint
    migrationBuilder.DropPrimaryKey(
        name: "PK_Carts",
        table: "Carts");



    // Recreate the Id column with the IDENTITY property
    migrationBuilder.AddColumn<int>(
        name: "CartId",
        table: "Carts",
        type: "int",
        nullable: false)
        .Annotation("SqlServer:Identity", "1, 1");

    // Re-add the primary key constraint
    migrationBuilder.AddPrimaryKey(
        name: "PK_Carts",
        table: "Carts",
        column: "CartId");

    migrationBuilder.CreateTable(
        name: "EmailOtps",
        columns: table => new
        {
            Id = table.Column<int>(type: "int", nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
            Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
            ExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            IsUsed = table.Column<bool>(type: "bit", nullable: false)
        },
        constraints: table =>
        {
        });

    migrationBuilder.CreateIndex(
        name: "IX_Carts_ProductId",
        table: "Carts",
        column: "ProductId");

    migrationBuilder.AddForeignKey(
        name: "FK_Carts_AspNetUsers_UserId",
        table: "Carts",
        column: "UserId",
        principalTable: "AspNetUsers",
        principalColumn: "Id",
        onDelete: ReferentialAction.Cascade);

    migrationBuilder.AddForeignKey(
        name: "FK_Carts_Products_ProductId",
        table: "Carts",
        column: "ProductId",
        principalTable: "Products",
        principalColumn: "Id",
        onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Products_ProductId",
                table: "Carts");

            migrationBuilder.DropTable(
                name: "EmailOtps");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ProductId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductId1",
                table: "Carts",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Products_ProductId1",
                table: "Carts",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
