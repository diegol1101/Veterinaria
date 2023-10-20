using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos;

    public class CompraMedicamentoDto:BaseEntity
    {
        public int Cantidad {get; set;}
        public decimal Precio {get; set;}
        public DateTime Fecha {get; set;}
        public int MedicinaIdFk {get; set;}
    }
