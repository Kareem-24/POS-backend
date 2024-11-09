using AutoMapper;
using Core.Entities;
using Core.Models;
using Core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace POS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IAuthinticationManager _authManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;


        public AuthController(IMapper mapper, UserManager<User> userManager,
           IAuthinticationManager authManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _authManager = authManager;

        }


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLogin)
        {
            if (userLogin != null)
            {
                if (!await _authManager.ValidateUSer(userLogin))
                {
                    return Unauthorized();
                }
                return Ok(new { Token = await _authManager.CreateToken() });
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDTO userForRegistration)
        {
            if (userForRegistration != null)
            {
                userForRegistration.Id = Guid.NewGuid();

                var user = _mapper.Map<User>(userForRegistration);
                var result = await _userManager.CreateAsync(user, userForRegistration.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.TryAddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
            }
            return Ok();
        }
    }
}
