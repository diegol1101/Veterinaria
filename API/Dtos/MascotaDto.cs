using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos;

    public class MascotaDto:BaseEntity
    {
        public string Nombre {get; set;}
        public DateTime Nacimiento {get; set;}
        public int PropietarioIdFk {get; set;}
        public int RazaIdFk {get; set;}
    }

    public class MascotaEspecieDto
    {
        public string Nombre {get; set;}
        public string Especie {get; set;}
    }

    public class MascotaPropietarioDto
    {
        public string Nombre {get; set;}
        public string Propietario {get; set;}
    }
