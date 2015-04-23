using Nrgs.Adapter.Domain.Models;
using Nrgs.Adapter.Server.Base.Business;
using Nrgs.Adapter.Server.Base.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nrgs.Adapter.Server.Implementation.Facade
{
    public class ArticlesFacade : IArticlesFacade
    {
        private IArticlesBl _articlesBl;

        public ArticlesFacade(IArticlesBl articlesBl)
        {
            _articlesBl = articlesBl;
        }

        public IEnumerable<Topic> GetArticles(string languageCode)
        {
            return _articlesBl.GetArticles(languageCode);
        }
    }
}
