using Club_in_API.UserType.Application;
using Club_in_API.UserType.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Club_in_API.UserType.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/getUser/{id}")]
        public async Task<ActionResult<User>> get(int id)
        {
            var user = await _mediator.Send(new GetUser.Execute { UserId = id });
            return user == null ? NotFound() : Ok(user);
        }

    }
}
