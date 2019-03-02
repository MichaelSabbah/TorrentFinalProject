using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WCFServer;
using System.Net;

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

            string userDetails = "{username : \"Amir\",password : \"12345\"}";

            bool signInResult = proxy.SignIn(userDetails);

            Console.WriteLine("SignIn called - Result = " + signInResult);

        }
    }
}
