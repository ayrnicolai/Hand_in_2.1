using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hand_in_2._1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hand_in_2._1.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class AdultController : ControllerBase
    {
        private IAdultData adultService;

        public AdultController(IAdultData adultService)
        {
            this.adultService = adultService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Person>>>
            GetAdults([FromQuery] int? userId)
        {
            try
            {
                IList<Person> adults = await adultService.getAdult();
                if (userId != null)
                {
                    adults = adults.Where(adult => adult.Id == userId).ToList();
                }

                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> RemoveAdult([FromRoute] int id)
        {
            try
            {
                await adultService.RemoveAdult(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        } 
        [HttpPost]
        public async Task<ActionResult<Person>> AddTodo([FromBody] Person adult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Person added = await adultService.AddAdult(adult);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}