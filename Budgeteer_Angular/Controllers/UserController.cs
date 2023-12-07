using Budgeteer_Angular.Models;
using Budgeteer_Angular.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Budgeteer_Angular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.GetAllEntities().ToArray();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] User userData)
        {
            try
            {
                await _userService.AddUserAsync(userData);
                return Ok(userData);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, $"Unable to create user. {ex.Message}");
            }
        }
    }
}
