
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

    public class CompraMedicamentoController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public CompraMedicamentoController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<CompraMedicamentoDto>>> Get()
    {
        var compraMedicamento = await unitofwork.CompraMedicamentos.GetAllAsync();
        return mapper.Map<List<CompraMedicamentoDto>>(compraMedicamento);
    }

    [HttpGet("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<CompraMedicamentoDto>> Get(int id)
    {
        var compraMedicamento = await unitofwork.CompraMedicamentos.GetByIdAsync(id);
        if (compraMedicamento == null)
        {
            return NotFound();
        }
        return this.mapper.Map<CompraMedicamentoDto>(compraMedicamento);
    }
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<CompraMedicamento>>> GetPagination([FromQuery] Params paisParams)
    {
        var entidad = await unitofwork.CompraMedicamentos.GetAllAsync(paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
        var listEntidad = mapper.Map<List<CompraMedicamento>>(entidad.registros);
        return new Pager<CompraMedicamento>(listEntidad, entidad.totalRegistros, paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<CompraMedicamento>> Post(CompraMedicamentoDto compraMedicamentosDto)
    {
        var compraMedicamento = this.mapper.Map<CompraMedicamento>(compraMedicamentosDto);
        this.unitofwork.CompraMedicamentos.Add(compraMedicamento);
        await unitofwork.SaveAsync();
        if (compraMedicamento == null)
        {
            return BadRequest();
        }
        compraMedicamentosDto.Id = compraMedicamento.Id;
        return CreatedAtAction(nameof(Post), new { id = compraMedicamentosDto.Id }, compraMedicamentosDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<CompraMedicamentoDto>> Put(int id, [FromBody] CompraMedicamentoDto compraMedicamentosDto)
    {
        if (compraMedicamentosDto == null)
        {
            return NotFound();
        }
        var compraMedicamento = this.mapper.Map<CompraMedicamento>(compraMedicamentosDto);
        unitofwork.CompraMedicamentos.Update(compraMedicamento);
        await unitofwork.SaveAsync();
        return compraMedicamentosDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var compraMedicamento = await unitofwork.CompraMedicamentos.GetByIdAsync(id);
        if (compraMedicamento == null)
        {
            return NotFound();
        }
        unitofwork.CompraMedicamentos.Remove(compraMedicamento);
        await unitofwork.SaveAsync();
        return NoContent();
    }
    [HttpGet("movimientoCompra")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> movimientoCompra()
    {
        var entidad = await unitofwork.CompraMedicamentos.movimientoCompra();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }
        
    }
