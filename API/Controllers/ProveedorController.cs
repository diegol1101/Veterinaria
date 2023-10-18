



using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    public class ProveedorController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public ProveedorController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<ProveedorDto>>> Get()
    {
        var proveedor = await unitofwork.Proveedores.GetAllAsync();
        return mapper.Map<List<ProveedorDto>>(proveedor);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ProveedorDto>> Get(int id)
    {
        var proveedor = await unitofwork.Proveedores.GetByIdAsync(id);
        if (proveedor == null)
        {
            return NotFound();
        }
        return this.mapper.Map<ProveedorDto>(proveedor);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Proveedor>> Post(ProveedorDto proveedorDto)
    {
        var proveedor = this.mapper.Map<Proveedor>(proveedorDto);
        this.unitofwork.Proveedores.Add(proveedor);
        await unitofwork.SaveAsync();
        if (proveedor == null)
        {
            return BadRequest();
        }
        proveedorDto.Id = proveedor.Id;
        return CreatedAtAction(nameof(Post), new { id = proveedorDto.Id }, proveedorDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ProveedorDto>> Put(int id, [FromBody] ProveedorDto proveedorDto)
    {
        if (proveedorDto == null)
        {
            return NotFound();
        }
        var proveedor = this.mapper.Map<Proveedor>(proveedorDto);
        unitofwork.Proveedores.Update(proveedor);
        await unitofwork.SaveAsync();
        return proveedorDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var proveedor = await unitofwork.Proveedores.GetByIdAsync(id);
        if (proveedor == null)
        {
            return NotFound();
        }
        unitofwork.Proveedores.Remove(proveedor);
        await unitofwork.SaveAsync();
        return NoContent();
    }
    

}
