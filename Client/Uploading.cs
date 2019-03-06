using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Uploading
    {
        public UploadingManageDelegate UploadStartedEvent;
        public UploadingManageDelegate UploadFinishedEvent;

        internal void StartTCPListen()
        {
            int clientPort = ClientUtils.clientDetails.Port;
            TcpListener listener = new TcpListener(IPAddress.Any, clientPort);

            //Start listen to requests
            listener.Start();
            while (true)
            {
                //Accept remote client request
                TcpClient client = listener.AcceptTcpClient();

                //Start task to handle file upload request
                Task.Factory.StartNew(() => StartUploadTask(client));
            }
        }

        private void StartUploadTask(TcpClient client)
        {
            NetworkStream clientNetworkStream = client.GetStream();
            StreamReader clientsStreamReader = new StreamReader(clientNetworkStream);

            //Get file request details from remote peer
            var requestedFileName = clientsStreamReader.ReadLine();
            var requestedFileSize = clientsStreamReader.ReadLine();
            var amountOfBytesToUpload = clientsStreamReader.ReadLine();
            var startingByteOffset = clientsStreamReader.ReadLine();

            UploadStartedEvent(requestedFileName);

            byte[] bytes = new byte[int.Parse(amountOfBytesToUpload)];

            //Get file path in local file system
            string filePath = ClientUtils.clientDetails.UploadPath + "\\" + requestedFileName;

            bool finishedReadingAndTransfering = false;

            //Start reading the file from local file system and transfering the file to remote peer
            while (!finishedReadingAndTransfering)
            {
                try
                {
                    //Read file from local file system to bytes array
                    using (BinaryReader reader = new BinaryReader(new FileStream(filePath, FileMode.Open)))
                    {
                        //Seek for the starting requested place at file
                        long offset = long.Parse(startingByteOffset);
                        reader.BaseStream.Seek(offset, SeekOrigin.Begin);

                        reader.Read(bytes, 0, bytes.Length);
                    }
                    finishedReadingAndTransfering = true; //Reading finished

                    //Write file to remote peeer
                    clientNetworkStream.Write(bytes, 0, bytes.Length);
                }
                catch //(IOException e)
                {
                    finishedReadingAndTransfering = false;
                }
            }
            //Finish transfering the file to remote peer

            UploadFinishedEvent(requestedFileName);
        }
    }
}
