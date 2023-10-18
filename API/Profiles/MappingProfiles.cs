
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles;

public class MappingProfiles : Profile
{
        public MappingProfiles()
    {
        CreateMap<Cita, CitaDto>().ReverseMap();
        CreateMap<CompraMedicamento, CompraMedicamentoDto>().ReverseMap();
        CreateMap<Especie, EspecieDto>().ReverseMap();
        CreateMap<Mascota, MascotaDto>().ReverseMap();
        CreateMap<Medicina, MedicinaDto>().ReverseMap();
        CreateMap<Propietario, PropietarioDto>().ReverseMap();
        CreateMap<Proveedor, ProveedorDto>().ReverseMap();
        CreateMap<Raza, RazaDto>().ReverseMap();
        CreateMap<Rol, RolDto>().ReverseMap();
        CreateMap<Tratamiento, TratamientoDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<VentaMedicamento, VentaMedicamentoDto>().ReverseMap();
        CreateMap<Veterinario, VeterinarioDto>().ReverseMap();
    }

}
