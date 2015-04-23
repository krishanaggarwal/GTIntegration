using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nrgs.Adapter.Domain.Models
{
    public class Topic
    {
        public Topic()
        {
            Articles = new List<Article>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public string GameId { get; set; }

        public List<Article> Articles { get; set; }
    }
}
