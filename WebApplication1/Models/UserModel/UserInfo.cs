using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models.RoleModel;

namespace Models.UserModel
{
    public class UserInfo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public RoleInfo Role { get; set; }
        public int? ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public UserInfo()
        {
        }
    }
}
