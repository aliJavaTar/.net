using ali.controller.dto;
using ali.service;
using Microsoft.AspNetCore.Mvc;

namespace ali.controller;

[ApiController]
[Route("api/users")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost("/register")]
    public async Task<IActionResult> CreateUser([FromBody] UserDTO dto)
    {
        var userDto = await userService.Register(dto);
        return Ok(userDto);
    }

    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] UserDTO dto)
    {
        UserResponse response = await userService.Login(dto.Username, dto.Password);
        return Ok(response);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UserDTO dto)
    {
        var userDto = await userService.Update(id, dto);
        return Ok(userDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] int userId)
    {
        var userDto = await userService.GetById(userId);
        return Ok(userDto);
    }

    [HttpGet("/all")]
    public async Task<IActionResult> GetAllUsers()
    {
        var list = await userService.GetAllUsers();
        return Ok(list);
    }
}