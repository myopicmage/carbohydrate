using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CavernsOfDraconis.Models
{
    public class User
    {
        public int userid { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public DateTime created { get; set; }
    }
}
