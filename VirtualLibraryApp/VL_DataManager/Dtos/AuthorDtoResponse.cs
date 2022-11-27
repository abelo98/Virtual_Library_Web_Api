using System.ComponentModel.DataAnnotations;

namespace VL_DataManager.Dtos
{
    public class AuthorDtoResponse
    {
        public Guid Id { get; set; }


        public string Name { get; set; }

        public string Nationality { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
