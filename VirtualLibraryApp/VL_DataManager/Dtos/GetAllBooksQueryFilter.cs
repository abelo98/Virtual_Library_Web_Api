namespace VL_DataManager.Dtos
{
    public class GetAllBooksQueryFilter
    {
        public Guid? AuthorId { get; set; }
        public string? EditorialName { get; set; }
        public DateOnly? Before { get; set; }
        public DateOnly? After { get; set; }
        //public int Offset { get; set; }
        //public int Limit { get; set; } = 50;
        public bool? Sort { get; set; }
    }
}
