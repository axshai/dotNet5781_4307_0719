using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class UserDO
    {
        public String Name { get; set; }
        public String Password { get; set; }
        public bool ManagePermission { get; set; }
        public bool IsExists { get; set; }
    }
}
