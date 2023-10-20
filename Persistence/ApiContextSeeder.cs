using System.Globalization;
using System.Reflection;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Persistence.Data;

namespace Persistence;

public class APIContextSeeder
{
    public static async Task SeedAsync(VeterinariaContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            var ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!context.Proveedores.Any())
            {
                using (var readerLaboratorio = new StreamReader("../Persistence/Data/Csvs/Proveedor.csv"))
                {
                    using (var csvLaboratorio = new CsvReader(readerLaboratorio, CultureInfo.InvariantCulture))
                    {
                        var laboratorios = csvLaboratorio.GetRecords<Proveedor>();
                        context.Proveedores.AddRange(laboratorios);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Propietarios.Any())
            {
                using (var readerLaboratorio = new StreamReader("../Persistence/Data/Csvs/Propietario.csv"))
                {
                    using (var csvLaboratorio = new CsvReader(readerLaboratorio, CultureInfo.InvariantCulture))
                    {
                        var laboratorios = csvLaboratorio.GetRecords<Propietario>();
                        context.Propietarios.AddRange(laboratorios);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Veterinarios.Any())
            {
                using (var readerLaboratorio = new StreamReader("../Persistence/Data/Csvs/Veterinario.csv"))
                {
                    using (var csvLaboratorio = new CsvReader(readerLaboratorio, CultureInfo.InvariantCulture))
                    {
                        var laboratorios = csvLaboratorio.GetRecords<Veterinario>();
                        context.Veterinarios.AddRange(laboratorios);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Especies.Any())
            {
                using (var readerLaboratorio = new StreamReader("../Persistence/Data/Csvs/Especie.csv"))
                {
                    using (var csvLaboratorio = new CsvReader(readerLaboratorio, CultureInfo.InvariantCulture))
                    {
                        var laboratorios = csvLaboratorio.GetRecords<Especie>();
                        context.Especies.AddRange(laboratorios);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Users.Any())
            {
                using (var readerLaboratorio = new StreamReader("../Persistence/Data/Csvs/User.csv"))
                {
                    using (var csvLaboratorio = new CsvReader(readerLaboratorio, CultureInfo.InvariantCulture))
                    {
                        var laboratorios = csvLaboratorio.GetRecords<User>();
                        context.Users.AddRange(laboratorios);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Razas.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/Raza.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Raza>();
                        List<Raza> entidad = new List<Raza>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Raza
                            {
                                Id = item.Id,
                                Nombre = item.Nombre,
                                EspecieIdFk = item.EspecieIdFk
                            });
                        }
                        context.Razas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Mascotas.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/Mascota.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Mascota>();
                        List<Mascota> entidad = new List<Mascota>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Mascota
                            {
                                Id = item.Id,
                                Nombre = item.Nombre,
                                Nacimiento = item.Nacimiento,
                                RazaIdFk = item.RazaIdFk,
                                PropietarioIdFk = item.PropietarioIdFk
                            });
                        }
                        context.Mascotas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Citas.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/Cita.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Cita>();
                        List<Cita> entidad = new List<Cita>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Cita
                            {
                                Id = item.Id,
                                Fecha = item.Fecha,
                                Motivo = item.Motivo,
                                MascotaIdFk = item.MascotaIdFk,
                                VeterinarioIdFk = item.VeterinarioIdFk
                            });
                        }
                        context.Citas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Medicinas.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/Medicina.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Medicina>();
                        List<Medicina> entidad = new List<Medicina>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Medicina
                            {
                                Id = item.Id,
                                Nombre = item.Nombre,
                                Stock = item.Stock,
                                Precio = item.Precio,
                                Laboratorio = item.Laboratorio,
                                ProveedorIdFk = item.ProveedorIdFk
                            });
                        }
                        context.Medicinas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Tratamientos.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/Tratamiento.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Tratamiento>();
                        List<Tratamiento> entidad = new List<Tratamiento>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Tratamiento
                            {
                                Id = item.Id,
                                Dosis = item.Dosis,
                                Instruccion = item.Instruccion,
                                Comentarios = item.Comentarios,
                                CitaIdFk = item.CitaIdFk,
                                MedicinaIdFk = item.MedicinaIdFk
                            });
                        }
                        context.Tratamientos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.CompraMedicamentos.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/CompraMedicamento.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<CompraMedicamento>();
                        List<CompraMedicamento> entidad = new List<CompraMedicamento>();
                        foreach (var item in list)
                        {
                            entidad.Add(new CompraMedicamento
                            {
                                Id = item.Id,
                                Cantidad = item.Cantidad,
                                Precio = item.Precio,
                                Fecha = item.Fecha,
                                MedicinaIdFk = item.MedicinaIdFk
                            });
                        }
                        context.CompraMedicamentos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.VentaMedicamentos.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/VentaMedicamento.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<VentaMedicamento>();
                        List<VentaMedicamento> entidad = new List<VentaMedicamento>();
                        foreach (var item in list)
                        {
                            entidad.Add(new VentaMedicamento
                            {
                                Id = item.Id,
                                Cantidad = item.Cantidad,
                                Precio = item.Precio,
                                Fecha = item.Fecha,
                                MedicinaIdFk = item.MedicinaIdFk
                            });
                        }
                        context.VentaMedicamentos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            
            if (!context.UserRoles.Any())
            {
                using (var reader = new StreamReader("../Persistence/Data/Csvs/UserRol.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<UserRol>();
                        List<UserRol> entidad = new List<UserRol>();
                        foreach (var item in list)
                        {
                            entidad.Add(new UserRol
                            {
                                RolIdFk = item.RolIdFk,
                                UserIdFk = item.UserIdFk
                            });
                        }
                        context.UserRoles.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<VeterinariaContext>();
            logger.LogError(ex.Message);
        }
    }

    public static async Task SeedRolesAsync(VeterinariaContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.Roles.Any())
            {
                var roles = new List<Rol>()
                        {
                            new Rol { Id = 1, Nombre = "Empleado" },
                            new Rol { Id = 2, Nombre = "Administrador" }
                        };
                context.Roles.AddRange(roles);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<VeterinariaContext>();
            logger.LogError(ex.Message);
        }
    }
}