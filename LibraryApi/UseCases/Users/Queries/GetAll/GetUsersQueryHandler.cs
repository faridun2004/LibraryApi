using LibraryApi.Data;
using LibraryApi.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.UseCases.Users.Queries.GetAll
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
    {
        private readonly LibraryDbContext _context;

        public GetUsersQueryHandler(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users
                .AsNoTracking()
                .Include(u => u.FavoriteBooks)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    FavoriteBooks = u.FavoriteBooks.Select(b => b.Book.Title).ToList()
                })
                .ToListAsync(cancellationToken);
        }
    }
}
