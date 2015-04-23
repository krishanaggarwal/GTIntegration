using NaGreen.WebApi.Server.Base.Facade;
using NaGreen.WebApi.Server.Base.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaGreen.WebApi.Server.Implementation.Services
{
    public class UsersService : IUsersService
    {
        private IUsersFacade _usersFacade;

        public UsersService(IUsersFacade usersFacade)
        {
            _usersFacade = usersFacade;
        }
    }
}
