using NaGreen.WebUi.Server.Base.Repositories;
using NaGreen.WebUi.Server.Base.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaGreen.WebUi.Server.Implementation.Services
{
    public class UsersService:IUsersService
    {
        private IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
    }
}
