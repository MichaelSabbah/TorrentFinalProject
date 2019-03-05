using SharedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class ClientDetails
    {
        public ClientDetails() { }

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

        public int Port
        {
            get;set;
        }

        public string DownloadPath
        {
            get;set;
        }

        public string UploadPath
        {
            get;set;
        }
        
        public UserTO ToUserTo()
        {
            UserTO userTO = new UserTO();
            userTO.Username = Username;
            userTO.Password = Password;
            userTO.IP = IP;
            userTO.Port = Port.ToString();
            return userTO;
        }
    }
}
