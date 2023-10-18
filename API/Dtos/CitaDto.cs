using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos;

    public class CitaDto: BaseEntity
    {
        public DateTime Fecha {get; set;}
        public string Motivo {get; set;}
        public int MascotaIdFk {get; set;}
        public int VeterinarioIdFk {get; set;}
    }
