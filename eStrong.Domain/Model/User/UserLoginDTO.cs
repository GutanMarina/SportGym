using System;
using System.Collections.Generic;
using System.Text;

namespace eStrong.Domain.Model.User
{
    public class UserLoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; } 
        public string LastIp { get; set; }

        public DateTime LastLogin { get; set; }


    }
}
