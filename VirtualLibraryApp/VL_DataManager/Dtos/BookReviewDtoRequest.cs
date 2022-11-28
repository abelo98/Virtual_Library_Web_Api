using System.ComponentModel.DataAnnotations;
using VL_DataAccess.Models;

namespace VL_DataManager.Dtos
{
    public class BookReviewDtoRequest
    {

        [MaxLength(500)]
        public string? Opinion { get; set; }

        public RateReview Rate { get; set; }
    }
}
