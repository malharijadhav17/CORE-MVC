using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CORE_MVC.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SConatct",
                table: "Students",
                newName: "SContact");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SContact",
                table: "Students",
                newName: "SConatct");
        }
    }
}
