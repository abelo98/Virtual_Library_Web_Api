using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_Layer.Models
{
    public class AuthorDetailsServiceModel
    {
        public string Name { get; set; }
        public string Nationality { get; set; }
        public DateTime BirthDate { get; set; }
        public int Subscribers { get; set; }
        public ICollection<BookServiceModel> Books { get; set; }
    }
}
