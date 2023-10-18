using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

    public class Especie:BaseEntity
    {
        public string Nombre {get; set;}

        /*llaves*/
        public ICollection<Raza> Razas {get; set;}
    }
