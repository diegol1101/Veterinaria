using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

    public class Cita:BaseEntity
    {
        public DateTime Fecha {get; set;}
        public string Motivo {get; set;}

        /*llaves*/

        public int MascotaIdFk {get; set;}
        public Mascota Mascota {get; set;}

        public int VeterinarioIdFk {get; set;}
        public Veterinario Veterinario {get; set;}

        public ICollection<Tratamiento> Tratamientos {get; set;}
    }
