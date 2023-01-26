using Task.Models;

namespace CinemaAPI.Models.ModelsForRequests
{
    public class AddTicketRequest
    {
        public DateTime DateOfPurchase { get; set; }
        public decimal Price { get; set; }
        public Guid BuyerId { get; set; }
        public Guid MovieSessionId { get; set; }
        public Guid SeatId { get; set; }
    }
}
