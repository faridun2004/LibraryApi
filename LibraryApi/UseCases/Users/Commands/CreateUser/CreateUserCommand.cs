using MediatR;

namespace LibraryApi.UseCases.Users.Commands.CreateUser
{
    public class CreateUserCommand: IRequest<Guid>
    {
        private string _name;
        public string Name 
        { 
            get=>_name; set=>_name=value.Trim().ToLower(); 
        }
    }
}