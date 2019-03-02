using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace WCFServer.TO
{
    public class FileSharingDetailsTO
    {
        public FileSharingDetailsTO() { }

        public string FileName
        {
            get;set;
        }

        public double Size
        {
            get;set;
        }

        public List<Peer> Peers
        {
            get;set;
        }
    }
}
