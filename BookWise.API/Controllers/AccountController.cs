using BookWise.Application.Models.InputModels.Account;
using BookWise.Application.Services.Account;
using Microsoft.AspNetCore.Mvc;

namespace BookWise.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromServices] ILoginService service, [FromBody] LoginInputModel model)
    {
        var result = await service.Login(model);
        return Ok(result);
    }
}
