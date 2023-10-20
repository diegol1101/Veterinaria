﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(VeterinariaContext))]
    partial class VeterinariaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Cita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DateTime")
                        .HasColumnName("Fecha_cita");

                    b.Property<int>("MascotaIdFk")
                        .HasColumnType("int");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Motivo_cita");

                    b.Property<int>("VeterinarioIdFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MascotaIdFk");

                    b.HasIndex("VeterinarioIdFk");

                    b.ToTable("cita", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CompraMedicamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("Cantidad");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DateTime")
                        .HasColumnName("Fecha_Compra");

                    b.Property<int>("MedicinaIdFk")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(22,2)")
                        .HasColumnName("Precio");

                    b.HasKey("Id");

                    b.HasIndex("MedicinaIdFk");

                    b.ToTable("compramedicamento", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Especie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.ToTable("especie", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Mascota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<DateTime>("Nacimiento")
                        .HasColumnType("DateTime")
                        .HasColumnName("Fecha_Nacimiento");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Nombre");

                    b.Property<int>("PropietarioIdFk")
                        .HasColumnType("int");

                    b.Property<int>("RazaIdFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PropietarioIdFk");

                    b.HasIndex("RazaIdFk");

                    b.ToTable("mascota", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Medicina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<string>("Laboratorio")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("laboratorio");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(22,2)")
                        .HasColumnName("precio");

                    b.Property<int>("ProveedorIdFk")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("stock");

                    b.HasKey("Id");

                    b.HasIndex("ProveedorIdFk");

                    b.ToTable("medicina", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Propietario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("email");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("telefono");

                    b.HasKey("Id");

                    b.ToTable("propietario", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("direccion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("telefono");

                    b.HasKey("Id");

                    b.ToTable("proveedor", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Raza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<int>("EspecieIdFk")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("raza");

                    b.HasKey("Id");

                    b.HasIndex("EspecieIdFk");

                    b.ToTable("raza", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Token")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToken", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("rolName");

                    b.HasKey("Id");

                    b.ToTable("rol", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Tratamiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<int>("CitaIdFk")
                        .HasColumnType("int");

                    b.Property<string>("Comentarios")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("comentarios");

                    b.Property<decimal>("Dosis")
                        .HasColumnType("decimal(22,2)")
                        .HasColumnName("dosis");

                    b.Property<string>("Instruccion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("instruccion");

                    b.Property<int>("MedicinaIdFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CitaIdFk");

                    b.HasIndex("MedicinaIdFk");

                    b.ToTable("tratamiento", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("email");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("username");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.UserRol", b =>
                {
                    b.Property<int>("UserIdFk")
                        .HasColumnType("int");

                    b.Property<int>("RolIdFk")
                        .HasColumnType("int");

                    b.HasKey("UserIdFk", "RolIdFk");

                    b.HasIndex("RolIdFk");

                    b.ToTable("userRol", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.VentaMedicamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("cantidad");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime")
                        .HasColumnName("fechaventa");

                    b.Property<int>("MedicinaIdFk")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(22,2)")
                        .HasColumnName("precio");

                    b.HasKey("Id");

                    b.HasIndex("MedicinaIdFk");

                    b.ToTable("ventamedicamento", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Veterinario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("email");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("especialidad");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("telefono");

                    b.HasKey("Id");

                    b.ToTable("veterinario", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Cita", b =>
                {
                    b.HasOne("Domain.Entities.Mascota", "Mascota")
                        .WithMany("Citas")
                        .HasForeignKey("MascotaIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Veterinario", "Veterinario")
                        .WithMany("Citas")
                        .HasForeignKey("VeterinarioIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mascota");

                    b.Navigation("Veterinario");
                });

            modelBuilder.Entity("Domain.Entities.CompraMedicamento", b =>
                {
                    b.HasOne("Domain.Entities.Medicina", "Medicina")
                        .WithMany("CompraMedicamentos")
                        .HasForeignKey("MedicinaIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicina");
                });

            modelBuilder.Entity("Domain.Entities.Mascota", b =>
                {
                    b.HasOne("Domain.Entities.Propietario", "Propietario")
                        .WithMany("Mascotas")
                        .HasForeignKey("PropietarioIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Raza", "Raza")
                        .WithMany("Mascotas")
                        .HasForeignKey("RazaIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Propietario");

                    b.Navigation("Raza");
                });

            modelBuilder.Entity("Domain.Entities.Medicina", b =>
                {
                    b.HasOne("Domain.Entities.Proveedor", "Proveedor")
                        .WithMany("Medicinas")
                        .HasForeignKey("ProveedorIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Domain.Entities.Raza", b =>
                {
                    b.HasOne("Domain.Entities.Especie", "Especie")
                        .WithMany("Razas")
                        .HasForeignKey("EspecieIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especie");
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Tratamiento", b =>
                {
                    b.HasOne("Domain.Entities.Cita", "Cita")
                        .WithMany("Tratamientos")
                        .HasForeignKey("CitaIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Medicina", "Medicina")
                        .WithMany("Tratamientos")
                        .HasForeignKey("MedicinaIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cita");

                    b.Navigation("Medicina");
                });

            modelBuilder.Entity("Domain.Entities.UserRol", b =>
                {
                    b.HasOne("Domain.Entities.Rol", "Rol")
                        .WithMany("UsersRols")
                        .HasForeignKey("RolIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UsersRols")
                        .HasForeignKey("UserIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.VentaMedicamento", b =>
                {
                    b.HasOne("Domain.Entities.Medicina", "Medicina")
                        .WithMany("VentaMedicamentos")
                        .HasForeignKey("MedicinaIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicina");
                });

            modelBuilder.Entity("Domain.Entities.Cita", b =>
                {
                    b.Navigation("Tratamientos");
                });

            modelBuilder.Entity("Domain.Entities.Especie", b =>
                {
                    b.Navigation("Razas");
                });

            modelBuilder.Entity("Domain.Entities.Mascota", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("Domain.Entities.Medicina", b =>
                {
                    b.Navigation("CompraMedicamentos");

                    b.Navigation("Tratamientos");

                    b.Navigation("VentaMedicamentos");
                });

            modelBuilder.Entity("Domain.Entities.Propietario", b =>
                {
                    b.Navigation("Mascotas");
                });

            modelBuilder.Entity("Domain.Entities.Proveedor", b =>
                {
                    b.Navigation("Medicinas");
                });

            modelBuilder.Entity("Domain.Entities.Raza", b =>
                {
                    b.Navigation("Mascotas");
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Navigation("UsersRols");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UsersRols");
                });

            modelBuilder.Entity("Domain.Entities.Veterinario", b =>
                {
                    b.Navigation("Citas");
                });
#pragma warning restore 612, 618
        }
    }
}
