using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeClub.Attribute;
using CoffeeClub.Domain;
using CoffeeClub.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeClub.Controllers
{
    [Route("api/coffee")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly CoffeeClubContext context;

        public CoffeeController(CoffeeClubContext context)
        {
            this.context = context;
        }

        // GET: api/coffee
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(context.Coffee.ToList());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/coffee
        [HttpPost]
        public IActionResult CreateCoffee([FromBody] Coffee coffee)
        {
            try
            {
                if (Validation.ValidateEntity(coffee))
                {
                    context.Coffee.Add(coffee);
                    context.SaveChanges();

                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/coffee/5
        [Cookie]
        [Session]
        [HttpDelete("{name}")]
        public IActionResult DeleteCoffee(string name)
        {
            try
            {
                var coffee = context.Coffee.FirstOrDefault(c => c.Name == name);
                if (coffee == null)
                {
                    return NotFound();
                }

                context.Coffee.Remove(coffee);
                context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
