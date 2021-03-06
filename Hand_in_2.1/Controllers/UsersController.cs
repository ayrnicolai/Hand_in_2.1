using System;
using System.Threading.Tasks;
using Hand_in_2._1.Data;
using Hand_in_2._1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hand_in_2._1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> ValidateUser([FromQuery] string username, [FromQuery] string password)
        {
            Console.WriteLine("Here");
            try
            {
                var user = await userService.ValidateUser(username, password);
                return Ok(user);
            }
            catch (Exception e)
            {                
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}