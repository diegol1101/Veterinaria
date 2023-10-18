using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

    public class Medicina:BaseEntity
    {
        public string Nombre {get; set;}
        public int Stock {get; set;}
        public decimal Precio {get; set;}
        public string Laboratorio {get; set;}

        /*llaves*/
        public int ProveedorIdFk {get; set;}
        public Proveedor Proveedor {get; set;}

        public ICollection<Tratamiento> Tratamientos {get; set;}
        public ICollection<CompraMedicamento> CompraMedicamentos {get; set;}
        public ICollection<VentaMedicamento> VentaMedicamentos {get; set;}
    }
