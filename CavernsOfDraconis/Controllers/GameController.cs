using CavernsOfDraconis.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CavernsOfDraconis.Controllers
{
    public class GameController : ApiController
    {
        private DataContext db = new DataContext();

        public object Post()
        {
            var input = Request.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<JObject>(input.Result);

            var game = new Game()
            {
                deck = new Deck(data["name"].ToString(), db),
                name = data["name"].ToString(),
                owner = data["user"].ToString(),
                password = data["password"].ToString(),
                Started = DateTime.Now
            };

            db.Games.Add(game);
            var id = db.SaveChanges();

            return new { gid = id };
        }
    }
}
