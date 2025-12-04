using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    DescontoPercentual = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Preco = table.Column<decimal>(type: "numeric(10,2)", precision: 18, scale: 2, nullable: false),
                    Categoria = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Estoque = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItensPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Preco = table.Column<decimal>(type: "numeric(10,2)", precision: 18, scale: 2, nullable: false),
                    PedidoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensPedido_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Categoria", "Estoque", "Nome", "Preco" },
                values: new object[,]
                {
                    { 1, "Periféricos", 15, "Mouse Gamer RGB", 120.90m },
                    { 2, "Periféricos", 8, "Teclado Mecânico Redragon", 289.00m },
                    { 3, "Monitores", 5, "Monitor 27'' 144hz", 1499.90m },
                    { 4, "Hardware", 3, "Notebook i7 16GB 512SSD", 4899.90m },
                    { 5, "Headset", 10, "Headset HyperX Cloud", 399.90m },
                    { 6, "Hardware", 4, "Placa de Vídeo RTX 4060 8GB", 2399.00m },
                    { 7, "Armazenamento", 12, "SSD NVMe 1TB Gen4", 499.90m },
                    { 8, "Redes", 9, "Roteador Wi-Fi 6 AX1800", 349.00m },
                    { 9, "Acessórios", 6, "Cadeira Gamer Ergonômica", 899.90m },
                    { 10, "Periféricos", 14, "Webcam Full HD 1080p", 189.00m },
                    { 11, "Acessórios", 5, "Mesa Gamer", 1200.00m },
                    { 12, "Hardware", 3, "Computador Gamer", 7200.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_PedidoId",
                table: "ItensPedido",
                column: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensPedido");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
