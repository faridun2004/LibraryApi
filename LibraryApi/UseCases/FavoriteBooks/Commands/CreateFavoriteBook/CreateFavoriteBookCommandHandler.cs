using LibraryApi.Data;
using LibraryApi.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var userExists = await _context.Users
                .AsNoTracking()
                .AnyAsync(u => u.Id == request.UserId, cancellationToken);

            var bookExists = await _context.Books
                .AsNoTracking()
                .AnyAsync(b => b.Id == request.BookId, cancellationToken);

            if (!userExists || !bookExists)
                throw new InvalidOperationException("Пользователь или книга не найдены.");

            var alreadyFavorite = await _context.FavoriteBooks
                .AsNoTracking()
                .AnyAsync(fb => fb.UserId == request.UserId && fb.BookId == request.BookId, cancellationToken);

            if (alreadyFavorite)
                throw new InvalidOperationException("Книга уже добавлена в избранное.");

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
