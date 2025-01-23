using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api2Postgresql.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarcaAutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Marca = table.Column<string>(type: "text", nullable: false),
                    Modelo = table.Column<string>(type: "text", nullable: false),
                    Ano = table.Column<int>(type: "integer", nullable: false),
                    NroPuertas = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaAutos", x => x.Id);
                });
            Seed(migrationBuilder);
        }


        /// Data Seed
        /// 

        private void Seed(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MarcaAutos",
                columns: ["Id", "Marca", "Modelo", "Ano", "NroPuertas", "Color"],
                values: new object[,]
                {
                    { 1, "Toyota", "Yaris", 2021, 2, "Azul" },
                    { 2, "Kia", "Sportage", 2025, 4, "Blanco" },
                    { 3, "Fiat", "Argo", 2024, 2, "Negro" },
                    { 4, "Kia", "K4", 2025, 4, "Rojo" }
                }
             );
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarcaAutos");
            {


            }
        }
    }
}
