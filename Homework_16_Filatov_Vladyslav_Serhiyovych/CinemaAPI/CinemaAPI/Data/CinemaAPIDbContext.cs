using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace CinemaAPI.Data
{
    public class CinemaAPIDbContext: DbContext
    {

        public CinemaAPIDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<MovieSession> MovieSessions { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
