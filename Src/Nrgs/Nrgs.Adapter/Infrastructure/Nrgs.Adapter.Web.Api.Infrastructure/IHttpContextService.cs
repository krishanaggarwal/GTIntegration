﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Nrgs.Adapter.Web.Api.Infrastructure
{
    public interface IHttpContextService
    {
        HttpRequest CurrentRequest { get; }
    }
}
