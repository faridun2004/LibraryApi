using LibraryApi.Data;
using LibraryApi.Entities;
using MediatR;

namespace LibraryApi.UseCases.FavoriteBooks.Commands.CreateFavoriteBook
{
    public class CreateFavoriteBookCommandHandler : IRequestHandler<CreateFavoriteBookCommand, Guid>
    {
        private readonly LibraryDbContext _context;

        public CreateFavoriteBookCommandHandler(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateFavoriteBookCommand request, CancellationToken cancellationToken)
        {
            var favoriteBook = new FavoriteBook
            {
                UserId = request.UserId,
                BookId = request.BookId
            };

            _context.FavoriteBooks.Add(favoriteBook);
            await _context.SaveChangesAsync(cancellationToken);

            return favoriteBook.Id;
        }
    }
}
