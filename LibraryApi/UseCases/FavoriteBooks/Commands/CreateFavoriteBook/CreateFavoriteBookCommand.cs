using MediatR;

namespace LibraryApi.UseCases.FavoriteBooks.Commands.CreateFavoriteBook
{
    public class CreateFavoriteBookCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
