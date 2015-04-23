using Nrgs.Adapter.Domain.Models;
using Nrgs.Adapter.Server.Base.Business;
using Nrgs.Adapter.Server.Base.Repositories;
using System.Collections.Generic;

namespace Nrgs.Adapter.Server.Implementation.Business
{
    public class ArticlesBl : IArticlesBl
    {
        private IArticlesRepository _articlesrepository;

        public ArticlesBl(IArticlesRepository articlesrepository)
        {
            _articlesrepository = articlesrepository;
        }

        public IEnumerable<Topic> GetArticles(string languageCode)
        {
            return _articlesrepository.GetArticles(languageCode);
        }
    }
}
