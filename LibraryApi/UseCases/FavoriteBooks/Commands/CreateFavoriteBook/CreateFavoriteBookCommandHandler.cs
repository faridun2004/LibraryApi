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

            var data = await (
                from user in _context.Users
                where user.Id == request.UserId
                from book in _context.Books
                where book.Id == request.BookId
                select new
                {
                    UserId = user.Id,
                    BookId = book.Id
                }
            ).FirstOrDefaultAsync(cancellationToken);

            if (data == null)
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
