using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

    public class CitaRepository : GenericRepository<Cita>, ICita
{
    private readonly VeterinariaContext _context;

    public CitaRepository(VeterinariaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Cita>> GetAllAsync()
    {
        return await _context.Citas
            .Include(p => p.Veterinario)
            .Include(p=> p.Mascota)
            .ToListAsync();
    }

    public override async Task<Cita> GetByIdAsync(int id)
    {
        return await _context.Citas
        .Include(p=>p.Veterinario)
        .Include(p => p.Mascota)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
}