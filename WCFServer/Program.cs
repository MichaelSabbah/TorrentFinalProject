using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace WCFServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("In main");
            using (ServiceHost host = new ServiceHost(typeof(TorrentServices)))
            {
                Console.WriteLine("In using");
                host.Open();
                Console.WriteLine("Server is open");
                Console.ReadLine();
            }
        }
    }
}
