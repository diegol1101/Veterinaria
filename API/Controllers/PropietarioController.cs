


using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    public class PropietarioController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public PropietarioController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<PropietarioDto>>> Get()
    {
        var propietario = await unitofwork.Propietarios.GetAllAsync();
        return mapper.Map<List<PropietarioDto>>(propietario);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<PropietarioDto>> Get(int id)
    {
        var propietario = await unitofwork.Propietarios.GetByIdAsync(id);
        if (propietario == null)
        {
            return NotFound();
        }
        return this.mapper.Map<PropietarioDto>(propietario);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Propietario>> Post(PropietarioDto propietarioDto)
    {
        var propietario = this.mapper.Map<Propietario>(propietarioDto);
        this.unitofwork.Propietarios.Add(propietario);
        await unitofwork.SaveAsync();
        if (propietario == null)
        {
            return BadRequest();
        }
        propietarioDto.Id = propietario.Id;
        return CreatedAtAction(nameof(Post), new { id = propietarioDto.Id }, propietarioDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<PropietarioDto>> Put(int id, [FromBody] PropietarioDto propietarioDto)
    {
        if (propietarioDto == null)
        {
            return NotFound();
        }
        var propietario = this.mapper.Map<Propietario>(propietarioDto);
        unitofwork.Propietarios.Update(propietario);
        await unitofwork.SaveAsync();
        return propietarioDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var propietario = await unitofwork.Propietarios.GetByIdAsync(id);
        if (propietario == null)
        {
            return NotFound();
        }
        unitofwork.Propietarios.Remove(propietario);
        await unitofwork.SaveAsync();
        return NoContent();
    }
    
        
    }
