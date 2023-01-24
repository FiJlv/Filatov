using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models
{
    public class MovieSession
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime SessionDate { get; set; }         
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public Guid HallId { get; set; }
        public Hall Hall { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
