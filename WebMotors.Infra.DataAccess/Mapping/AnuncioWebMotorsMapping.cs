using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Domain;

namespace WebMotors.Infra.DataAccess
{
    public class AnuncioWebMotorsMapping : IEntityTypeConfiguration<AnuncioWebMotors>
    {

        public void Configure(EntityTypeBuilder<AnuncioWebMotors> builder)
        {
            builder.ToTable("tb_AnuncioWebmotors");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Marca)
                .HasColumnName("marca")
                .HasColumnType("varchar")
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(x => x.Modelo)
                .HasColumnName("Modelo")
                .HasColumnType("varchar")
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(x => x.Versao)
                .HasColumnName("Versao")
                .HasColumnType("varchar")
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(x => x.Ano)
                .HasColumnName("ano")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Quilometragem)
                .HasColumnName("quilometragem")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Observacao)
                .HasColumnName("observacao")
                .HasColumnType("text")
                .IsRequired();
        }
    }
}
