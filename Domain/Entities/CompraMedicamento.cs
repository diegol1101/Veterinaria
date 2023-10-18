using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

    public class CompraMedicamento:BaseEntity
    {

        public int Cantidad {get; set;}
        public decimal Precio {get; set;}
        public DateTime Fecha {get; set;}


        /*llaves*/
        public int ProveedorIdFk {get; set;}
        public Proveedor Proveedor {get; set;}

        public int MedicinaIdFk {get; set;}
        public Medicina Medicina {get; set;}
    }
