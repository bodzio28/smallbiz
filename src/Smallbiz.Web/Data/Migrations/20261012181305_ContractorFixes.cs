using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smallbiz.Web.Migrations
{
    /// <inheritdoc />
    public partial class ContractorFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Contractors",
                newName: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Contractors_Code",
                table: "Contractors",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contractors_Code",
                table: "Contractors");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Contractors",
                newName: "isActive");
        }
    }
}
