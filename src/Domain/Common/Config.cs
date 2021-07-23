using System;

namespace ChatboxApi.Domain.Common
{
    public class Config
    {
        public Cred cred { get; set; }
        public Urls urls { get; set; }
        public Pathnames pathNames { get; set; }
    }

    public class Cred
    {
        public int appId { get; set; }
        public string authKey { get; set; }
        public string authSecret { get; set; }
    }

    public class Urls
    {
        public string api_endpoint { get; set; }
    }

    public class Pathnames
    {
        public string users { get; set; }
        public string session { get; set; }
    }

}
