using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServices" in both code and config file together.
    [ServiceContract]
    public interface ITorrentServices
    {
        [OperationContract]
        bool SignIn(string jsonUserDetails);

        [OperationContract]
        string FileRequest(string jsonFileRequest);

        [OperationContract]
        string SignOut(string jsonUserDetails);
    }
}
