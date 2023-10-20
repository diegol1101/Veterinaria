using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

    public class CompraMedicamentoRepository : GenericRepository<CompraMedicamento>, ICompraMedicamento
{
    private readonly VeterinariaContext _context;

    public CompraMedicamentoRepository(VeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<CompraMedicamento>> GetAllAsync()
    {
        return await _context.CompraMedicamentos
        .Include(p=>p.Medicina)
        .ToListAsync();
    }

    public override async Task<CompraMedicamento> GetByIdAsync(int id)
    {
        return await _context.CompraMedicamentos
        .Include(p=>p.Medicina)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public async Task<object> movimientoCompra()
    {
        
        var Movimiento = await (
            from d in _context.CompraMedicamentos
            
            select new{
                IdCompra = d.Id,
                total = d.Precio * d.Cantidad,
            }).Distinct()
            .ToListAsync();

        return Movimiento;
    }
}