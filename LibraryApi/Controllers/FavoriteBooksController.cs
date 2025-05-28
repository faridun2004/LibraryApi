using LibraryApi.Entities;
using LibraryApi.UseCases.FavoriteBooks.Commands.CreateFavoriteBook;
using LibraryApi.UseCases.FavoriteBooks.Commands.DeleteFavoriteBook;
using LibraryApi.UseCases.FavoriteBooks.Queries.GetById;
using LibraryApi.UseCases.FavoriteBooks.Queries.GetByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteBooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FavoriteBooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateFavoriteBookCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteFavoriteBookCommand { Id = id });
            return NoContent();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FavoriteBook>> GetById(Guid id)
        {
            var favoriteBook = await _mediator.Send(new GetFavoriteBookByIdQuery { Id = id });
            if (favoriteBook == null)
                return NotFound();
            return Ok(favoriteBook);
        }

        [HttpGet("user/{userId:guid}")]
        public async Task<ActionResult<IEnumerable<FavoriteBook>>> GetByUserId(Guid userId)
        {
            var favoriteBooks = await _mediator.Send(new GetFavoriteBooksByUserIdQuery { UserId = userId });
            return Ok(favoriteBooks);
        }
    }
}
