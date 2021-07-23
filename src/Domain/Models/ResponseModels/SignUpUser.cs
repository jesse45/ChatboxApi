using System;



namespace ChatboxApi.Domain.Models
{

    public class SignUpUser
    {
        public UserObj user { get; set; }
    }

    public class UserObj
    {
        public int id { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string phone { get; set; }
        public object website { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public object last_request_at { get; set; }
        public object external_user_id { get; set; }
        public string facebook_id { get; set; }
        public string twitter_id { get; set; }
        public object blob_id { get; set; }
        public object custom_data { get; set; }
        public object avatar { get; set; }
        public object user_tags { get; set; }
    }


}
