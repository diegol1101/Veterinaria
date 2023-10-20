



using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Authorize]

    public class VentaMedicamentoController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public VentaMedicamentoController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<VentaMedicamentoDto>>> Get()
    {
        var ventaMedicamento = await unitofwork.VentaMedicamentos.GetAllAsync();
        return mapper.Map<List<VentaMedicamentoDto>>(ventaMedicamento);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<VentaMedicamentoDto>> Get(int id)
    {
        var ventaMedicamento = await unitofwork.VentaMedicamentos.GetByIdAsync(id);
        if (ventaMedicamento == null)
        {
            return NotFound();
        }
        return this.mapper.Map<VentaMedicamentoDto>(ventaMedicamento);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<VentaMedicamento>> Post(VentaMedicamentoDto ventaMedicamentoDto)
    {
        var ventaMedicamento = this.mapper.Map<VentaMedicamento>(ventaMedicamentoDto);
        this.unitofwork.VentaMedicamentos.Add(ventaMedicamento);
        await unitofwork.SaveAsync();
        if (ventaMedicamento == null)
        {
            return BadRequest();
        }
        ventaMedicamentoDto.Id = ventaMedicamento.Id;
        return CreatedAtAction(nameof(Post), new { id = ventaMedicamentoDto.Id }, ventaMedicamentoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<VentaMedicamentoDto>> Put(int id, [FromBody] VentaMedicamentoDto ventaMedicamentoDto)
    {
        if (ventaMedicamentoDto == null)
        {
            return NotFound();
        }
        var ventaMedicamento = this.mapper.Map<VentaMedicamento>(ventaMedicamentoDto);
        unitofwork.VentaMedicamentos.Update(ventaMedicamento);
        await unitofwork.SaveAsync();
        return ventaMedicamentoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var ventaMedicamento = await unitofwork.VentaMedicamentos.GetByIdAsync(id);
        if (ventaMedicamento == null)
        {
            return NotFound();
        }
        unitofwork.VentaMedicamentos.Remove(ventaMedicamento);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    [HttpGet("movimientoVenta")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> movimientoVenta()
    {
        var entidad = await unitofwork.VentaMedicamentos.movimientoVenta();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }
        
    }
