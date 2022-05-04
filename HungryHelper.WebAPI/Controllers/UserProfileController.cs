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

        [HttpGet("{userProfileId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int userProfileId)
        {
            var userProfileDetail = await _service.GetUserProfileByIdAsync(userProfileId);

            if (userProfileDetail is null)
            {
                return NotFound();
            }

            return Ok(userProfileDetail);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserProfileById([FromForm] UserProfileUpdate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _service.UpdateUserProfileAsync(request)
                ? Ok("User Profile updated successfully.")
                : BadRequest("Note could not be updated.");
        }

        [HttpDelete("{userProfileId:int}")]
        public async Task<IActionResult> DeleteUserProfileById([FromRoute] int userProfileId)
        {
            return await _service.DeleteUserProfileAsync(userProfileId)
                ? Ok($"User Profile {userProfileId} was deleted successfully.")
                : BadRequest($"User Profile {userProfileId} could not be deleted.");
        }
    }
}
