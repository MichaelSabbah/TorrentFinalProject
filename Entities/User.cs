using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public User()
        {

        }

        public User(string userName, string password, bool connected, bool enabled)
        {
            UserName = userName;
            Password = password;
            Connected = connected;
            Enabled = enabled;
        }

        public string UserName
        {
            get;set;
        }

        public string Password
        {
            get; set;
        }
        public bool Connected
        {
            get; set;
        }
        public bool Enabled
        {
            get;set;
        }
    }
}
