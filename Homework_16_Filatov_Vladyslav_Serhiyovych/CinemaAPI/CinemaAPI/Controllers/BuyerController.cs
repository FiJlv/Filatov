using CinemaAPI.Data;
using CinemaAPI.Models.ModelsForRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace CinemaAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BuyerController : Controller
    {
        private readonly CinemaAPIDbContext context;
        public BuyerController(CinemaAPIDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBuyers()
        {
            return Ok(await context.Buyers.ToListAsync());

        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetBuyer([FromRoute] Guid id)
        {
            var buyer = await context.Buyers.FindAsync(id);

            if (buyer == null)
            {
                return NotFound();
            }

            return Ok(buyer);
        }

        [HttpPost]
        public async Task<IActionResult> AddBuyer(AddBuyerRequest addBuyerRequest)
        {
            var buyer = new Buyer()
            {
                Id = Guid.NewGuid(),
                FirstName= addBuyerRequest.FirstName,
                LastName= addBuyerRequest.LastName,
                Email = addBuyerRequest.Email
            };

            await context.Buyers.AddAsync(buyer);
            await context.SaveChangesAsync();

            return Ok(buyer);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateBuyer([FromRoute] Guid id, Buyer updateBuyerRequest)
        {
            var buyer = await context.Buyers.FindAsync(id);

            if (buyer != null)
            {
                buyer.FirstName = updateBuyerRequest.FirstName;
                buyer.LastName = updateBuyerRequest.LastName;
                buyer.Email = updateBuyerRequest.Email;

                await context.SaveChangesAsync();

                return Ok(buyer);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteBuyer([FromRoute] Guid id)
        {
            var buyer = await context.Buyers.FindAsync(id);

            if (buyer != null)
            {
                context.Remove(buyer);
                await context.SaveChangesAsync();
                return Ok(buyer);
            }

            return NotFound();
        }
    }
}
