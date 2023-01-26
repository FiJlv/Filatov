using CinemaAPI.Data;
using CinemaAPI.Models.ModelsForRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeatController : Controller
    {
        private readonly CinemaAPIDbContext context;
        public SeatController(CinemaAPIDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSeats()
        {
            return Ok(await context.Seats.ToListAsync());
        }      

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetSeat([FromRoute] Guid id)
        {
            var seat = await context.Seats.FindAsync(id);

            if (seat == null)
            {
                return NotFound();
            }

            return Ok(seat);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetNotBookedSeats()
        //{
        //    return Ok(await context.Seats
        //        .Where(s => s.IsAvailable == true)
        //        .Select(s => new { Num = s.Number }).ToListAsync());
        //}

        //[HttpGet]
        //public IActionResult SeatsForSpecificShow()
        //{
        //    var seatsForShow = from s in context.Seats
        //                       join t in context.Tickets on s.Id equals t.SeatId
        //                       where s.IsAvailable == true
        //                       select new { Num = s.Number };
        //    return Ok(seatsForShow);
        //}

        [HttpPost]
        public async Task<IActionResult> AddSeat(AddSeatRequest addSeatRequest)
        {
            var seat = new Seat()
            {
                Id = Guid.NewGuid(),
                Row = addSeatRequest.Row,
                Number = addSeatRequest.Number,
                IsAvailable = addSeatRequest.IsAvailable,
                HallId = addSeatRequest.HallId
            };

            await context.Seats.AddAsync(seat);
            await context.SaveChangesAsync();

            return Ok(seat);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateSeat([FromRoute] Guid id, Seat updateSeatRequest)
        {
            var seat = await context.Seats.FindAsync(id);

            if (seat != null)
            {
                seat.Row = updateSeatRequest.Row;
                seat.Number = updateSeatRequest.Number;
                seat.IsAvailable= updateSeatRequest.IsAvailable;
                seat.HallId = updateSeatRequest.HallId;

                await context.SaveChangesAsync();

                return Ok(seat);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteSeat([FromRoute] Guid id)
        {
            var seat = await context.Seats.FindAsync(id);

            if (seat != null)
            {
                context.Remove(seat);
                await context.SaveChangesAsync();
                return Ok(seat);
            }

            return NotFound();
        }
    }
}
