using ali.controller.dto;
using ali.service;
using Microsoft.AspNetCore.Mvc;

namespace ali.controller;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] UserDTO dto)
    {
        _userService.crate(dto);
        return Ok();
    }
}