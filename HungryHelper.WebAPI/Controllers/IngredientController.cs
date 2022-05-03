using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HungryHelper.Services.Ingredient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HungryHelper.WebAPI.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientServices _service; //creates instance of Iservice
        public IngredientController(IIngredientServices service) //dependency injection
        {
            _service = service;
        }
    }
}
