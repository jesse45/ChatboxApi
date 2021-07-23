using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatboxApi.Dtos
{
    public class SessionDto
    {
        public int Application_id { get; set; }
        public string Auth_key { get; set; }
        public double Nonce { get; set; }
        public double Timestamp { get; set; }
        public string Signature { get; set; }
        public dynamic User { get; set; }
    }
}
