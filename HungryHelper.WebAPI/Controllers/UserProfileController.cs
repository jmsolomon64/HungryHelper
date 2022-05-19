using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HungryHelper.Services.UserProfile;
using HungryHelper.Models.UserProfile;
using Microsoft.AspNetCore.Authorization;
using HungryHelper.Services.Token;
using HungryHelper.Models.Token;
using HungryHelper.Services.SeedData;

namespace HungryHelper.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;
        private readonly ITokenService _tokenService;
        private readonly ISeedDataService _seedService;
        public UserProfileController(IUserProfileService userProfileService, ITokenService tokenService, ISeedDataService seedService)
        {
            _userProfileService = userProfileService;
            _tokenService = tokenService;
            _seedService = seedService;
        }

        [HttpPost("UserProfileRegister")]
        // Testing post using FromForm instead of FromBody (which was in the initial EN modules)
        // public async Task<IActionResult> RegisterUserProfile([FromBody] UserProfileRegister model)
        public async Task<IActionResult> RegisterUserProfile([FromBody] UserProfileRegister model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = await _userProfileService.RegisterUserProfileAsync(model);
            if (registerResult)
            {
                return Ok("User Profile was registered.");
            }

            return BadRequest("User could not be registered");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ViewAllUserProfiles()
        {
            await _seedService.SeedUserProfilesAsync();
            List<UserProfileDetail> userProfiles = _userProfileService.GetAllUserProfiles();
            if (userProfiles is null)
            {
                return NotFound();
            }

            return Ok(userProfiles);
        }

        [Authorize]
        [HttpGet("{userProfileId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int userProfileId)
        {
            await _seedService.SeedUserProfilesAsync();
            var userProfileDetail = await _userProfileService.GetUserProfileByIdAsync(userProfileId);

            if (userProfileDetail is null)
            {
                return NotFound();
            }

            return Ok(userProfileDetail);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserProfileById([FromBody] UserProfileUpdate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _userProfileService.UpdateUserProfileAsync(request)
                ? Ok("User Profile updated successfully.")
                : BadRequest("Note could not be updated.");
        }

        [HttpDelete("{userProfileId:int}")]
        public async Task<IActionResult> DeleteUserProfileById([FromRoute] int userProfileId)
        {
            return await _userProfileService.DeleteUserProfileAsync(userProfileId)
                ? Ok($"User Profile {userProfileId} was deleted successfully.")
                : BadRequest($"User Profile {userProfileId} could not be deleted.");
        }

        [HttpPost("~/api/Token")]
        public async Task<IActionResult> Token([FromBody] TokenRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var tokenResponse = await _tokenService.GetTokenAsync(request);
            if (tokenResponse is null)
                return BadRequest("Invalid username or password");

            return Ok(tokenResponse);
        }
    }
}
