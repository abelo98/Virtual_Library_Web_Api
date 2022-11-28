using VL_DataAccess.Models;

namespace VL_DataManager.Dtos
{
    public class BookReviewDtoResponse
    {
        public string? Opinion { get; set; }
        public RateReview Rate { get; set; }
    }
}
