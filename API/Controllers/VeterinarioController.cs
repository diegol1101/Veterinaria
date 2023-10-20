



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

    public class VeterinarioController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public VeterinarioController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<VeterinarioDto>>> Get()
    {
        var veterinario = await unitofwork.Veterinarios.GetAllAsync();
        return mapper.Map<List<VeterinarioDto>>(veterinario);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<VeterinarioDto>> Get(int id)
    {
        var veterinario = await unitofwork.Veterinarios.GetByIdAsync(id);
        if (veterinario == null)
        {
            return NotFound();
        }
        return this.mapper.Map<VeterinarioDto>(veterinario);
    }
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<VeterinarioDto>>> GetPagination([FromQuery] Params paisParams)
    {
        var entidad = await unitofwork.Veterinarios.GetAllAsync(paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
        var listEntidad = mapper.Map<List<VeterinarioDto>>(entidad.registros);
        return new Pager<VeterinarioDto>(listEntidad, entidad.totalRegistros, paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Veterinario>> Post(VeterinarioDto veterinarioDto)
    {
        var veterinario = this.mapper.Map<Veterinario>(veterinarioDto);
        this.unitofwork.Veterinarios.Add(veterinario);
        await unitofwork.SaveAsync();
        if (veterinario == null)
        {
            return BadRequest();
        }
        veterinarioDto.Id = veterinario.Id;
        return CreatedAtAction(nameof(Post), new { id = veterinarioDto.Id }, veterinarioDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<VeterinarioDto>> Put(int id, [FromBody] VeterinarioDto veterinarioDto)
    {
        if (veterinarioDto == null)
        {
            return NotFound();
        }
        var veterinario = this.mapper.Map<Veterinario>(veterinarioDto);
        unitofwork.Veterinarios.Update(veterinario);
        await unitofwork.SaveAsync();
        return veterinarioDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var veterinario = await unitofwork.Veterinarios.GetByIdAsync(id);
        if (veterinario == null)
        {
            return NotFound();
        }
        unitofwork.Veterinarios.Remove(veterinario);
        await unitofwork.SaveAsync();
        return NoContent();
    }
    
    [HttpGet("veterinarioespecialidad")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<VeterinarioDto>>> GetEspecialidad()
    {
        var veterinario = await unitofwork.Veterinarios.GetEspecialidad();
        return mapper.Map<List<VeterinarioDto>>(veterinario);
    }
    }
