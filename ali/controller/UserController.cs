using ali.controller.dto;
using ali.service;
using Microsoft.AspNetCore.Mvc;

namespace ali.controller;

[ApiController]
[Route("api/users")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserDTO dto)
    {
        var userDto = await userService.Create(dto);
        return Ok(userDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser([FromRoute] int id , [FromBody] UserDTO dto)
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
