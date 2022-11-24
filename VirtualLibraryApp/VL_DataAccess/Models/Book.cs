using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL_DataAccess.Models
{
    public class Book: BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Author { get; set; }

        [Required]
        [MaxLength(100)]
        public string EditorialName { get; set; }

        [Required]
        public int Pages { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PublishingDate { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string DowloadUrl { get; set; }

        [Required]
        public int ISBN { get; set; } /*check that int suits the number*/

        [Required]
        [Range(0,5)]
        public int Rate{ get; set; }

    }
}
