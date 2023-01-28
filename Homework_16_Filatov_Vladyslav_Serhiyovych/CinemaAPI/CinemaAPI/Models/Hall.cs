using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models
{
    public class Hall
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        public MovieSession MovieSession {get;set;}
        public List<Seat> Seats { get; set; }       
    }
}
