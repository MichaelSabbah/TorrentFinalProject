using SharedObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    public class Downloading
    {
        public DownloadingManageDelegate DownloadStartedEvent;
        public DownloadingManageDelegate DownloadFinishedEvent;
        private FileSharingDetailsTO currentlyDownloadingFile;
        private byte[] bytes;

        public Downloading(FileSharingDetailsTO fileSharingDetails)
        {
            currentlyDownloadingFile = fileSharingDetails;
        }

        public void StartDownloadingFile()
        {
            int fileSize = Convert.ToInt32(currentlyDownloadingFile.Size);
            //Check if file already exist in local file system
            string filePath = ClientUtils.clientDetails.DownloadPath + "\\" + currentlyDownloadingFile.FileName;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            FileStream fileStream = File.Open(filePath, FileMode.Create);
            bytes = new byte[fileSize];
            var allPartsDownloading = new List<FilePartDownloading>();
            int partSize = fileSize / currentlyDownloadingFile.Peers.Count;
            int remainingBytesToDownload = fileSize;

            DownloadStartedEvent(currentlyDownloadingFile.FileName);

            for (int index = 0; index < currentlyDownloadingFile.Peers.Count; index++)
            {
                var oldIndex = index;
                FilePartDownloading filePartDownloading;

                if (index == currentlyDownloadingFile.Peers.Count - 1) // Last iteration
                {
                    filePartDownloading = new FilePartDownloading(
                        currentlyDownloadingFile.Peers[oldIndex].IP,
                        currentlyDownloadingFile.FileName,
                        fileSize,
                        partSize * oldIndex,
                        remainingBytesToDownload,
                        int.Parse(currentlyDownloadingFile.Peers[oldIndex].Port)
                    );
                    allPartsDownloading.Add(filePartDownloading);
                    filePartDownloading.downloadPartTask.Start();
                    break;
                }
                filePartDownloading = new FilePartDownloading(
                    currentlyDownloadingFile.Peers[oldIndex].IP,
                    currentlyDownloadingFile.FileName,
                    fileSize,
                    partSize * oldIndex,
                    partSize,
                    int.Parse(currentlyDownloadingFile.Peers[oldIndex].Port)
                );

                remainingBytesToDownload -= partSize;
                allPartsDownloading.Add(filePartDownloading);
                filePartDownloading.downloadPartTask.Start();
            }

            // Wait for everyone to finish send file parts and then save all new file
            for (int i = 0; i < allPartsDownloading.Count; i++)
            {
                //Wait for all client to send their parts
                Task.WaitAll(allPartsDownloading[i].downloadPartTask);
                //Write file to local file system
                fileStream.Write(allPartsDownloading[i].bytes, 0, allPartsDownloading[i].bytes.Length);
            }
            fileStream.Close();
            DownloadFinishedEvent(currentlyDownloadingFile.FileName);
        }
    }
}
