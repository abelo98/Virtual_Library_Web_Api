using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VL_DataAccess.Models;

namespace Services_Layer.Models
{
    public class AllUsers
    {
        public int TotalUsers { get { return Users.Count; } set { } }
        public ICollection<LibraryUser> Users { get; set; }
        public int TotalAuthors { get; set; }
    }
}
