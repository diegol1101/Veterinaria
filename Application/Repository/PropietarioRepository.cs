using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

    public class PropietarioRepository: GenericRepository<Propietario>, IPropietario
{
    private readonly VeterinariaContext _context;

    public PropietarioRepository(VeterinariaContext context) : base(context)
    {
        _context = context;
    }
    
        public override async Task<IEnumerable<Propietario>> GetAllAsync()
    {
        return await _context.Propietarios
            .ToListAsync();
    }

    public override async Task<Propietario> GetByIdAsync(int id)
    {
        return await _context.Propietarios
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }

    }
