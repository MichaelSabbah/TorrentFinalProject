using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Services" in both code and config file together.
    public class TorrentServices : ITorrentServices
    {
        public void DoWork()
        {
        }

        public string FileRequest(string jsonFileRequest)
        {
            throw new NotImplementedException();
        }

        public void SignIn(string jsonUserDetails)
        {
            throw new NotImplementedException();
        }

        public string SignOut(string jsonUserDetails)
        {
            throw new NotImplementedException();
        }
    }
}
