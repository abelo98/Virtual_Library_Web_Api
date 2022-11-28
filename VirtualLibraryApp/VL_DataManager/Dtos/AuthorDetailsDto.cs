namespace VL_DataManager.Dtos
{
    public class AuthorDetailsDto
    {
        public string Name { get; set; }
        public string Nationality { get; set; }
        public DateTime BirthDate { get; set; }
        public int Subscribers { get; set; }
        public ICollection<BookAuthorDetailsDto> Books { get; set; }
    }
}
