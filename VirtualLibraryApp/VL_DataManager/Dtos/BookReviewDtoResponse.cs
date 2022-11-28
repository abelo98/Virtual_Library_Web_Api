using System.ComponentModel.DataAnnotations;
using VL_DataAccess.Models;

namespace VL_DataManager.Dtos
{
    public class BookReviewDtoResponse
    {
        [DataType(DataType.Date)]
        public DateTime PostedDate { get; set; }
        public string? Opinion { get; set; }
        public RateReview Rate { get; set; }
    }
}
