using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

    public class MedicinaConfiguration : IEntityTypeConfiguration<Medicina>
        {
            public void Configure(EntityTypeBuilder<Medicina> builder)
            {
                builder.ToTable("medicina");
    
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id)
                .HasMaxLength(3);
    
                builder.Property(e => e.Nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(50);

                builder.Property(p => p.Stock)
                .HasColumnName("stock")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(p => p.Precio)
                .HasColumnName("precio")
                .HasColumnType("decimal(22,2)")
                .IsRequired();

                builder.Property(e => e.Laboratorio)
                .HasColumnName("laboratorio")
                .HasMaxLength(50)
                .IsRequired();

                builder.HasOne(p => p.Proveedor)
                .WithMany(p => p.Medicinas)
                .HasForeignKey(p => p.ProveedorIdFk);
            }
        }
    
