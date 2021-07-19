using System;

namespace ChatboxApi.Models
{
    public class CreateSessionObj
    {
        public AppSession session { get; set; }
    }

    public class AppSession
    {
        public int application_id { get; set; }
        public DateTime created_at { get; set; }
        public object device_id { get; set; }
        public int id { get; set; }
        public long nonce { get; set; }
        public string token { get; set; }
        public int ts { get; set; }
        public DateTime updated_at { get; set; }
        public object user_id { get; set; }
    }

}
