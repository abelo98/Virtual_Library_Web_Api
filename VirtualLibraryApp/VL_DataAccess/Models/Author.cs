﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL_DataAccess.Models
{
    public class Author: BaseUser
    {
        public string Nationality { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
