using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace WebApi.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("CreateUser")]
    public async Task<ActionResult> CreateUser([FromBody] UserRequest request)
    {
        try
        {
            var result = await _userService.CreateAsync(request.FirstName, request.LastName);
            return Ok(result);
        }
        catch (ApplicationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("DeleteUser")]
    public async Task<ActionResult> DeleteUser([FromQuery] int userId)
    {
        try
        {
            await _userService.DeleteAsync(userId);
            return Ok();
        }
        catch (ApplicationException ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [HttpGet("GetAllUsers")]
    public async Task<ActionResult<IEnumerable<UserEntityDto>>> GetAllUsers()
    {
        try
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
        catch(ApplicationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}