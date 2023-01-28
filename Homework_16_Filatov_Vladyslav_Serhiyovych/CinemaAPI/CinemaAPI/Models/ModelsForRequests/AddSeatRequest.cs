namespace CinemaAPI.Models.ModelsForRequests
{
    public class AddSeatRequest
    {
        public int Row { get; set; }
        public int Number { get; set; }
        public bool IsAvailable { get; set; }
        public Guid HallId { get; set; }
    }
}
