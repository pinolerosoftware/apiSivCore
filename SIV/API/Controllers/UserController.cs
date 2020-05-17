using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Dto;
using Services.Interface;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService serviceUser;

        public UserController(IUserService userService)
        {
            serviceUser = userService;
        }

        [HttpPost, Route("[action]")]
        public IActionResult Create(UserDtoInput userBM)
        {
            var result = serviceUser.Create(userBM);

            return Ok(result);
        }
    }
}