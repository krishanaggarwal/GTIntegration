using Nrgs.Adapter.Web.Api.Infrastructure.Routing;
using Nrgs.Adapter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Nrgs.Adapter.Web.Api.Infrastructure.Extensions;
using Nrgs.Adapter.Common.Exceptions;
using Nrgs.Adapter.Server.Base.Services;

namespace Nrgs.Adapter.Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("Articles")]
    public class ArticlesController : ApiController
    {
        private IArticlesService _articlesService;
        public ArticlesController(IArticlesService articlesService)
        {
            _articlesService = articlesService;
        }

        [Route("", Name = "GetArticles")]
        public IEnumerable<Topic> GetArticles(string languageCode)
        {
            return _articlesService.GetArticles(languageCode);
        }
    }
}
