using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABB_PROJECT_API.Migrations
{
    /// <inheritdoc />
    public partial class AddNameColumnToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TblUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "TblUser");
        }
    }
}
