using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

    public class CitaConfiguration:IEntityTypeConfiguration<Cita>
        {
            public void Configure(EntityTypeBuilder<Cita> builder)
            {
                builder.ToTable("cita");
    
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id)
                .HasMaxLength(3);
    
                builder.Property(e => e.Fecha)
                .HasColumnName("Fecha_cita")
                .HasColumnType("DateTime")
                .IsRequired();

                builder.Property(e => e.Motivo)
                .HasColumnName("Motivo_cita")
                .IsRequired();

                builder.HasOne(p => p.Veterinario)
                .WithMany(p => p.Citas)
                .HasForeignKey(p => p.VeterinarioIdFk);

                builder.HasOne(p => p.Mascota)
                .WithMany(p => p.Citas)
                .HasForeignKey(p => p.MascotaIdFk);
                
            }
        }
    
