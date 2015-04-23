using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaGreen.Models
{
    public class Game
    {
        public Game()
        {
            Url = "Hello.html";
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}