using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces;

    public interface IMedicina: IGenericRepository<Medicina>
    {
        Task<IEnumerable<Medicina>> Getmedicamentolab();
        Task<IEnumerable<Medicina>> GetMedicinaPrecio();
    }
