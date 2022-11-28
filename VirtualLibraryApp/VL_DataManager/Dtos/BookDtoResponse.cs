using System.ComponentModel.DataAnnotations;

namespace VL_DataManager.Dtos
{
    public class BookDtoResponse
    {
        public string Title { get; set; }

        public string EditorialName { get; set; }

        public int Pages { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        [DataType(DataType.Url)]
        public string DowloadUrl { get; set; }

        public string ISBN { get; set; }
    }
}
