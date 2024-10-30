using BookWise.Application.Models.InputModels.Book;
using BookWise.Application.Services.Book;
using BookWise.Infra.GoogleBook;
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

    [HttpPost]
    public async Task<IActionResult> Create([FromServices] IBookService service, [FromBody] CreateBookInputModel model)
    {
        var result = await service.Create(model);

        return Ok(result);
    }
}
