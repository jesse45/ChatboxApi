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
        public string FullName { get; set; } = default;
        public int Phone { get; set; } = default;
        public string Website { get; set; } = default;

    }
}
