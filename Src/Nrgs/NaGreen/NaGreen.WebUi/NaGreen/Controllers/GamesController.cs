using NaGreen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NaGreen.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        private static List<Game> gameList;
        //
        // GET: /Games/
        public ActionResult GetGameList()
        {
            var list = new List<Game>();
            list.Add(new Game() { Id = 1, Title = "Hello" });
            list.Add(new Game() { Id = 1, Title = "Hello" });
            list.Add(new Game() { Id = 1, Title = "Hello" });
            var gameResult = new GamesResult() { GameList = list };
            gameList = list.ToList();
            return View(gameResult);
        }

        public ActionResult GetGame(int gameId)
        {
            var game = gameList.Where(x => x.Id == gameId).FirstOrDefault();
            string gameUrl= game!=null ? game.Url: "Hello.html";
            return View(game);
        }
	}
}