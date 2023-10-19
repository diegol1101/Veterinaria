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