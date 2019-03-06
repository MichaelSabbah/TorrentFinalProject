using DAL;
using Entities;
using SharedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static List<Peer> GetAllFileSharingPeers(List<File> files,string fileName)
        {
            List<Peer> peers = new List<Peer>();
            foreach(File file in files)
            {
                Peer peer = new Peer();
                User user = dbOperations.GetUserByUsername(file.Username);
                if (user != null)
                {
                    peer.IP = user.IP;
                    peer.Port = user.Port;
                    peers.Add(peer);
                }
                else
                {
                    throw new Exception("User not exist");
                }
                peers.Add(peer);
            }
            return peers;
        }

        internal static List<FileSharingDetailsTO> GetSharingFilesTOClassifiedByName(List<File> files)
        {
            List<FileSharingDetailsTO> fileSharingDetailsTOs = new List<FileSharingDetailsTO>();
            foreach (File file in files)
            {
                FileSharingDetailsTO fileSharingDetailsTO = new FileSharingDetailsTO();
                fileSharingDetailsTO.FileName = file.FileName;
                fileSharingDetailsTO.Size = file.Size;
                fileSharingDetailsTO.Peers = GetAllFileSharingPeers(files,file.FileName);
                fileSharingDetailsTOs.Add(fileSharingDetailsTO);
            }
            return fileSharingDetailsTOs;
        }

        public static List<Peer> GetFileSharingPeers(List<File> files)
        {
            List<Peer> peers = new List<Peer>();
            foreach(File file in files)
            {
                Peer peer = new Peer();
                string username = file.Username;
                User user = dbOperations.GetUserByUsername(file.Username);
                if (user != null)
                {
                    peer.IP = user.IP;
                    peer.Port = user.Port;
                    peers.Add(peer);
                }
                else
                {
                    throw new Exception("User not exist");
                }
            }
            return peers;
        }
    }
}
