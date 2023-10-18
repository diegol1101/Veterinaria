using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

    public class Tratamiento:BaseEntity
    {
        public decimal Dosis {get; set;}
        public string Instruccion {get; set;}
        public string Comentarios {get; set;}

        /*llaves*/

        public int CitaIdFk {get; set;}
        public Cita Cita {get; set;}

        public int MedicinaIdFk {get; set;}
        public Medicina Medicina {get; set;}
    }
