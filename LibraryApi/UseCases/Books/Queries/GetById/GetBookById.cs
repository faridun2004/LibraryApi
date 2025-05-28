using LibraryApi.DTOs;
using MediatR;

namespace LibraryApi.UseCases.Books.Queries.GetById
{
    public class GetBookById : IRequest<List<BookDto>>
    {
        public Guid BookId { get; set; }
        public GetBookById(Guid bookId)
        {
            BookId = bookId;
        }
    }
}
