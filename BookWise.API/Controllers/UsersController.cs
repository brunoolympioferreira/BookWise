using BookWise.Application.Models.InputModels;
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
}
