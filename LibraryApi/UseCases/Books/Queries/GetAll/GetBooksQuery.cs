using LibraryApi.DTOs;
using MediatR;

namespace LibraryApi.UseCases.Books.Queries.GetAll
{
    public record GetBooksQuery(): IRequest<List<BookDto>>;
    
}
