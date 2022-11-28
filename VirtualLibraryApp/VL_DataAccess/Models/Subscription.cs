using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VL_DataAccess.Models
{
    public class Subscription:BaseEntity
    {
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }

        public Guid LibraryUserId { get; set; }
        public LibraryUser LibraryUser { get; set; }

    }
}
