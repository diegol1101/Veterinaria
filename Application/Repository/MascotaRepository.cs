using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;

namespace Application.Repository;

    public class MascotaRepository: GenericRepository<Mascota>, IMascota
{
    private readonly VeterinariaContext _context;

    public MascotaRepository(VeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Mascota>> GetAllAsync()
    {
        return await _context.Mascotas
        .Include(p=>p.Propietario)
        .Include(p=>p.Raza)
        .ToListAsync();
    }

    public override async Task<Mascota> GetByIdAsync(int id)
    {
        return await _context.Mascotas
        .Include(p=>p.Propietario)
        .Include(p=>p.Raza)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }

    public async Task<IEnumerable<Mascota>> GetMascotaEspecie()
    {
        var Especies = await _context.Mascotas
                        .Include(p=>p.Raza)
                        .ThenInclude(p=>p.Especie)
                        .Where(p=>p.Raza.Especie.Nombre.ToLower()=="felina").ToListAsync();

                    return Especies;
    }

    public async Task<IEnumerable<Mascota>> GetMascotaPopietario()
    {
        var Propietarios = await _context.Mascotas
                            .Include(p=>p.Propietario)
                            .ToListAsync();

                        return Propietarios;

    }

    public async Task<IEnumerable<Mascota>> GetMascotaTrimMotivoAnio(int trim, string Motivo, int anio)
    {
        int primerMesTrim = (trim - 1) * 3 + 1;
        return await _context.Mascotas
                            .Where(p => p.Citas.Any(p => p.Fecha.Month >= primerMesTrim && p.Fecha.Month <= primerMesTrim + 2) &&
                            p.Citas.Any(p => p.Motivo.ToUpper() == Motivo.ToUpper()) &&
                            p.Citas.Any(p => p.Fecha.Year == anio))
                            .ToListAsync(); 
    }
    public async Task<object> mascotaXEspecie()
    {
        var consulta = 
        from e in _context.Especies 
        select new
        {
            NombreEspecie = e.Nombre,
            Mascotas = (from m in _context.Mascotas
                        join r in _context.Razas on m.RazaIdFk equals r.Id
                        where m.RazaIdFk == r.Id
                        where r.EspecieIdFk == e.Id
                        select new
                        {
                            NombreMascota = m.Nombre,
                            FechaNacimiento = m.Nacimiento,
                            Raza = r.Nombre
                        }).ToList()
        };

        var MascotaEspecie = await consulta.ToListAsync();
        return MascotaEspecie;
    }
    public async Task<object> mascotasXveterinario()
    {
        var consulta = 
        from e in _context.Citas 
        join v in _context.Veterinarios on e.VeterinarioIdFk equals v.Id
        select new
        {
            Veterinario = v.Nombre,
            Mascotas = (from c in _context.Citas 
                        join m in _context.Mascotas on c.MascotaIdFk equals m.Id
                        where c.VeterinarioIdFk == v.Id
                        select new
                        {
                            NombreMascota = m.Nombre,
                            FechaNacimiento = m.Nacimiento,
                        })
                        .ToList()
        };

        var MascotaEspecie = await consulta.ToListAsync();
        return MascotaEspecie;
    }
    public virtual async Task<object> mascotasXraza()
    {
        var consulta =
        from r in _context.Razas
        select new
        {
            NombreRaza = r.Nombre,
            CantidadMascotas = _context.Mascotas.Distinct().Count(m => m.RazaIdFk == r.Id)
        };

        var MascotasPorRaza = await consulta.ToListAsync();
        return MascotasPorRaza;
    }
}
