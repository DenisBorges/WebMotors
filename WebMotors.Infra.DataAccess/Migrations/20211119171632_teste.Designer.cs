﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebMotors.Infra.DataAccess;

namespace WebMotors.Infra.DataAccess.Migrations
{
    [DbContext(typeof(Conexao))]
    [Migration("20211119171632_teste")]
    partial class teste
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WebMotors.Domain.AnuncioWebMotors", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Ano")
                        .HasColumnType("int")
                        .HasColumnName("ano");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("marca");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("Modelo");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("observacao");

                    b.Property<int>("Quilometragem")
                        .HasColumnType("int")
                        .HasColumnName("quilometragem");

                    b.Property<string>("Versao")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("Versao");

                    b.HasKey("ID");

                    b.ToTable("tb_AnuncioWebmotors");
                });
#pragma warning restore 612, 618
        }
    }
}
