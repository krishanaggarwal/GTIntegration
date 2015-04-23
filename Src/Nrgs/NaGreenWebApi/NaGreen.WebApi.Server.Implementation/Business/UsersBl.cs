using NaGreen.WebApi.Server.Base.Business;
using NaGreen.WebApi.Server.Base.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaGreen.WebApi.Server.Implementation.Business
{
    public class UsersBl:IUsersBl
    {
        private IUsersRepository _userRepository;

        public UsersBl(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
