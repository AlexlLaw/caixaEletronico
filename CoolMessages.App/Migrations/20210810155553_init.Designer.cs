﻿// <auto-generated />
using System;
using CoolMessages.App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoolMessages.App.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210810155553_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CoolMessages.App.Models.Conta", b =>
                {
                    b.Property<int>("ContaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NumeroDaConta")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isAtivo")
                        .HasColumnType("INTEGER");

                    b.HasKey("ContaId");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("CoolMessages.App.Models.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cep")
                        .HasColumnType("TEXT");

                    b.Property<string>("Complemento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Localidade")
                        .HasColumnType("TEXT");

                    b.Property<string>("Logradouro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Uf")
                        .HasColumnType("TEXT");

                    b.HasKey("EnderecoId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("CoolMessages.App.Models.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ContaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Idade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("TipoContaID")
                        .HasColumnType("INTEGER");

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("CoolMessages.App.Models.TipoConta", b =>
                {
                    b.Property<int>("TipoContaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tipo")
                        .HasColumnType("TEXT");

                    b.HasKey("TipoContaId");

                    b.ToTable("TipoContas");
                });

            modelBuilder.Entity("CoolMessages.App.Models.Transferecia", b =>
                {
                    b.Property<int>("TransfereciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContaCreditadoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ContaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DataDeTransferencia")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Valor")
                        .HasColumnType("TEXT");

                    b.Property<string>("descricao")
                        .HasColumnType("TEXT");

                    b.HasKey("TransfereciaId");

                    b.HasIndex("ContaId");

                    b.ToTable("transferecias");
                });

            modelBuilder.Entity("CoolMessages.App.Models.Conta", b =>
                {
                    b.HasOne("CoolMessages.App.Models.Pessoa", "Pessoa")
                        .WithOne("Conta")
                        .HasForeignKey("CoolMessages.App.Models.Conta", "ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("CoolMessages.App.Models.Endereco", b =>
                {
                    b.HasOne("CoolMessages.App.Models.Pessoa", "Pessoa")
                        .WithOne("Endereco")
                        .HasForeignKey("CoolMessages.App.Models.Endereco", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("CoolMessages.App.Models.Transferecia", b =>
                {
                    b.HasOne("CoolMessages.App.Models.Conta", "Conta")
                        .WithMany("Transferencias")
                        .HasForeignKey("ContaId");

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("CoolMessages.App.Models.Conta", b =>
                {
                    b.Navigation("Transferencias");
                });

            modelBuilder.Entity("CoolMessages.App.Models.Pessoa", b =>
                {
                    b.Navigation("Conta");

                    b.Navigation("Endereco");
                });
#pragma warning restore 612, 618
        }
    }
}
