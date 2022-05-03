using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HungryHelper.Services.UserProfile;

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
    }
}
