using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

    public class VentaMedicamentoConfiguration : IEntityTypeConfiguration<VentaMedicamento>
        {
            public void Configure(EntityTypeBuilder<VentaMedicamento> builder)
            {
                builder.ToTable("ventamedicamento");
    
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id)
                .HasMaxLength(3);
    
                builder.Property(e => e.Cantidad)
                .HasColumnName("cantidad")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(e => e.Precio)
                .HasColumnName("precio")
                .HasColumnType("decimal(22,2)")
                .IsRequired();

                builder.Property(e=> e.Fecha)
                .HasColumnName("fechaventa")
                .HasColumnType("datetime")
                .IsRequired();

                builder.HasOne(p => p.Medicina)
                .WithMany(p => p.VentaMedicamentos)
                .HasForeignKey(p => p.MedicinaIdFk);
            }
        }
    
