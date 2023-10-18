using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos;

    public class VeterinarioDto:BaseEntity
    {
        public string Nombre {get; set;}
        public string Telefono {get; set;}
        public string Email {get; set;}
    }
