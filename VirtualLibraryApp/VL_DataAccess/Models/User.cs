using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL_DataAccess.Models
{
    public class User:BaseUser
    {
        public string Email{ get; set; }
        public string ProfilePictureUrl { get; set; }

    }
}
