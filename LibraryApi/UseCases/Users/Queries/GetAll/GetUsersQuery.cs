using LibraryApi.DTOs;
using MediatR;

namespace LibraryApi.UseCases.Users.Queries.GetAll
{
    public record GetUsersQuery():IRequest<List<UserDto>>;
    
}
