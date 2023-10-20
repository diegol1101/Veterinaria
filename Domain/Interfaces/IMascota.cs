using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces;

    public interface IMascota: IGenericRepository<Mascota>
    {
        Task<IEnumerable<Mascota>>GetMascotaEspecie();
        Task<IEnumerable<Mascota>>GetMascotaPopietario();
    }
