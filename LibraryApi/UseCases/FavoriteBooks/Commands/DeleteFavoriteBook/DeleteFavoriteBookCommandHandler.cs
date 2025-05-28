using LibraryApi.Data;
using MediatR;

namespace LibraryApi.UseCases.FavoriteBooks.Commands.DeleteFavoriteBook
{
    public class DeleteFavoriteBookCommandHandler : IRequestHandler<DeleteFavoriteBookCommand>
    {
        private readonly LibraryDbContext _context;

        public DeleteFavoriteBookCommandHandler(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteFavoriteBookCommand request, CancellationToken cancellationToken)
        {
            var favoriteBook = await _context.FavoriteBooks.FindAsync(  request.Id , cancellationToken);
            if (favoriteBook != null)
            {
                _context.FavoriteBooks.Remove(favoriteBook);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
