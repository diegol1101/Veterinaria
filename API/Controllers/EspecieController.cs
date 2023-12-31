
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using API.Helpers.Errors;
namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
[Authorize]
    public class EspecieController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public EspecieController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<EspecieDto>>> Get()
    {
        var especie = await unitofwork.Especies.GetAllAsync();
        return mapper.Map<List<EspecieDto>>(especie);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<EspecieDto>> Get(int id)
    {
        var especie = await unitofwork.Especies.GetByIdAsync(id);
        if (especie == null)
        {
            return NotFound();
        }
        return this.mapper.Map<EspecieDto>(especie);
    }
     [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<EspecieDto>>> GetPagination([FromQuery] Params paisParams)
    {
        var entidad = await unitofwork.Especies.GetAllAsync(paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
        var listEntidad = mapper.Map<List<EspecieDto>>(entidad.registros);
        return new Pager<EspecieDto>(listEntidad, entidad.totalRegistros, paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Especie>> Post(EspecieDto especieDto)
    {
        var especie = this.mapper.Map<Especie>(especieDto);
        this.unitofwork.Especies.Add(especie);
        await unitofwork.SaveAsync();
        if (especie == null)
        {
            return BadRequest();
        }
        especieDto.Id = especie.Id;
        return CreatedAtAction(nameof(Post), new { id = especieDto.Id }, especieDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<EspecieDto>> Put(int id, [FromBody] EspecieDto especieDto)
    {
        if (especieDto == null)
        {
            return NotFound();
        }
        var especie = this.mapper.Map<Especie>(especieDto);
        unitofwork.Especies.Update(especie);
        await unitofwork.SaveAsync();
        return especieDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var especie = await unitofwork.Especies.GetByIdAsync(id);
        if (especie == null)
        {
            return NotFound();
        }
        unitofwork.Especies.Remove(especie);
        await unitofwork.SaveAsync();
        return NoContent();
    }
    
        
}
