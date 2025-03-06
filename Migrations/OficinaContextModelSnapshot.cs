﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OficinaAPI.connection;

#nullable disable

namespace OficinaAPI.Migrations
{
    [DbContext(typeof(OficinaContext))]
    partial class OficinaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OficinaAPI.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("clienteid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("endereco");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("telefone");

                    b.HasKey("ClienteId");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("OficinaAPI.Models.ItemOrcamento", b =>
                {
                    b.Property<int>("ItemOrcamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("itemorcamentoid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ItemOrcamentoId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("descricao");

                    b.Property<int>("OrcamentoId")
                        .HasColumnType("integer")
                        .HasColumnName("orcamentoId");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric")
                        .HasColumnName("valor");

                    b.HasKey("ItemOrcamentoId");

                    b.HasIndex("OrcamentoId");

                    b.ToTable("itensorcamento");
                });

            modelBuilder.Entity("OficinaAPI.Models.Orcamento", b =>
                {
                    b.Property<int>("OrcamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("orcamentoid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrcamentoId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer")
                        .HasColumnName("clienteid");

                    b.Property<int?>("ClienteId1")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("numeric")
                        .HasColumnName("valor");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("integer")
                        .HasColumnName("veiculoId");

                    b.HasKey("OrcamentoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ClienteId1");

                    b.HasIndex("VeiculoId");

                    b.ToTable("orcamentos");
                });

            modelBuilder.Entity("OficinaAPI.Models.Veiculo", b =>
                {
                    b.Property<int>("VeiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("veiculoid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VeiculoId"));

                    b.Property<int>("Ano")
                        .HasMaxLength(8)
                        .HasColumnType("integer")
                        .HasColumnName("ano");

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer")
                        .HasColumnName("clienteid");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("marca");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("modelo");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("placa");

                    b.HasKey("VeiculoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("veiculos");
                });

            modelBuilder.Entity("OficinaAPI.Models.ItemOrcamento", b =>
                {
                    b.HasOne("OficinaAPI.Models.Orcamento", "Orcamento")
                        .WithMany("Itens")
                        .HasForeignKey("OrcamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orcamento");
                });

            modelBuilder.Entity("OficinaAPI.Models.Orcamento", b =>
                {
                    b.HasOne("OficinaAPI.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OficinaAPI.Models.Cliente", null)
                        .WithMany("Orcamentos")
                        .HasForeignKey("ClienteId1");

                    b.HasOne("OficinaAPI.Models.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("OficinaAPI.Models.Veiculo", b =>
                {
                    b.HasOne("OficinaAPI.Models.Cliente", "Cliente")
                        .WithMany("Veiculos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("OficinaAPI.Models.Cliente", b =>
                {
                    b.Navigation("Orcamentos");

                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("OficinaAPI.Models.Orcamento", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
