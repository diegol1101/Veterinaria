using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

    public class PropietarioConfiguration : IEntityTypeConfiguration<Propietario>
        {
            public void Configure(EntityTypeBuilder<Propietario> builder)
            {
                builder.ToTable("propietario");
    
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
            }
        }
    