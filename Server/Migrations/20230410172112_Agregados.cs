using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProStellar.Server.Migrations
{
    /// <inheritdoc />
    public partial class Agregados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Pagos");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Trabajos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Concepto",
                table: "Nominas",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "Balance",
                table: "Nominas",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "NombrePersona",
                table: "NominaDetalle",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "EstadoId",
                keyValue: 1,
                column: "Descripcion",
                value: "Con deuda");

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "EstadoId",
                keyValue: 2,
                column: "Descripcion",
                value: "Paga");

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "EstadoId", "Descripcion" },
                values: new object[] { 3, "Vacia" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "EstadoId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "NombrePersona",
                table: "NominaDetalle");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Trabajos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "Pagos",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Concepto",
                table: "Nominas",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Balance",
                table: "Nominas",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "EstadoId",
                keyValue: 1,
                column: "Descripcion",
                value: "Con deuda pendiente");

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "EstadoId",
                keyValue: 2,
                column: "Descripcion",
                value: "Saldada/Pagada");
        }
    }
}
