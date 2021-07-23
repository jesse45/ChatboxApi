

namespace ChatboxApi.Domain.Models
{
    public class SessionObject
    {
        public int application_id { get; set; }
        public string auth_key { get; set; }
        public double nonce { get; set; }
        public double timestamp { get; set; }
        public string signature { get; set; }
        public dynamic user { get; set; }
        /*public Dictionary<string, string> user = new Dictionary<string, string>();*/
    }
}
