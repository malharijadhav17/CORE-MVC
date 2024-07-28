using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CORE_MVC.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedUSer",
                table: "Students",
                newName: "UpdatedUser");

            migrationBuilder.AlterColumn<string>(
                name: "SConatct",
                table: "Students",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedUser",
                table: "Students",
                newName: "UpdatedUSer");

            migrationBuilder.AlterColumn<int>(
                name: "SConatct",
                table: "Students",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}
