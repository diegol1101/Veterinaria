using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

    public class CompraMedicamentoConfiguration : IEntityTypeConfiguration<CompraMedicamento>
        {
            public void Configure(EntityTypeBuilder<CompraMedicamento> builder)
            {
                builder.ToTable("compramedicamento");
    
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id)
                .HasMaxLength(3);
    
                builder.Property(e => e.Cantidad)
                .HasColumnName("Cantidad")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(e => e.Precio)
                .HasColumnName("Precio")
                .HasColumnType("decimal(22,2)")
                .IsRequired();


                builder.Property(e => e.Fecha)
                .HasColumnName("Fecha_Compra")
                .HasColumnType("DateTime")
                .IsRequired();

                builder.HasOne(p => p.Medicina)
                .WithMany(p => p.CompraMedicamentos)
                .HasForeignKey(p => p.MedicinaIdFk);
            }

        }
        
    