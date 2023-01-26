using Task.Models;

namespace CinemaAPI.Models.ModelsForRequests
{
    public class AddMovieSessionRequest
    {
        public DateTime SessionDate { get; set; }
        public Guid MovieId { get; set; }
        public Guid HallId { get; set; }
    }
}
