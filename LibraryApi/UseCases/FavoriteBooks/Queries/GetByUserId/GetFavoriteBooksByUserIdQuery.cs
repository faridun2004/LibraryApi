using LibraryApi.DTOs;
using LibraryApi.Entities;
using MediatR;

namespace LibraryApi.UseCases.FavoriteBooks.Queries.GetByUserId
{
    public class GetFavoriteBooksByUserIdQuery : IRequest<List<FavoriteBookDto>>
    {
        public Guid UserId { get; set; }
    }
}
