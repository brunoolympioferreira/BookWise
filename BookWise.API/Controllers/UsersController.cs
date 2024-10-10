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

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromServices] IUserService service, [FromBody] UpdateUserInputModel model, Guid id)
    {
        await service.Update(model, id);

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById([FromServices] IUserService service, Guid id)
    {
        var result = await service.GetById(id);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromServices] IUserService service)
    {
        var result = await service.GetAll();

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove([FromServices] IUserService service, Guid id)
    {
        await service.Remove(id);

        return Ok();
    }
}
