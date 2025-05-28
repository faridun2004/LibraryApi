using LibraryApi.Data;
using LibraryApi.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.UseCases.Books.Queries.GetAll
{
    public class GetBooksQueryHandler: IRequestHandler<GetBooksQuery, List<BookDto>>
    {
        private readonly LibraryDbContext _context;
        public GetBooksQueryHandler(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<List<BookDto>> Handle(GetBooksQuery query, CancellationToken cancellationToken)
        {
            return await _context.Books
                .AsNoTracking()
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    Author=b.Author,
                    Price = b.Price,
                }).ToListAsync(cancellationToken);   
        }
    }
}
