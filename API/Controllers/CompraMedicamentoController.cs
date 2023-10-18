
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

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
    
        
    }
