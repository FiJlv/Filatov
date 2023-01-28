using CinemaAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Task.Models;
using CinemaAPI.Models.ModelsForRequests;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HallController : Controller  
    {
        private readonly CinemaAPIDbContext context;
        public HallController(CinemaAPIDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetHalls()
        {
            return Ok(await context.Halls.ToListAsync());
            
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetHall([FromRoute] Guid id)
        {
            var hall = await context.Halls.FindAsync(id);  

            if(hall == null)
            {
                return NotFound();
            }

            return Ok(hall);
        }

        [HttpPost]
        public async Task<IActionResult> AddHall(AddHallRequest addHallRequest)
        {
            var hall = new Hall()
            {
                Id = Guid.NewGuid(),
                Name = addHallRequest.Name,
                CinemaId = addHallRequest.CinemaId

            };

            await context.Halls.AddAsync(hall);
            await context.SaveChangesAsync();

            return Ok(hall);
        }

        [HttpPut ]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateHall([FromRoute] Guid id, Hall updateHallRequest)
        {
            var hall = await context.Halls.FindAsync(id);

            if(hall != null)
            {
                hall.Name = updateHallRequest.Name;

                await context.SaveChangesAsync();

                return Ok(hall);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteHall([FromRoute] Guid id)
        {
            var hall = await context.Halls.FindAsync(id);

            if(hall != null) 
            {
                context.Remove(hall);
                await context.SaveChangesAsync();
                return Ok(hall);
            }

            return NotFound();
        }
    }
}
