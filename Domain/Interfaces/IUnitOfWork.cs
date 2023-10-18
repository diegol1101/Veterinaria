

namespace Domain.Interfaces;

    public interface IUnitOfWork
    {
        ICita Citas { get; }
        ICompraMedicamento CompraMedicamentos { get;}
        IEspecie Especies { get;}
        IMascota Mascotas { get;}
        IMedicina Medicinas { get;}
        IPropietario Propietarios { get;}
        IProveedor Proveedores { get;}
        IRaza Razas { get;}
        IRol Roles { get; }
        ITratamiento Tratamientos {get;}
        IUser Users { get; }
        IVentaMedicamento VentaMedicamentos { get;}
        IVeterinario Veterinarios { get;}
        Task<int> SaveAsync();
    }
