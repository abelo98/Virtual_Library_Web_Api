using System.ComponentModel.DataAnnotations;

namespace VL_DataManager.Dtos
{
    public class AuthorDtoRequest
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nationality { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
    }
}
