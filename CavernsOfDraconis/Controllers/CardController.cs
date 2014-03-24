using CavernsOfDraconis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CavernsOfDraconis.Controllers
{
    public class CardController : ApiController
    {
        private DataContext db = new DataContext();

        // GET api/<controller>/5
        public IEnumerable<Card> Get(int deck_id, int quantity, string type = "white")
        {
            var deck = db.Decks.Find(deck_id);
            var color = type == "white" ? Color.White : Color.Black;

            return deck.Get(quantity, color);
        }

        // POST api/<controller>
        public void Post()
        {
            var input = Request.Content.ReadAsStringAsync();

            var data =
                input.Result.Split('&')
                    .Select(item => item.Replace("+", " "))
                    .Select(item => item.Split('='))
                    .Aggregate(new Dictionary<string, string>(), (seed, item) =>
                    {
                        seed.Add(item[0], item[1]);
                        return seed;
                    });

            var card = new Card
            {
                title = data["title"],
                type = data["type"] == "white" ? Color.White : Color.Black
            };

            db.Cards.Add(card);
            db.SaveChanges();
        }
    }
}