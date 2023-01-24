using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models
{
    public class Cinema
    {
        [Key]
        public Guid Id { get; set; }
        public string CinemaName { get; set; }
        public string Address { get; set; }
        public List<Hall> Halls { get; set; } = new List<Hall>();
    }
}
