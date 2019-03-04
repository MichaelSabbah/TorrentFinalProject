using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects
{
    public class UserTO
    {
        public UserTO() { }
        
        public string Username
        {
            get;set;
        }

        public string Password
        {
            get;set;
        }

        public string IP
        {
            get;set;
        }

        public string Port
        {
            get;set;
        }

        public List<FileTO> Files
        {
            get;set;
        }
    }
}
