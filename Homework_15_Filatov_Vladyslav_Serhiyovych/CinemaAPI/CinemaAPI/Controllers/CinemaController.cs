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
    public class CinemaController : Controller  
    {
        private readonly CinemaAPIDbContext context;
        public CinemaController(CinemaAPIDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCinemas()
        {
            return Ok(await context.Cinemas.ToListAsync());
            
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCinema([FromRoute] Guid id)
        {
            var cinema = await context.Cinemas.FindAsync(id);  

            if(cinema == null)
            {
                return NotFound();
            }

            return Ok(cinema);
        }

        [HttpPost]
        public async Task<IActionResult> AddCinema(AddCinemaRequest addCinemaRequest)
        {
            var cinema = new Cinema()
            {
                Id = Guid.NewGuid(),    
                Address = addCinemaRequest.Address,
                CinemaName = addCinemaRequest.CinemaName,
            };

            await context.Cinemas.AddAsync(cinema);
            await context.SaveChangesAsync();

            return Ok(cinema);
        }

        [HttpPut ]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCinema([FromRoute] Guid id, Cinema updateCinemaRequest)
        {
            var cinema = await context.Cinemas.FindAsync(id);

            if(cinema != null)
            {
                cinema.Address = updateCinemaRequest.Address;
                cinema.CinemaName = updateCinemaRequest.CinemaName;

                await context.SaveChangesAsync();

                return Ok(cinema);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCinema([FromRoute] Guid id)
        {
            var cinema = await context.Cinemas.FindAsync(id);

            if(cinema != null) 
            {
                context.Remove(cinema);
                await context.SaveChangesAsync();
                return Ok(cinema);
            }

            return NotFound();
        }
    }
}
