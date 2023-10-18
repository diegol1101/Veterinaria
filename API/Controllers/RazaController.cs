


using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    public class RazaController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public RazaController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<RazaDto>>> Get()
    {
        var raza = await unitofwork.Razas.GetAllAsync();
        return mapper.Map<List<RazaDto>>(raza);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<RazaDto>> Get(int id)
    {
        var raza = await unitofwork.Razas.GetByIdAsync(id);
        if (raza == null)
        {
            return NotFound();
        }
        return this.mapper.Map<RazaDto>(raza);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Raza>> Post(RazaDto razaDto)
    {
        var raza = this.mapper.Map<Raza>(razaDto);
        this.unitofwork.Razas.Add(raza);
        await unitofwork.SaveAsync();
        if (raza == null)
        {
            return BadRequest();
        }
        razaDto.Id = raza.Id;
        return CreatedAtAction(nameof(Post), new { id = razaDto.Id }, razaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<RazaDto>> Put(int id, [FromBody] RazaDto razaDto)
    {
        if (razaDto == null)
        {
            return NotFound();
        }
        var raza = this.mapper.Map<Raza>(razaDto);
        unitofwork.Razas.Update(raza);
        await unitofwork.SaveAsync();
        return razaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var raza = await unitofwork.Razas.GetByIdAsync(id);
        if (raza == null)
        {
            return NotFound();
        }
        unitofwork.Razas.Remove(raza);
        await unitofwork.SaveAsync();
        return NoContent();
    }
    
        
    }
