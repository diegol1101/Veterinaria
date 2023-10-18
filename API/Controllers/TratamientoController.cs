



using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    public class TratamientoController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public TratamientoController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<TratamientoDto>>> Get()
    {
        var tratamiento = await unitofwork.Tratamientos.GetAllAsync();
        return mapper.Map<List<TratamientoDto>>(tratamiento);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TratamientoDto>> Get(int id)
    {
        var tratamiento = await unitofwork.Tratamientos.GetByIdAsync(id);
        if (tratamiento == null)
        {
            return NotFound();
        }
        return this.mapper.Map<TratamientoDto>(tratamiento);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Tratamiento>> Post(TratamientoDto tratamientoDto)
    {
        var tratamiento = this.mapper.Map<Tratamiento>(tratamientoDto);
        this.unitofwork.Tratamientos.Add(tratamiento);
        await unitofwork.SaveAsync();
        if (tratamiento == null)
        {
            return BadRequest();
        }
        tratamientoDto.Id = tratamiento.Id;
        return CreatedAtAction(nameof(Post), new { id = tratamientoDto.Id }, tratamientoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TratamientoDto>> Put(int id, [FromBody] TratamientoDto tratamientoDto)
    {
        if (tratamientoDto == null)
        {
            return NotFound();
        }
        var tratamiento = this.mapper.Map<Tratamiento>(tratamientoDto);
        unitofwork.Tratamientos.Update(tratamiento);
        await unitofwork.SaveAsync();
        return tratamientoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var tratamiento = await unitofwork.Tratamientos.GetByIdAsync(id);
        if (tratamiento == null)
        {
            return NotFound();
        }
        unitofwork.Tratamientos.Remove(tratamiento);
        await unitofwork.SaveAsync();
        return NoContent();
    }
    
        
    }
