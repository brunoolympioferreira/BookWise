using BookWise.Infra.GoogleBook;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookWise.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetByParameters([FromServices] IGoogleBookClient client, string? title, string? author)
    {
        var result = await client.GetByParametersAsync(title, author);

        return Ok(result);
    }
}
