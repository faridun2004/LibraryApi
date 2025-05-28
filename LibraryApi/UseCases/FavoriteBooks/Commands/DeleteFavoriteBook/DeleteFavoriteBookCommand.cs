using MediatR;

namespace LibraryApi.UseCases.FavoriteBooks.Commands.DeleteFavoriteBook
{
    public class DeleteFavoriteBookCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
