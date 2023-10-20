using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

    public class VeterinarioRepository: GenericRepository<Veterinario>, IVeterinario
{
    private readonly VeterinariaContext _context;

    public VeterinarioRepository(VeterinariaContext context) : base(context)
    {
        _context = context;
    }
    
    public override async Task<IEnumerable<Veterinario>> GetAllAsync()
    {
        return await _context.Veterinarios
        .ToListAsync();
    }

    public override async Task<Veterinario> GetByIdAsync(int id)
    {
        return await _context.Veterinarios
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }

    public async Task<IEnumerable<Veterinario>> GetEspecialidad()
    {
        var Veterinarios = await _context.Veterinarios
                            .Where(p=>p.Especialidad.ToLower()=="cirujano vascular").ToListAsync();

        return Veterinarios;
    }
    public override async Task<(int totalRegistros, IEnumerable<Veterinario> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Veterinarios as IQueryable<Veterinario>;

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
}


