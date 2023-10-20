using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

    public class RazaRepository: GenericRepository<Raza>, IRaza
{
    private readonly VeterinariaContext _context;

    public RazaRepository(VeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Raza>> GetAllAsync()
    {
        return await _context.Razas
            .Include(p=> p.Especie)
            .ToListAsync();
    }

    public override async Task<Raza> GetByIdAsync(int id)
    {
        return await _context.Razas
        .Include(p=> p.Especie)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
     public override async Task<(int totalRegistros, IEnumerable<Raza> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Razas as IQueryable<Raza>;

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Include(p => p.Especie)
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
}
