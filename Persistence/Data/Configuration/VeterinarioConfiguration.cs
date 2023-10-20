using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

    public class VeterinarioConfiguration : IEntityTypeConfiguration<Veterinario>
        {
            public void Configure(EntityTypeBuilder<Veterinario> builder)
            {
                builder.ToTable("veterinario");
    
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id)
                .HasMaxLength(3);
    
                builder.Property(e => e.Nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(50);

                builder.Property(e => e.Telefono)
                .HasColumnName("telefono")
                .IsRequired()
                .HasMaxLength(50);

                builder.Property(e => e.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(150);

                builder.Property(e => e.Especialidad)
                .HasColumnName("especialidad")
                .IsRequired()
                .HasMaxLength(100);
            }
        }
    