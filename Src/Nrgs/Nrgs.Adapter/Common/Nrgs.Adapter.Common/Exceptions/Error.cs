using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Nrgs.Adapter.Common.Exceptions
{
    public class Error
    {
        public Error()
        {
            Parameters = new List<Parameter>();
        }

        public HttpStatusCode HttpStatus { get; set; }
        public string DetailStatus
        {
            get
            {
                return HttpWorkerRequest.GetStatusDescription((int)HttpStatus);
            }
        }
        public string ErrorDescription { get; set; }
        public List<Parameter> Parameters { get; set; }
    }
}
