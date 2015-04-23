using NaGreen.WebApi.Server.Base.Business;
using NaGreen.WebApi.Server.Base.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaGreen.WebApi.Server.Implementation.Facade
{
    public class UsersFacade:IUsersFacade
    {
        private IUsersBl _userBl;

        public UsersFacade(IUsersBl userBl)
        {
            _userBl = userBl;
        }
    }
}
