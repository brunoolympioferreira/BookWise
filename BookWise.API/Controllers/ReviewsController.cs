using BookWise.Application.Models.InputModels.Review;
using BookWise.Application.Services.Review;
using Microsoft.AspNetCore.Mvc;

namespace BookWise.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReviewsController : ControllerBase
{
    [HttpGet("{bookId}")]
    public async Task<IActionResult> GetByBookId([FromServices] IReviewService service, Guid bookId)
    {
        var result = await service.GetByBookId(bookId);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromServices] IReviewService service, CreateReviewInputModel model)
    {
        var result = await service.Create(model);

        return Ok(result);
    }
}
