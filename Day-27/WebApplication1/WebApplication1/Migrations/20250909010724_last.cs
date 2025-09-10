using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class last : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "otp",
                table: "EmailConfirmations",
                newName: "Otp");

            migrationBuilder.RenameColumn(
                name: "mail",
                table: "EmailConfirmations",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Otp",
                table: "EmailConfirmations",
                newName: "otp");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "EmailConfirmations",
                newName: "mail");
        }
    }
}
