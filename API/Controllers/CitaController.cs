
using API.Dtos;
using API.Helpers.Errors;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
[Authorize]

    public class CitaController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public CitaController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<CitaDto>>> Get()
    {
        var cita = await unitofwork.Citas.GetAllAsync();
        return mapper.Map<List<CitaDto>>(cita);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<CitaDto>> Get(int id)
    {
        var cita = await unitofwork.Citas.GetByIdAsync(id);
        if (cita == null)
        {
            return NotFound();
        }
        return this.mapper.Map<CitaDto>(cita);
    }
     [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<CitaDto>>> GetPagination([FromQuery] Params paisParams)
    {
        var entidad = await unitofwork.Citas.GetAllAsync(paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
        var listEntidad = mapper.Map<List<CitaDto>>(entidad.registros);
        return new Pager<CitaDto>(listEntidad, entidad.totalRegistros, paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Cita>> Post(CitaDto citaDto)
    {
        var cita = this.mapper.Map<Cita>(citaDto);
        this.unitofwork.Citas.Add(cita);
        await unitofwork.SaveAsync();
        if (cita == null)
        {
            return BadRequest();
        }
        citaDto.Id = cita.Id;
        return CreatedAtAction(nameof(Post), new { id = citaDto.Id }, citaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<CitaDto>> Put(int id, [FromBody] CitaDto citaDto)
    {
        if (citaDto == null)
        {
            return NotFound();
        }
        var cita = this.mapper.Map<Cita>(citaDto);
        unitofwork.Citas.Update(cita);
        await unitofwork.SaveAsync();
        return citaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var cita = await unitofwork.Citas.GetByIdAsync(id);
        if (cita == null)
        {
            return NotFound();
        }
        unitofwork.Citas.Remove(cita);
        await unitofwork.SaveAsync();
        return NoContent();
    }
        

    }
