using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

    public class Veterinario:BaseEntity
    {
        public string Nombre {get; set;}
        public string Telefono {get; set;}
        public string Email {get; set;}

        /*llaves*/
        public ICollection<Cita> Citas {get; set;}
    }
