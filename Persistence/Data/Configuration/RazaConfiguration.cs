using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

    public class RazaConfiguration : IEntityTypeConfiguration<Raza>
        {
            public void Configure(EntityTypeBuilder<Raza> builder)
            {
                builder.ToTable("raza");
    
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id)
                .HasMaxLength(3);
    
                builder.Property(e => e.Nombre)
                .HasColumnName("raza")
                .IsRequired()
                .HasMaxLength(50);

                builder.HasOne(p => p.Especie)
                .WithMany(p => p.Razas)
                .HasForeignKey(p => p.EspecieIdFk);
            }
        }
