

using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

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
    
        
    }
