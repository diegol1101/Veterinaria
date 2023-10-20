

using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Authorize]

    public class MascotaController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public MascotaController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MascotaDto>>> Get()
    {
        var mascota = await unitofwork.Mascotas.GetAllAsync();
        return mapper.Map<List<MascotaDto>>(mascota);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<MascotaDto>> Get(int id)
    {
        var mascota = await unitofwork.Mascotas.GetByIdAsync(id);
        if (mascota == null)
        {
            return NotFound();
        }
        return this.mapper.Map<MascotaDto>(mascota);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Mascota>> Post(MascotaDto mascotaDto)
    {
        var mascota = this.mapper.Map<Mascota>(mascotaDto);
        this.unitofwork.Mascotas.Add(mascota);
        await unitofwork.SaveAsync();
        if (mascota == null)
        {
            return BadRequest();
        }
        mascotaDto.Id = mascota.Id;
        return CreatedAtAction(nameof(Post), new { id = mascotaDto.Id }, mascotaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<MascotaDto>> Put(int id, [FromBody] MascotaDto mascotaDto)
    {
        if (mascotaDto == null)
        {
            return NotFound();
        }
        var mascota = this.mapper.Map<Mascota>(mascotaDto);
        unitofwork.Mascotas.Update(mascota);
        await unitofwork.SaveAsync();
        return mascotaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var mascota = await unitofwork.Mascotas.GetByIdAsync(id);
        if (mascota == null)
        {
            return NotFound();
        }
        unitofwork.Mascotas.Remove(mascota);
        await unitofwork.SaveAsync();
        return NoContent();
    }
    
    [HttpGet("especies")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MascotaEspecieDto>>> GetMascotaEspecie()
    {
        var mascota = await unitofwork.Mascotas.GetMascotaEspecie();
        return mapper.Map<List<MascotaEspecieDto>>(mascota);
    }
    
    [HttpGet("MascotaPropietario")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MascotaPropietarioDto>>> GetMascotaPopietario()
    {
        var mascota = await unitofwork.Mascotas.GetMascotaPopietario();
        return mapper.Map<List<MascotaPropietarioDto>>(mascota);
    }

    [HttpGet("GetMascotaTrimMotivoAnio/{trim}/{motivo}/{anio}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MascotaDto>>> GetMascotaTrimMotivoAnio(int trim, string motivo, int anio)
    {
        var mascota = await unitofwork.Mascotas.GetMascotaTrimMotivoAnio(trim, motivo, anio);
        return mapper.Map<List<MascotaDto>>(mascota);
    }
    [HttpGet("mascotaXEspecie")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> mascotaXEspecie()
    {
        var entidad = await unitofwork.Mascotas.mascotaXEspecie();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }
    [HttpGet("mascotasXveterinario")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> mascotasXveterinario()
    {
        var entidad = await unitofwork.Mascotas.mascotasXveterinario();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }
    [HttpGet("mascotasXraza")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> mascotasXraza()
    {
        var entidad = await unitofwork.Mascotas.mascotasXraza();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }
}
