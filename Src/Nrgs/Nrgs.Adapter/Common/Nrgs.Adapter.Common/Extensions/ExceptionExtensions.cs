using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nrgs.Adapter.Common.Extensions
{
    public static class ExceptionExtensions
    {
        public static Exception GetInnerMostException(this Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
    }
}
