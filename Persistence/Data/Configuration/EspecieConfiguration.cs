using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

    public class EspecieConfiguration : IEntityTypeConfiguration<Especie>
        {
            public void Configure(EntityTypeBuilder<Especie> builder)
            {
                builder.ToTable("especie");
    
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id)
                .HasMaxLength(3);
    
                builder.Property(e => e.Nombre)
                .HasColumnName("Nombre")
                .IsRequired()
                .HasMaxLength(50);
            }
        }
    
