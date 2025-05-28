using LibraryApi.UseCases.Users.Commands.CreateUser;
using LibraryApi.UseCases.Users.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _mediator.Send(new GetUsersQuery());
            return Ok(users);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var user=await _mediator.Send(command);
            return Ok(user);
        }
    }
}
