using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nrgs.Adapter.Common.Constants
{
    public static class Constants
    {
        public static class HeaderNames
        {
            public const string DateUtc = "DateUtc";
            public const string X_Forwarded_For_UserAgent="X-Forwarded-For-UserAgent";
            public const string X_Forwarded_For_UserIp="X-Forwarded-For-UserIp";
        }

        public static class SchemeTypes
        {
            public const string V1 = "v1";
            public const string P1 = "p1";
        }

        public static class ConfigurationKeys
        {
            public const string ArticlesBaseUrl = "ArticlesBaseUrl";
        }
    }
}
