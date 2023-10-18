using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

    public class Propietario:BaseEntity
    {
        public string Nombre {get; set;}
        public string Telefono {get; set;}
        public string Email {get; set;}


        /*llaves*/
        public ICollection<Mascota> Mascotas {get; set;}

    }
