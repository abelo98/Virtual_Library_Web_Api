using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Models
{
    public class GetAllBooksFilter
    {
        public Guid? AuthorId { get; set; }
        public string? EditorialName { get; set; }
        public DateTime? Before { get; set; }
        public DateTime? After { get; set; }
        //public int Offset{ get; set; } = 0;
        //public int Limit { get; set; } = 50;
        public bool? Sort{ get; set; }

    }
}
