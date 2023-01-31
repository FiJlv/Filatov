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

        [HttpGet("top-three-buyers-who-spent-most-money")]
        public async Task<IActionResult> TopThreeBuyersWhoSpentMostMoney()
        {
            var topThreeBuyersWhoSpentMostMoney = from b in context.Buyers
                                                  join ms in context.MovieSessions on b.Id equals ms.BuyerId
                                                  join t in context.Tickets on b.Id equals t.BuyerId
                                                  where ms.SessionDate == ms.SessionDate.AddDays(7) 
                                                  group b.LastName by t.Price;

            return Ok(topThreeBuyersWhoSpentMostMoney);
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
                LastName= addBuyerRequest.LastName
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
