using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaGreen.WebApi.Common.Exceptions
{
    public class NaGreenWebException:Exception
    {
        public NaGreenWebException()
        {
            Error = new Error();
        }

        public Error Error { get; set; }
    }
}
