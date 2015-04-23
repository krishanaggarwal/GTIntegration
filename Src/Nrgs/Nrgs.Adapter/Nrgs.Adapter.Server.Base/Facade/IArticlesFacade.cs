using Nrgs.Adapter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nrgs.Adapter.Server.Base.Facade
{
    public interface IArticlesFacade
    {
        IEnumerable<Topic> GetArticles(string languageCode);
    }
}
