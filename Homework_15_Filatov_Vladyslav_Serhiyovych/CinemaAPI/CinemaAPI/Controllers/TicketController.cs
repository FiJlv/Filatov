using CinemaAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : Controller
    {
        private readonly CinemaAPIDbContext context;
        public TicketController(CinemaAPIDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            return Ok(await context.Tickets.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetTicket([FromRoute] Guid id)
        {
            var ticket = await context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> AddTicket(Ticket addTicketRequest)
        {
            var ticket = new Ticket()
            {
                Id = Guid.NewGuid(),
                BuyerId = addTicketRequest.BuyerId,
                MovieSessionId= addTicketRequest.MovieSessionId,
                SeatId = addTicketRequest.SeatId,
                DateOfPurchase = addTicketRequest.DateOfPurchase,
                Price = addTicketRequest.Price,
            };

            await context.Tickets.AddAsync(ticket);
            await context.SaveChangesAsync();

            return Ok(ticket);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateTicket([FromRoute] Guid id, Ticket updateTicketRequest)
        {
            var ticket = await context.Tickets.FindAsync(id);

            if (ticket != null)
            {
                ticket.BuyerId = updateTicketRequest.BuyerId;
                ticket.MovieSessionId = updateTicketRequest.MovieSessionId;
                ticket.SeatId = updateTicketRequest.SeatId;
                ticket.DateOfPurchase = updateTicketRequest.DateOfPurchase;
                ticket.Price = updateTicketRequest.Price;

                await context.SaveChangesAsync();

                return Ok(ticket);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteTicket([FromRoute] Guid id)
        {
            var ticket = await context.Tickets.FindAsync(id);

            if (ticket != null)
            {
                context.Remove(ticket);
                await context.SaveChangesAsync();
                return Ok(ticket);
            }

            return NotFound();
        }
    }
}
