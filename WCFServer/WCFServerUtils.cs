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
    }
}
