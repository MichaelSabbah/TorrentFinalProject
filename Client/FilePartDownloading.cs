using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class FilePartDownloading
    {
        private string sharingClientIp;
        private int sharingClientPort;
        private string fileName;
        private int partFileOffset;
        private int amountOfBytes;
        private int fileSize;
        public byte[] bytes { get; }
        public Task downloadPartTask { get; }
        

        public FilePartDownloading(string sharingClientIp, string fileName, int fileSize, int partFileOffset, int amountOfBytes, int sharingClientPort)
        {
            this.sharingClientIp = sharingClientIp;
            this.sharingClientPort = sharingClientPort;
            this.fileName = fileName;
            this.fileSize = fileSize;
            this.partFileOffset = partFileOffset;
            this.amountOfBytes = amountOfBytes;
            bytes = new byte[amountOfBytes];

            //Downloading file part task
            downloadPartTask = new Task(() =>
            {
                DownloadSingleFilePart();
            });
        }

        private void DownloadSingleFilePart()
        {
            try
            {
                //Connect to remote client
                TcpClient tcpClient = new TcpClient(sharingClientIp, sharingClientPort);
                NetworkStream networkStream = tcpClient.GetStream();

                //Get client writer
                StreamWriter streamWriter = new StreamWriter(networkStream);

                streamWriter.WriteLine(fileName);
                streamWriter.Flush();
                streamWriter.WriteLine(fileSize);
                streamWriter.Flush();
                streamWriter.WriteLine(partFileOffset);
                streamWriter.Flush();
                streamWriter.WriteLine(amountOfBytes);
                streamWriter.Flush();

                //Debug.WriteLine("hi " + fileName + " " + partSize + " " + partFileOffset + " " + amountOfBytes);

                int receivedAmountBytes = 0;
                receivedAmountBytes += networkStream.Read(bytes, 0, bytes.Length); // Reading requested file part into bytes array
                while (receivedAmountBytes < bytes.Length)
                    networkStream.Read(bytes, 0, bytes.Length);
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
