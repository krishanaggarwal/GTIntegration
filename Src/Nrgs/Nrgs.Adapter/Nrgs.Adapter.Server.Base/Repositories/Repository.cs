using Nrgs.Adapter.Web.Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nrgs.Adapter.Server.Base.Repositories
{
    public class Repository<T>:IRepository<T> where T:class
    {
        public Repository(IRestClient<T> restClient)
        {

        }
    }
}
