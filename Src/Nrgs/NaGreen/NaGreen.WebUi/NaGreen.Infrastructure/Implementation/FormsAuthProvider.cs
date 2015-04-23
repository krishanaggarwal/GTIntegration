using NaGreen.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace NaGreen.Infrastructure.Implementation
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            FormsAuthentication.SetAuthCookie(username, false);
            return true;
        }
    }
}
