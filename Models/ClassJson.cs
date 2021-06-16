using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatboxApi.Models
{

    public class Rootobject
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
