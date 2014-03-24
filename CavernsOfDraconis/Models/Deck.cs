using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CavernsOfDraconis.Helper;
using System.ComponentModel.DataAnnotations;

namespace CavernsOfDraconis.Models
{
    public class Deck
    {
        [Key]
        public int deck_id { get; set; }
        public string title { get; set; }

        public List<Card> white_cards { get; set; }
        public List<Card> black_cards { get; set; }

        public Deck(string title, DataContext db)
        {
            this.title = title;
            init(db);
        }

        public IEnumerable<Card> Get(int how_many, Color color)
        {
            var deck = color == Color.White ? white_cards : black_cards;
            var hand = deck.Shuffle().Take(how_many).ToList();
            hand.ForEach(card => white_cards.Remove(card));

            return hand;
        }

        private void init(DataContext db)
        {
            white_cards = db.Cards.Where(card => card.type == Color.White).ToList();
            black_cards = db.Cards.Where(card => card.type == Color.Black).ToList();
        }
    }
}