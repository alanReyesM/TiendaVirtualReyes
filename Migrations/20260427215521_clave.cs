using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaVirtualReyes.Migrations
{
    /// <inheritdoc />
    public partial class clave : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "clave",
                table: "usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "clave",
                table: "usuarios");
        }
    }
}
