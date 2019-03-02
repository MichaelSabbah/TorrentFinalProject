using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer.TO
{
    public class FileRequestTO
    {
        public FileRequestTO() { }

        public string Username
        {
            get;set;
        }

        public string Password
        {
            get;set;
        }

        public string FileName
        {
            get;set;
        }
    }
}
