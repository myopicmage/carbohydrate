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

    public class CardDto
    {
        public string type { get; set; }
        public string title { get; set; }

        public CardDto(Card card)
        {
            this.type = card.type == Color.White ? "white" : "black";
            this.title = card.title;
        }

        public static List<CardDto> GenDto(List<Card> cards)
        {
            var cdto = new List<CardDto>();

            cards.ForEach(card => cdto.Add(new CardDto(card)));

            return cdto;
        }
    }
}