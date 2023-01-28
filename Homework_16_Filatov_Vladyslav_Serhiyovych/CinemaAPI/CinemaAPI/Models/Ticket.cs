using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public decimal Price { get; set; }
        public Guid BuyerId { get; set; }   
        public Buyer Buyer { get; set; }
        public Guid MovieSessionId { get; set; }
        public MovieSession MovieSession { get; set; }
        public Guid SeatId { get; set; }     
    }
}
