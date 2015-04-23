using Nrgs.Adapter.Domain.Models;
using Nrgs.Adapter.Server.Base.Facade;
using Nrgs.Adapter.Server.Base.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nrgs.Adapter.Server.Implementation.Services
{
    public class ArticlesService : IArticlesService
    {
        private IArticlesFacade _articlesFacade;
        public ArticlesService(IArticlesFacade articlesFacade)
        {
            _articlesFacade = articlesFacade;
        }

        public IEnumerable<Topic> GetArticles(string languageCode)
        {
            return _articlesFacade.GetArticles(languageCode);
        }
    }
}
