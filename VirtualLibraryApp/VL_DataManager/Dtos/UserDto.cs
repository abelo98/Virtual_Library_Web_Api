using System.ComponentModel.DataAnnotations;

namespace VL_DataManager.Dtos
{
    public class UserDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ProfilePictureUrl { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
