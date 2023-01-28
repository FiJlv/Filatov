using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }
        public string MovieName { get; set; }
        public int Duration { get; set; }
        public MovieSession MovieSession { get; set; }
    }
}
