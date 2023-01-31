using CinemaAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.Models;
using CinemaAPI.Models.ModelsForRequests;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly CinemaAPIDbContext context;
        public MovieController(CinemaAPIDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            return Ok(await context.Movies.ToListAsync());

        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetMovie([FromRoute] Guid id)
        {
            var movie = await context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpGet("all-the-money-earned-by-each-movie")]
        public IActionResult AllTheMoneyEarnedByEachMovie()
        {
            var allTheMoneyEarnedByEachMovie = from t in context.Tickets
                                               join ms in context.MovieSessions on t.MovieSessionId equals ms.Id
                                               orderby t.Price descending
                                               group t by ms.MovieId;

            return Ok(allTheMoneyEarnedByEachMovie);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(AddMovieRequest addMovieRequest)
        {
            var movie = new Movie()
            {
                Id = Guid.NewGuid(),
                MovieName = addMovieRequest.MovieName,
                Duration = addMovieRequest.Duration    
            };

            await context.Movies.AddAsync(movie);
            await context.SaveChangesAsync();

            return Ok(movie);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateMovie([FromRoute] Guid id, Movie updateMovieRequest)
        {
            var movie = await context.Movies.FindAsync(id);

            if (movie != null)
            {
                movie.MovieName = updateMovieRequest.MovieName;
                movie.Duration = updateMovieRequest.Duration;

                await context.SaveChangesAsync();

                return Ok(movie);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteMovie([FromRoute] Guid id)
        {
            var movie = await context.Movies.FindAsync(id);

            if (movie != null)
            {
                context.Remove(movie);
                await context.SaveChangesAsync();
                return Ok(movie);
            }

            return NotFound();
        }
    }
}
