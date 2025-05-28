using LibraryApi.UseCases.Books.Commands.CreateBook;
using LibraryApi.UseCases.Books.Queries.GetAll;
using LibraryApi.UseCases.Books.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController: ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookCommand command)
        {
            var book=await _mediator.Send(command);
            return Ok(book);
        }
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _mediator.Send(new GetBooksQuery());
            return Ok(books);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = await _mediator.Send(new GetBookById(id));
            return Ok(book);
        }
    }
}
