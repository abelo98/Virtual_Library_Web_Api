using System.ComponentModel.DataAnnotations;

namespace VL_DataManager.Dtos
{
    public class BookDtoResponse
    {
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string EditorialName { get; set; }
        public string ISBN { get; set; }
    }
}
