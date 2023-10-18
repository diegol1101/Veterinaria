using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

    public class VentaMedicamentoRepository: GenericRepository<VentaMedicamento>, IVentaMedicamento
{
    private readonly VeterinariaContext _context;

    public VentaMedicamentoRepository(VeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<VentaMedicamento>> GetAllAsync()
    {
        return await _context.VentaMedicamentos
        .Include(p=>p.Medicina)
        .ToListAsync();
    }

    public override async Task<VentaMedicamento> GetByIdAsync(int id)
    {
        return await _context.VentaMedicamentos
        .Include(p=>p.Medicina)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    
}
