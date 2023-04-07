using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProStellar.Server.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "EmpleadoId", "PrimerApellido", "PrimerNombre", "SegundoApellido", "SegundoNombre", "Telefono" },
                values: new object[] { 1, "De la cruz", "Kevin", "Amparo", "Duran", "829-863-5599" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Empleados",
                keyColumn: "EmpleadoId",
                keyValue: 1);
        }
    }
}
