using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL_DataAccess.Models;

namespace Services_Layer.Models
{
    public class GetAllReviewsFilter
    {
        public RateReview? ReviewType { get; set; }
        public bool? Sort { get; set; }

    }
}
