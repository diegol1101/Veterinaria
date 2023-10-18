

using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly VeterinariaContext _context;
        private CitaRepository _citas;
        private CompraMedicamentoRepository _compraMedicamentos;
        private EspecieRepository _especies;
        private MascotaRepository _mascotas;
        private MedicinaRepository _medicinas;
        private PropietarioRepository _propietarios;
        private ProveedorRepository _proveedores;
        private RazaRepository _razas;
        private RolRepository _roles;
        private TratamientoRepository _tratamientos;
        private UserRepository _users;
        private VentaMedicamentoRepository _ventaMedicamentos;
        private VeterinarioRepository _veterinarios;


        public UnitOfWork(VeterinariaContext context)
        {
            _context = context;
        }

        public ICita Citas
        {
            get
            {
                if (_citas == null)
                {
                    _citas = new CitaRepository(_context);
                }
                return _citas;
            }
        }

        public ICompraMedicamento CompraMedicamentos
        {
            get
            {
                if (_compraMedicamentos == null)
                {
                    _compraMedicamentos = new CompraMedicamentoRepository(_context);
                }
                return _compraMedicamentos;
            }
        }

        public IEspecie Especies
        {
            get
            {
                if (_especies == null)
                {
                    _especies = new EspecieRepository(_context);
                }
                return _especies;
            }
        }

        public IMascota Mascotas
        {
            get
            {
                if (_mascotas == null)
                {
                    _mascotas = new MascotaRepository(_context);
                }
                return _mascotas;
            }
        }

        public IMedicina Medicinas
        {
            get
            {
                if (_medicinas == null)
                {
                    _medicinas = new MedicinaRepository(_context);
                }
                return _medicinas;
            }
        }

        public IPropietario Propietarios
        {
            get
            {
                if (_propietarios == null)
                {
                    _propietarios = new PropietarioRepository(_context);
                }
                return _propietarios;
            }
        }

        public IProveedor Proveedores
        {
            get
            {
                if (_proveedores == null)
                {
                    _proveedores = new ProveedorRepository(_context);
                }
                return _proveedores;
            }
        }

        public IRaza Razas
        {
            get
            {
                if (_razas == null)
                {
                    _razas = new RazaRepository(_context);
                }
                return _razas;
            }
        }

        public IRol Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new RolRepository(_context);
                }
                return _roles;
            }
        }

        public ITratamiento Tratamientos
        {
            get
            {
                if (_tratamientos == null)
                {
                    _tratamientos = new TratamientoRepository(_context);
                }
                return _tratamientos;
            }
        }

        public IUser Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_context);
                }
                return _users;
            }
        }

        public IVentaMedicamento VentaMedicamentos
        {
            get
            {
                if (_ventaMedicamentos == null)
                {
                    _ventaMedicamentos = new VentaMedicamentoRepository(_context);
                }
                return _ventaMedicamentos;
            }
        }

        public IVeterinario Veterinarios
        {
            get
            {
                if (_veterinarios == null)
                {
                    _veterinarios = new VeterinarioRepository(_context);
                }
                return _veterinarios;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
