
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

        CreateMap<Medicina,MedicinaLabDto>()
        .ForMember(dest=>dest.Proveedor,origen=>origen.MapFrom(origen=>origen.Proveedor.Nombre))
        .ReverseMap();

        CreateMap<Mascota,MascotaEspecieDto>()
        .ForMember(dest=>dest.Especie,origen=>origen.MapFrom(origen=>origen.Raza.Especie.Nombre))
        .ReverseMap();

        CreateMap<Mascota,MascotaPropietarioDto>()
        .ForMember(dest=>dest.Propietario,origen=>origen.MapFrom(origen=>origen.Propietario.Nombre))
        .ReverseMap();

        CreateMap<Medicina,MedicinaPrecioDto>()
        .ReverseMap();


    }

}
