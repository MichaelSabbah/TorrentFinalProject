using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServer.TO;

namespace WCFServer
{
    public class WCFServerUtils
    {
        private static DBOperations dbOperations = new DBOperations();

        public static List<File> FilesListByUser(UserTO user)
        {
            List<File> files = new List<File>();
            foreach(FileTO fileTO in user.Files)
            {
                File file = new File();
                file.FileName = fileTO.Name;
                file.Size = fileTO.Size;
                file.Username = user.Username;
                files.Add(file);
            }
            return files;
        }

        public static void RemoveUserFiles(string IP)
        {

        }

        public static List<Peer> GetAllSharingPeers(List<File> files)
        {
            List<Peer> peers = new List<Peer>();
            foreach(File file in files)
            {
                User user = dbOperations.GetUserByUsername(file.Username);
                if(user != null)
                {
                    if(user.Enabled && user.Connected)
                    {
                        Peer peer = new Peer();
                        peer.IP = user.IP;
                        peer.Port = user.Port;
                        peers.Add(peer);
                    }
                }
            }
            return peers;
        }
    }
}
