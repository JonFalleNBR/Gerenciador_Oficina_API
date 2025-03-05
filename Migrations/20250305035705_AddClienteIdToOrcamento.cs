using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OficinaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddClienteIdToOrcamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    clienteid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    telefone = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    endereco = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.clienteid);
                });

            migrationBuilder.CreateTable(
                name: "veiculos",
                columns: table => new
                {
                    veiculoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    marca = table.Column<string>(type: "text", nullable: false),
                    modelo = table.Column<string>(type: "text", nullable: false),
                    placa = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ano = table.Column<int>(type: "integer", maxLength: 8, nullable: false),
                    clienteid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculos", x => x.veiculoid);
                    table.ForeignKey(
                        name: "FK_veiculos_clientes_clienteid",
                        column: x => x.clienteid,
                        principalTable: "clientes",
                        principalColumn: "clienteid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orcamentos",
                columns: table => new
                {
                    orcamentoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    veiculoId = table.Column<int>(type: "integer", nullable: false),
                    clienteid = table.Column<int>(type: "integer", nullable: false),
                    data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    valor = table.Column<decimal>(type: "numeric", nullable: false),
                    ClienteId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orcamentos", x => x.orcamentoid);
                    table.ForeignKey(
                        name: "FK_orcamentos_clientes_ClienteId1",
                        column: x => x.ClienteId1,
                        principalTable: "clientes",
                        principalColumn: "clienteid");
                    table.ForeignKey(
                        name: "FK_orcamentos_clientes_clienteid",
                        column: x => x.clienteid,
                        principalTable: "clientes",
                        principalColumn: "clienteid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orcamentos_veiculos_veiculoId",
                        column: x => x.veiculoId,
                        principalTable: "veiculos",
                        principalColumn: "veiculoid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "itensorcamento",
                columns: table => new
                {
                    itemorcamentoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    orcamentoId = table.Column<int>(type: "integer", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    valor = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itensorcamento", x => x.itemorcamentoid);
                    table.ForeignKey(
                        name: "FK_itensorcamento_orcamentos_orcamentoId",
                        column: x => x.orcamentoId,
                        principalTable: "orcamentos",
                        principalColumn: "orcamentoid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_itensorcamento_orcamentoId",
                table: "itensorcamento",
                column: "orcamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_orcamentos_clienteid",
                table: "orcamentos",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_orcamentos_ClienteId1",
                table: "orcamentos",
                column: "ClienteId1");

            migrationBuilder.CreateIndex(
                name: "IX_orcamentos_veiculoId",
                table: "orcamentos",
                column: "veiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_veiculos_clienteid",
                table: "veiculos",
                column: "clienteid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itensorcamento");

            migrationBuilder.DropTable(
                name: "orcamentos");

            migrationBuilder.DropTable(
                name: "veiculos");

            migrationBuilder.DropTable(
                name: "clientes");
        }
    }
}
