using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

    public class ProveedorRepository: GenericRepository<Proveedor>, IProveedor
{
    private readonly VeterinariaContext _context;

    public ProveedorRepository(VeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Proveedor>> GetAllAsync()
    {
        return await _context.Proveedores
        .ToListAsync();
    }

    public override async Task<Proveedor> GetByIdAsync(int id)
    {
        return await _context.Proveedores
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public async Task<object> medicamentoXProveedor()
    {
        var consulta = from m in _context.Medicinas
        select new
        {
            Nombre = m.Nombre,
            proveedores = (from mp in _context.Proveedores
                        where m.ProveedorIdFk == mp.Id
                        select new
                        {
                            NombreProveedor = mp.Nombre,
                        }).ToList()
        };

        var propietariosConMascotas = await consulta.ToListAsync();
        return propietariosConMascotas;
    }
    public override async Task<(int totalRegistros, IEnumerable<Proveedor> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Proveedores as IQueryable<Proveedor>;

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
