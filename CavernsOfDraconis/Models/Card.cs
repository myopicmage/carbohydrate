using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CavernsOfDraconis.Models
{
    public class Card
    {
        public int cardid { get; set; }
        public Color type { get; set; }
        public string title { get; set; }
    }

    public enum Color
    {
        Black,
        White
    }
}