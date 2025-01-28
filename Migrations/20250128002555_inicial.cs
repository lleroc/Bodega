using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bodega.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnidadMedida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegSanitario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoBarras = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmpresa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DireccionEmpresa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TelefonoEmpresa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RUCEmpresa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CorreoEmpresa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NombreContacto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TelefonoContacto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Proveedores");
        }
    }
}
