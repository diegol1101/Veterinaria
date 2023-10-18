using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

    public class MascotaConfiguration : IEntityTypeConfiguration<Mascota>
        {
            public void Configure(EntityTypeBuilder<Mascota> builder)
            {
                builder.ToTable("mascota");
    
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id)
                .HasMaxLength(3);
    
                builder.Property(e => e.Nombre)
                .HasColumnName("Nombre")
                .IsRequired()
                .HasMaxLength(50);

                builder.Property(e => e.Nacimiento)
                .HasColumnName("Fecha_Nacimiento")
                .HasColumnType("DateTime")
                .IsRequired();

                builder.HasOne(p => p.Propietario)
                .WithMany(p => p.Mascotas)
                .HasForeignKey(p => p.PropietarioIdFk);

                builder.HasOne(p => p.Raza)
                .WithMany(p => p.Mascotas)
                .HasForeignKey(p => p.RazaIdFk);
            }
        }
    
