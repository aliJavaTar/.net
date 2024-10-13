using ali.controller.dto;
using ali.service;
using Microsoft.AspNetCore.Mvc;

namespace ali.controller;

[ApiController]
[Route("api/users")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateUser([FromBody] UserDTO dto)
    {
        userService.Create(dto);
        return Ok();
    }
}