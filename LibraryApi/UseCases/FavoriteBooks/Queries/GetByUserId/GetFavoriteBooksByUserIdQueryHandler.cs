using LibraryApi.Data;
using LibraryApi.DTOs;
using LibraryApi.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.UseCases.FavoriteBooks.Queries.GetByUserId
{
    public class GetFavoriteBooksByUserIdQueryHandler : IRequestHandler<GetFavoriteBooksByUserIdQuery, List<FavoriteBookDto>>
    {
        private readonly LibraryDbContext _context;

        public GetFavoriteBooksByUserIdQueryHandler(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<List<FavoriteBookDto>> Handle(GetFavoriteBooksByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.FavoriteBooks
                .AsNoTracking()
                .Include(fb => fb.Book)
                .Where(fb => fb.UserId == request.UserId)
                .Select(fb => new FavoriteBookDto
                {
                    Id = fb.Id,
                    BookId = fb.BookId,
                    BookTitle = fb.Book.Title,
                    BookAuthor = fb.Book.Author,
                    BookDescription = fb.Book.Description,
                    BookPrice = fb.Book.Price
                })
                .ToListAsync(cancellationToken);
        }
    }
}
