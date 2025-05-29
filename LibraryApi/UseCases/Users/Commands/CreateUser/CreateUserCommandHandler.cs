using LibraryApi.Data;
using LibraryApi.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.UseCases.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly LibraryDbContext _context;
        public CreateUserCommandHandler(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            if(await _context.Users.AnyAsync(u => u.Username==command.Username, cancellationToken))
                throw new ArgumentException("Username is already taken.");
            
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Username = command.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(command.Password),
                Role = "user",
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            return user.Id;
        }
    }
}
