using LibraryApi.Data;
using LibraryApi.Entities;
using MediatR;

namespace LibraryApi.UseCases.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler: IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly LibraryDbContext _context;
        public CreateBookCommandHandler(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = command.Title,
                Description = command.Description,
                Author = command.Author,
                Price = command.Price
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync(cancellationToken);
            return book.Id;
        }
    }
}
