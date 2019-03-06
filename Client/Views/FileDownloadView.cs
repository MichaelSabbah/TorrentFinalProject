using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Views
{
    class FileDownloadView
    {
        public string FileName
        {
            get; set;
        }

        public double Size
        {
            get; set;
        }
        public int Peers
        {
            get;set;
        }
        public string Status
        {
            get;set;
        }
        public TimeSpan Time
        {
            get;set;
        }
        public double Kbps
        {
            get;set;
        }


        public override bool Equals(object obj)
        {
            return FileName.Equals(((FileDownloadView)obj).FileName);
        }
    }
}
