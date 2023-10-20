



using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    public class MedicinaController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public MedicinaController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MedicinaDto>>> Get()
    {
        var medicina = await unitofwork.Medicinas.GetAllAsync();
        return mapper.Map<List<MedicinaDto>>(medicina);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<MedicinaDto>> Get(int id)
    {
        var medicina = await unitofwork.Medicinas.GetByIdAsync(id);
        if (medicina == null)
        {
            return NotFound();
        }
        return this.mapper.Map<MedicinaDto>(medicina);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Medicina>> Post(MedicinaDto medicinaDto)
    {
        var medicina = this.mapper.Map<Medicina>(medicinaDto);
        this.unitofwork.Medicinas.Add(medicina);
        await unitofwork.SaveAsync();
        if (medicina == null)
        {
            return BadRequest();
        }
        medicinaDto.Id = medicina.Id;
        return CreatedAtAction(nameof(Post), new { id = medicinaDto.Id }, medicinaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<MedicinaDto>> Put(int id, [FromBody] MedicinaDto medicinaDto)
    {
        if (medicinaDto == null)
        {
            return NotFound();
        }
        var medicina = this.mapper.Map<Medicina>(medicinaDto);
        unitofwork.Medicinas.Update(medicina);
        await unitofwork.SaveAsync();
        return medicinaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var medicina = await unitofwork.Medicinas.GetByIdAsync(id);
        if (medicina == null)
        {
            return NotFound();
        }
        unitofwork.Medicinas.Remove(medicina);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    [HttpGet("medicamentolab")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MedicinaLabDto>>> Getmedicamentolab()
    {
        var medicina = await unitofwork.Medicinas.Getmedicamentolab();
        return mapper.Map<List<MedicinaLabDto>>(medicina);
    }
    
    [HttpGet("GetMedicinaPrecio")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<MedicinaPrecioDto>>> GetMedicinaPrecio()
    {
        var medicina = await unitofwork.Medicinas.GetMedicinaPrecio();
        return mapper.Map<List<MedicinaPrecioDto>>(medicina);
    }
    
    }
