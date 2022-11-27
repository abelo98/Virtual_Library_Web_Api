using System.ComponentModel.DataAnnotations;

namespace VL_DataManager.Dtos
{
    public class LibraryUserDtoResponse
    {
        public Guid Id { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.ImageUrl)]
        public string? ProfilePictureUrl { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegisterDate { get; set; }

        public string Name { get; set; }
    }
}
