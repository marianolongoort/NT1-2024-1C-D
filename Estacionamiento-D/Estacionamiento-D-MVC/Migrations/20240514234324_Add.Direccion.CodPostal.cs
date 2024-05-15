using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estacionamiento_D_MVC.Migrations
{
    /// <inheritdoc />
    public partial class AddDireccionCodPostal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodPostal",
                table: "Direcciones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodPostal",
                table: "Direcciones");
        }
    }
}
