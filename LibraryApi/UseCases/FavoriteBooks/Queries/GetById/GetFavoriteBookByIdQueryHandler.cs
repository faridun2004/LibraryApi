using LibraryApi.Data;
using LibraryApi.DTOs;
using LibraryApi.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.UseCases.FavoriteBooks.Queries.GetById
{
    public class GetFavoriteBookByIdQueryHandler : IRequestHandler<GetFavoriteBookByIdQuery, FavoriteBookDto>
    {
        private readonly LibraryDbContext _context;

        public GetFavoriteBookByIdQueryHandler(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<FavoriteBookDto?> Handle(GetFavoriteBookByIdQuery request, CancellationToken cancellationToken)
        {
            var favoriteBook = await _context.FavoriteBooks
                .AsNoTracking()
                .Include(fb => fb.Book)
                .Include(fb => fb.User)
                .FirstOrDefaultAsync(fb => fb.Id == request.Id, cancellationToken);

            if (favoriteBook == null)
                return null;

            return new FavoriteBookDto
            {
                Id = favoriteBook.Id,
                BookId = favoriteBook.BookId,
                BookTitle = favoriteBook.Book?.Title ?? string.Empty,
                BookAuthor = favoriteBook.Book?.Author ?? string.Empty,
                BookDescription = favoriteBook.Book?.Description ?? string.Empty,
                BookPrice = favoriteBook.Book?.Price ?? 0
            };
        }
    }
}
