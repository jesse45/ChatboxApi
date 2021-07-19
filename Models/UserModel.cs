using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatboxApi.Models
{
    public class UserModel
    {
        public string Login { get; set; } = default;
        public string Password { get; set; } = default;
        public string Email { get; set; } = default;
        public string Full_Name { get; set; } = default;
        public string Phone { get; set; } = default;
        public string Website { get; set; } = default;

    }


}
