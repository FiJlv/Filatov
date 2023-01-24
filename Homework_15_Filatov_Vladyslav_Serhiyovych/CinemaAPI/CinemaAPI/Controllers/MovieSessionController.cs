using CinemaAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieSessionController: Controller
    {
        private readonly CinemaAPIDbContext context;
        public MovieSessionController(CinemaAPIDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovieSessions()
        {
            return Ok(await context.MovieSessions.ToListAsync());

        }  

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetMovieSession([FromRoute] Guid id)
        {
            var movieSession = await context.MovieSessions.FindAsync(id);

            if (movieSession == null)
            {
                return NotFound();
            }

            return Ok(movieSession);
        }

        //[HttpGet]
        //public IActionResult MovieSessionsForTheCurrentWeek()
        //{
        //    var movieSessionsForTheCurrentWeek = from ms in context.MovieSessions
        //                                         join m in context.Movies on ms.Id equals m.Id
        //                                         where ms.SessionDate = DateTime.Now.AddDays(7)
        //                                         select new { Name = m.MovieName, Date = ms.SessionDate };

        //    return Ok(movieSessionsForTheCurrentWeek);
        //} 

        [HttpPost]
        public async Task<IActionResult> AddMovieSession(MovieSession addMovieSessionRequest)
        {
            var movieSession = new MovieSession()
            {
                Id = Guid.NewGuid(),
                SessionDate = addMovieSessionRequest.SessionDate,
                HallId = addMovieSessionRequest.HallId,
                MovieId = addMovieSessionRequest.MovieId

            };

            await context.MovieSessions.AddAsync(movieSession);
            await context.SaveChangesAsync();

            return Ok(movieSession);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateMovieSession([FromRoute] Guid id, MovieSession updateMovieSessionRequest)
        {
            var movieSession = await context.MovieSessions.FindAsync(id);

            if (movieSession != null)
            {
                movieSession.SessionDate = updateMovieSessionRequest.SessionDate;
                movieSession.HallId = updateMovieSessionRequest.HallId;
                movieSession.MovieId = updateMovieSessionRequest.MovieId;

                await context.SaveChangesAsync();

                return Ok(movieSession);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteMovieSession([FromRoute] Guid id)
        {
            var movieSession = await context.MovieSessions.FindAsync(id);

            if (movieSession != null)
            {
                context.Remove(movieSession);
                await context.SaveChangesAsync();
                return Ok(movieSession);
            }

            return NotFound();
        }
    }
}
