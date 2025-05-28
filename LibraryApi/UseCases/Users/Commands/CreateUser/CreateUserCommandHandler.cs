using LibraryApi.Data;
using LibraryApi.Entities;
using MediatR;

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
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            return user.Id;
        }
    }
}
