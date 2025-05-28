using LibraryApi.DTOs;
using LibraryApi.Entities;
using MediatR;

namespace LibraryApi.UseCases.FavoriteBooks.Queries.GetById
{
    public class GetFavoriteBookByIdQuery : IRequest<FavoriteBookDto>
    {
        public Guid Id { get; set; }
    }
}
