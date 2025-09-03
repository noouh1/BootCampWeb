using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "E_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Dependents",
                newName: "D_Id");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "E_Id",
                table: "Employees",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "D_Id",
                table: "Dependents",
                newName: "Id");
        }
    }
}
