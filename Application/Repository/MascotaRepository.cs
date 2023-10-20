using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

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
}
