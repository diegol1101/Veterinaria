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
    }
