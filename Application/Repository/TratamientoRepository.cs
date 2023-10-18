using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

    public class TratamientoRepository: GenericRepository<Tratamiento>, ITratamiento
{
    private readonly VeterinariaContext _context;

    public TratamientoRepository(VeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Tratamiento>> GetAllAsync()
    {
        return await _context.Tratamientos
        .Include(p=>p.Cita)
        .Include(p=>p.Medicina)
        .ToListAsync();
    }

    public override async Task<Tratamiento> GetByIdAsync(int id)
    {
        return await _context.Tratamientos
        .Include(p=>p.Cita)
        .Include(p=>p.Medicina)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    
}
