



using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    public class UserController : ApiBaseController
{
    private readonly IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public UserController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<UserDto>>> Get()
    {
        var user = await unitofwork.Users.GetAllAsync();
        return mapper.Map<List<UserDto>>(user);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<UserDto>> Get(int id)
    {
        var user = await unitofwork.Users.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return this.mapper.Map<UserDto>(user);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<User>> Post(UserDto userDto)
    {
        var user = this.mapper.Map<User>(userDto);
        this.unitofwork.Users.Add(user);
        await unitofwork.SaveAsync();
        if (user == null)
        {
            return BadRequest();
        }
        userDto.Id = user.Id;
        return CreatedAtAction(nameof(Post), new { id = userDto.Id }, userDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<UserDto>> Put(int id, [FromBody] UserDto userDto)
    {
        if (userDto == null)
        {
            return NotFound();
        }
        var user = this.mapper.Map<User>(userDto);
        unitofwork.Users.Update(user);
        await unitofwork.SaveAsync();
        return userDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var user = await unitofwork.Users.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        unitofwork.Users.Remove(user);
        await unitofwork.SaveAsync();
        return NoContent();
    }
    
        
    }
