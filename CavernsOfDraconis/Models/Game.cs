using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CavernsOfDraconis.Models
{
    public class Game
    {
        public int gameid { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string owner { get; set; }
        public DateTime Started { get; set; }

        public int deckid { get; set; }
        public Deck deck { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}