using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class User
    {

        public User()
        {

        }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
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
