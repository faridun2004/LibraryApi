using LibraryApi.Data;
using LibraryApi.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.UseCases.Books.Queries.GetById
{
    public class GetBookByIdHandler: IRequestHandler<GetBookById,List<BookDto>>
    {
        private readonly LibraryDbContext _context;
        public GetBookByIdHandler(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<List<BookDto>> Handle(GetBookById query, CancellationToken cancellationToken)
        {
            return await _context.Books
                .AsNoTracking()
                .Where(b => b.Id == query.BookId)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    Author = b.Author,
                    Price = b.Price,
                })
                .ToListAsync(cancellationToken);
        }
    }
}
