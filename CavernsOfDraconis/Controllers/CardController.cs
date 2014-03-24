using CavernsOfDraconis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CavernsOfDraconis.Controllers
{
    public class CardController : ApiController
    {
        private DataContext db = new DataContext();

        public IEnumerable<CardDto> Get()
        {
            return CardDto.GenDto(db.Cards.ToList());
        }

        // GET api/<controller>/5
        public IEnumerable<Card> Get(int deck_id, int quantity, string type = "white")
        {
            var deck = db.Decks.Find(deck_id);
            var color = type == "white" ? Color.White : Color.Black;

            return deck.Get(quantity, color);
        }

        // POST api/<controller>
        public bool Post()
        {
            var input = Request.Content.ReadAsStringAsync();

            //var data =
            //    input.Result.Split('&')
            //        .Select(item => item.Replace(@"\", ""))
            //        .Select(item => item.Replace("+", " "))
            //        .Select(item => item.Split('='))
            //        .Aggregate(new Dictionary<string, string>(), (seed, item) =>
            //        {
            //            seed.Add(item[0], item[1]);
            //            return seed;
            //        });

            var data = JsonConvert.DeserializeObject<JObject>(input.Result);

            var card = new Card
            {
                title = data["title"].ToString(),
                type = data["type"].ToString() == "white" ? Color.White : Color.Black
            };

            try
            {
                db.Cards.Add(card);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var card = db.Cards.Find(id);

            try
            {
                db.Cards.Remove(card);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}