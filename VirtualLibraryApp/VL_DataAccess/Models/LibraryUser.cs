﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL_DataAccess.Models
{
    public class LibraryUser : BaseUser
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.ImageUrl)]
        public string? ProfilePictureUrl { get; set; }

        #region Navigation props
        ICollection<Subscription> SuscribedTo { get; set; }
        ICollection<BookReview> BookReviews { get; set; }
        #endregion

    }
}
