using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos;

    public class TratamientoDto:BaseEntity
    {
        public decimal Dosis {get; set;}
        public string Instruccion {get; set;}
        public string Comentarios {get; set;}
        public int CitaIdFk {get; set;}
        public int MedicinaIdFk {get; set;}
    }
