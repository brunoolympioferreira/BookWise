using BookWise.Application.Models.InputModels.User;
using BookWise.Application.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace BookWise.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromServices] IUserService service, [FromBody] CreateUserInputModel model)
    {
        var result = await service.Create(model);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById([FromServices] IUserService service, Guid id)
    {
        var result = await service.GetById(id);

        return Ok(result);
    }
}
