using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models
{
    public class Seat
    {
        [Key]
        public Guid Id { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }
        public bool IsAvailable { get; set; }
        public Guid HallId { get;set; }
        public Hall Hall { get; set; }

    }
}
