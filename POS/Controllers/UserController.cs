using Application.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace POS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;


        public UserController(ILogger<UserController> logger , IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (result != null)
            {
                return CreatedAtAction(nameof(AddUserCommand), new { id = command.Id }, command);
            }

            return BadRequest("Unable to add user.");
        }



        [HttpPost]
        public async Task<IActionResult> GetUserById([FromBody] GetUserByIdQuery command)
        {
            var result = await _mediator.Send(command);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Unable to add user.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers(GetAllUsersQuery command)
        {
            var result = await _mediator.Send(command);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Unable to Get users.");
        }

    }
}
