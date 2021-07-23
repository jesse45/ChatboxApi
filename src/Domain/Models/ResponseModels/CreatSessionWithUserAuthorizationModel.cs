using System;

namespace ChatboxApi.Domain.Models
{

    public class CreatSessionWithUserAuthorizationModel
    {
        public Session session { get; set; }
    }

    public class Session
    {
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int application_id { get; set; }
        public string token { get; set; }
        public long nonce { get; set; }
        public int ts { get; set; }
        public int user_id { get; set; }
        public User user { get; set; }
        public int id { get; set; }
    }

    public class User
    {
        public string _id { get; set; }
        public int id { get; set; }
        public DateTime created_at { get; set; } 
        public DateTime updated_at { get; set; } 
        public string last_request_at { get; set; } 
        public string login { get; set; }
        public string email { get; set; }
        public string full_name { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public object custom_data { get; set; }
        public string user_tags { get; set; }
        public object avatar { get; set; }
        public object twitter_id { get; set; }
        public object external_user_id { get; set; }
        public object facebook_id { get; set; }
        public object external_id { get; set; }
    }

}
