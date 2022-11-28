using VL_DataAccess.Models;

namespace VL_DataManager.Dtos
{
    public class GetAllReviewsQueryFilter
    {
        public RateReview? ReviewType { get; set; }
        public bool? Sort { get; set; }
    }
}
