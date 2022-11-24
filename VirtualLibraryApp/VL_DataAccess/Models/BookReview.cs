using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL_DataAccess.Models
{
    public class BookReview:BaseEntity
    {
        public Guid UserId { get; set; }
        public DateTime PostedDate { get; set; }
        public string? Opinion { get; set; }
        public RateReview Rate { get; set; }
    }
}
