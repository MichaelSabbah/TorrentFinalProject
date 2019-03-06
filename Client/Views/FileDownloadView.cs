using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Views
{
    public class FileDownloadView
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
        public int Kbps
        {
            get;set;
        }
    }
}
