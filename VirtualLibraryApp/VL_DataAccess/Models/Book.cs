using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL_DataAccess.Models
{
    public class Book: BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string EditorialName { get; set; }
        public int Pages { get; set; }
        public DateTime PublishingDate { get; set; }
        public string DowloadUrl { get; set; }
        public int ISBN { get; set; } /*check that int suits the number*/
        public int Rate{ get; set; }

    }
}
