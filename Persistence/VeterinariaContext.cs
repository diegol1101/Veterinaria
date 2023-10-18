using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

    public class VeterinariaContext:DbContext
    {
        
            public VeterinariaContext(DbContextOptions<VeterinariaContext> options) : base(options)
            {

            }
            public DbSet<Cita> Citas { get; set; }
            public DbSet<CompraMedicamento> CompraMedicamentos { get; set; }
            public DbSet<Especie> Especies { get; set; }
            public DbSet<Mascota> Mascotas { get; set; }
            public DbSet<Medicina> Medicinas { get; set; }
            public DbSet<Propietario> Propietarios { get; set; }
            public DbSet<Proveedor> Proveedores { get; set; }
            public DbSet<Raza> Razas { get; set; }
            public DbSet<RefreshToken> RefreshTokens { get; set; }
            public DbSet<Rol> Roles { get; set; }
            public DbSet<Tratamiento> Tratamientos { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<UserRol> UserRoles { get; set; }
            public DbSet<VentaMedicamento> VentaMedicamentos { get; set; }
            public DbSet<Veterinario> Veterinarios { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            }
    }
