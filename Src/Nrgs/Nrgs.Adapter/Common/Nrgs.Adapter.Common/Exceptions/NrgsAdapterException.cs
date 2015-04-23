using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nrgs.Adapter.Common.Exceptions
{
    public class NrgsAdapterException:Exception
    {
        public NrgsAdapterException()
        {
            Error = new Error();
        }
        public Error Error { get; set; }
    }
}
