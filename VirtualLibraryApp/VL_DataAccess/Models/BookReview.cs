using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL_DataAccess.Models
{
    public class BookReview : BaseEntity
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PostedDate { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "varchar(500)")]
        public string? Opinion { get; set; }

        public RateReview Rate { get; set; }


        #region Navigation props

        public string BookId { get; set; }
        public Book Book { get; set; }

        public Guid LibraryUserId { get; set; }
        public LibraryUser LibraryUser{ get; set; }


        #endregion
    }
}
