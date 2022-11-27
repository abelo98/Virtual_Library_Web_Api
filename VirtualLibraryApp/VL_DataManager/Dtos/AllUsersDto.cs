namespace VL_DataManager.Dtos
{
    public class AllUsersDto
    {
        public int TotalUsers { get { return Users.Count; } set { } }
        public ICollection<LibraryUser> Users { get; set; }
        public int TotalAuthors { get; set; }
    }
}
