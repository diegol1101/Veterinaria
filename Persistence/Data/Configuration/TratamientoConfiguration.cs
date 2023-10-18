
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

    public class TratamientoConfiguration: IEntityTypeConfiguration<Tratamiento>
        {
            public void Configure(EntityTypeBuilder<Tratamiento> builder)
            {
                builder.ToTable("tratamiento");
    
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id)
                .HasMaxLength(3);
    
                builder.Property(e => e.Instruccion)
                .HasColumnName("instruccion")
                .IsRequired()
                .HasMaxLength(150);

                builder.Property(e=> e.Dosis)
                .HasColumnName("dosis")
                .HasColumnType("decimal(22,2)")
                .IsRequired();

                builder.Property(e => e.Comentarios)
                .HasColumnName("comentarios")
                .IsRequired()
                .HasMaxLength(150);

                builder.HasOne(p => p.Cita)
                .WithMany(p => p.Tratamientos)
                .HasForeignKey(p => p.CitaIdFk);

                builder.HasOne(p => p.Medicina)
                .WithMany(p => p.Tratamientos)
                .HasForeignKey(p => p.MedicinaIdFk);

            }
        }
    