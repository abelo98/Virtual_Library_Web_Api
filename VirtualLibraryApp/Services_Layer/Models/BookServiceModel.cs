using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Models
{
    public class BookServiceModel
    {
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string EditorialName { get; set; }
        public string ISBN { get; set; }
    }
}
