using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

    public class MedicinaRepository: GenericRepository<Medicina>, IMedicina
{
    private readonly VeterinariaContext _context;

    public MedicinaRepository(VeterinariaContext context) : base(context)
    {
        _context = context;
    }
    
    public override async Task<IEnumerable<Medicina>> GetAllAsync()
    {
        return await _context.Medicinas
        .Include(p=>p.Proveedor)
        .ToListAsync();
    }

    public override async Task<Medicina> GetByIdAsync(int id)
    {
        return await _context.Medicinas
        .Include(p=>p.Proveedor)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }

    public async Task<IEnumerable<Medicina>> Getmedicamentolab()
    {
        var Medicina = await _context.Medicinas
                            .Include(p=>p.Proveedor)
                            .Where(p=>p.Laboratorio.ToLower()=="genfar").ToListAsync();
                        return Medicina;
    }

    public async Task<IEnumerable<Medicina>> GetMedicinaPrecio()
    {
        var Precio = await _context.Medicinas
                        .Where(p=>p.Precio >= 50000).ToListAsync();

                    return Precio;
    }
    public override async Task<(int totalRegistros, IEnumerable<Medicina> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Medicinas as IQueryable<Medicina>;

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
        .Include(p=>p.Proveedor)
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
}
