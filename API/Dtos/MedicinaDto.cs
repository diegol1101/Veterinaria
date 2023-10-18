using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos;

    public class MedicinaDto:BaseEntity
    {
        public string Nombre {get; set;}
        public int Stock {get; set;}
        public decimal Precio {get; set;}
        public string Laboratorio {get; set;}
        public int ProveedorIdFk {get; set;}
    }
