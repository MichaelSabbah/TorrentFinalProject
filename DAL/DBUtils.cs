using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBUtils
    {
        public static User UsersToUser(Users users)
        {
            User user = new User();

            if (users != null)
            {
                user.UserName = users.UserName;
                user.Password = users.Password;
                user.Connected = users.Connected;
                user.Enabled = users.Enabled;
                user.IP = users.IP;
                user.Port = users.Port;
            }

            return user;
        }

        public static File FilesToFile(Files files)
        {
            File file = new File();

            if (files != null)
            {
                file.Id = files.Id;
                file.FileName = files.FileName;
                file.Size = files.Size;
                file.Username = files.Username;
            }

            return file;
        }

        public static File FileToFiles(Files files)
        {
            File file = new File();

            if (files != null)
            {
                file.Id = files.Id;
                file.FileName = files.FileName;
                file.Size = files.Size;
                file.Username = files.Username;
            }

            return file;
        }
    }
}
