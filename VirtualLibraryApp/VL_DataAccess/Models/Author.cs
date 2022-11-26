using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL_DataAccess.Models
{
    public class Author : BaseUser
    {
        [Required]
        [MaxLength(50)]
        public string Nationality { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        #region Navigation props
        ICollection<Book> Books { get; set; }
        ICollection<LibraryUser> Users { get; set; }
        #endregion
    }
}
