using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smallbiz.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddContractorCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contractors_Code",
                table: "Contractors");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Contractors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("UPDATE Contractors SET CompanyId = (SELECT MIN(Id) FROM Companies)");

            migrationBuilder.CreateIndex(
                name: "IX_Contractors_CompanyId_Code",
                table: "Contractors",
                columns: new[] { "CompanyId", "Code" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contractors_Companies_CompanyId",
                table: "Contractors",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contractors_Companies_CompanyId",
                table: "Contractors");

            migrationBuilder.DropIndex(
                name: "IX_Contractors_CompanyId_Code",
                table: "Contractors");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Contractors");

            migrationBuilder.CreateIndex(
                name: "IX_Contractors_Code",
                table: "Contractors",
                column: "Code",
                unique: true);
        }
    }
}
