using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WCFServer;
using System.Net;
using Entities;
using SharedObjects;
using Newtonsoft.Json;

namespace ClienTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("In client main");

            /*IPHostEntry IPHost = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach (var ipAddress in IPHost.AddressList)
            {
                Console.WriteLine(ipAddress.ToString());
            }*/

            ChannelFactory<ITorrentServices> channelFactory =
                new ChannelFactory<ITorrentServices>("TorrentServiceEndpoint");

            Console.WriteLine("ChannlFactory created");

            ITorrentServices proxy = channelFactory.CreateChannel();

            Console.WriteLine("Channl proxy created");

            Console.WriteLine("Test SignIn");

            List<FileTO> files = new List<FileTO>();
            files.Add(new FileTO("file1", 10));
            files.Add(new FileTO("file2", 15));

            UserTO userTO = new UserTO();
            userTO.Username = "Amir";
            userTO.Password = "12345";
            userTO.IP = "123.123.123.123";
            userTO.Port = "1234";
            userTO.Files = files;

            string userDetails = "";

            try
            {
                userDetails = JsonConvert.SerializeObject(userTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine("userDetails = " + userDetails);

            //SignIn Test
            bool signInResult = proxy.SignIn(userDetails);
            Console.WriteLine("SignIn called - Result = " + signInResult);

            //File Request Test
            FileRequestTO fileRequestTO = new FileRequestTO();
            fileRequestTO.Username = "Amir";
            fileRequestTO.Password = "12345";
            fileRequestTO.FileName = "file1";
            string sharingFilesResponse = proxy.FileRequest(JsonConvert.SerializeObject(fileRequestTO));
            if(sharingFilesResponse != null)
            {
                Console.WriteLine("sharingFilesResponse = " + sharingFilesResponse);
                FileSharingDetailsTO fileSharingDetailsTO = JsonConvert.DeserializeObject<FileSharingDetailsTO>(sharingFilesResponse);
            }
            else
            {
                Console.WriteLine("User or Password are invalid");
            }
            //Console.WriteLine(" First peer = " + fileSharingDetailsTO.Peers.First().IP);

            //SignOut Test
            bool signOutResult = proxy.SignOut(userDetails);
            Console.WriteLine("signOut={0}", signOutResult);
            
        }
    }
}
