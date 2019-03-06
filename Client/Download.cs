using SharedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Download
    {
        public Download()
        {
        }

        public Download(FileSharingDetailsTO downloadingFile)
        {
            DownloadingFile = downloadingFile;
        }

        public FileSharingDetailsTO DownloadingFile
        {
            get;set;
        }
    }
}
