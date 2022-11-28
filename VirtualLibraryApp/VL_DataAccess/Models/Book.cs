using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL_DataAccess.Models
{
    public class Book : BaseEntity
    {

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string AuthorName { get; set; }

        [Required]
        [MaxLength(100)]
        public string EditorialName { get; set; }

        [Required]
        public int Pages { get; set; }

        [Required]
        [Column(TypeName = ("date"))]
        public DateTime PublishingDate { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string DowloadUrl { get; set; }

        [Required]
        [MaxLength(13)]
        [Column(TypeName = "varchar(13)")]
        public string ISBN { get; set; }

        [Required]
        [Range(0, 5)]
        public int Rate { get; set; }

        #region Navigation props
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }

        public ICollection<BookReview> BookReviews { get; set; }
        #endregion

    }
}
