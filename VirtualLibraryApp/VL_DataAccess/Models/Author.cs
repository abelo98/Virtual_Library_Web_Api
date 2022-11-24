using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL_DataAccess.Models
{
    public class Author: BaseEntity
    {
        public string Name { get; set; }
        public string Nacionality { get; set; }
    }
}
