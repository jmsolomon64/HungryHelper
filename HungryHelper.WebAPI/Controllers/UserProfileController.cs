using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HungryHelper.Services.UserProfile;
using HungryHelper.Models.UserProfile;

namespace HungryHelper.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _service;
        public UserProfileController(IUserProfileService service)
        {
            _service = service;
        }

        [HttpPost("UserProfileRegister")]
        // Testing post using FromForm instead of FromBody (which was in the initial EN modules)
        // public async Task<IActionResult> RegisterUserProfile([FromBody] UserProfileRegister model)
        public async Task<IActionResult> RegisterUserProfile([FromForm] UserProfileRegister model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = await _service.RegisterUserProfileAsync(model);
            if (registerResult)
            {
                return Ok("User Profile was registered.");
            }

            return BadRequest("User could not be registered");
        }

    }
}
