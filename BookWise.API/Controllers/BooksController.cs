using BookWise.Application.Models.InputModels.Book;
using BookWise.Application.Services.Book;
using BookWise.Infra.GoogleBook;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookWise.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BooksController : ControllerBase
{
    [HttpGet("google-api")]
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

    [HttpGet]
    public async Task<IActionResult> GetAll([FromServices] IBookService service)
    {
        var result = await service.GetAll();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromServices] IBookService service, Guid id)
    {
        var result = await service.GetById(id);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove([FromServices] IBookService service, Guid id)
    {
        await service.Remove(id);

        return Ok();
    }

    [HttpGet("read-year")]
    public async Task<IActionResult> GetByYear([FromServices] IBookService service, int year)
    {
        var result = await service.GetReadBooksByYear(year);

        return Ok(result);
    }
}
