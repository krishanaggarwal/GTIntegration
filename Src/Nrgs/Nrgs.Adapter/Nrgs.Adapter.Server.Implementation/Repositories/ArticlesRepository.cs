using Nrgs.Adapter.Common.Configuration;
using Nrgs.Adapter.Common.Constants;
using Nrgs.Adapter.Common.Exceptions;
using Nrgs.Adapter.Domain.Models;
using Nrgs.Adapter.Server.Base.Repositories;
using Nrgs.Adapter.Web.Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nrgs.Adapter.Server.Implementation.Repositories
{
    public class ArticlesRepository : Repository<Topic>, IArticlesRepository
    {
        private IRestClient<Topic> _restClient;
        public ArticlesRepository(IRestClient<Topic> restClient,INrgsConfigurations configurations):base(restClient)
        {
            _restClient = restClient;
            _restClient.BaseAddress = configurations.GetConfigurationSettingValue(Constants.ConfigurationKeys.ArticlesBaseUrl);
        }

        public IEnumerable<Topic> GetArticles(string languageCode)
        {
            _restClient.GetItemRequest("Test").Wait();
            return new List<Topic>();
        }
    }
}
