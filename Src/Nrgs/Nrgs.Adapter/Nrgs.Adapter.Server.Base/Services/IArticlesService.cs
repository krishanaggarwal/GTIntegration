﻿using Nrgs.Adapter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nrgs.Adapter.Server.Base.Services
{
    public interface IArticlesService
    {
        IEnumerable<Topic> GetArticles(string languageCode);
    }
}
