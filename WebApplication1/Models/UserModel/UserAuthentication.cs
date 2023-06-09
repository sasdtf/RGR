using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.UserModel
{
    public class UserAuthentication
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public UserAuthentication(string login, string password)
        { 
            Login= login;
            Password= password;
        }
        public UserAuthentication()
        {

        }
    }
}
