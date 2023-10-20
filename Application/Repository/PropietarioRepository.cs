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
    public async Task<object> mascotasXpropietarioGolden()
    {
        var consulta = from p in _context.Propietarios
        select new
        {
            Nombre = p.Nombre,
            Email = p.Email,
            Telefono = p.Telefono,
            Mascotas = (from m in _context.Mascotas
                        join r in _context.Razas on m.RazaIdFk equals r.Id
                        where r.Nombre == "Golden Retriver"
                        where m.PropietarioIdFk == p.Id
                        select new
                        {
                            NombreMascota = m.Nombre,
                            FechaNacimiento = m.Nacimiento,
                            Raza = r.Nombre
                        }).ToList()
        };

        var propietariosConMascotas = await consulta.ToListAsync();
        return propietariosConMascotas;
    }
    }
