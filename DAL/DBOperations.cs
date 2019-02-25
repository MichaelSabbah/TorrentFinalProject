using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class DBOperations : IDBOperations
    {
        public void AddUser(string username, string password)
        {
            using(TorrentDBEntities db = new TorrentDBEntities())
            {
                Users user = new Users();
                user.UserName = username;
                user.Password = password;
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void ClearAll()
        {
            using (TorrentDBEntities db = new TorrentDBEntities())
            {
                foreach (Users user in db.Users)
                {
                    db.Users.Remove(user);
                }
                db.SaveChanges();
            }
        }

        public List<File> getAllFiles()
        {
            List<File> list = new List<File>();
            using (TorrentDBEntities db = new TorrentDBEntities())
            {
                foreach(Files f in db.Files)
                {
                    list.Add(FilesToFile(f));
                }
            }
            return list;
        }

        public void GetAllUsers()
        {
            using (TorrentDBEntities db = new TorrentDBEntities())
            {

                Console.WriteLine("Users:");
                foreach (Users user in db.Users)
                {
                    Console.WriteLine(user.UserName);
                }
            }
        }

        public File getFileByName(string name)
        {
            using (TorrentDBEntities db = new TorrentDBEntities())
            {
                 Files fileInDB = (from f in db.Files
                                 where f.FileName == name
                                 select f).FirstOrDefault();
                return FilesToFile(fileInDB);
            }
        }

        public void RemoveUser(string userDetails)
        {
            throw new NotImplementedException();
        }
        public File FilesToFile(Files files)
        {
            File result = new File();
            if (files != null)
            {
                result.Id = files.Id;
                result.FileName = files.FileName;
                result.IP = files.IP;
                result.Port = files.Port;
                result.Size = files.Size;
            }
                return result;
        }

        public int getAmountOfUsers()
        {
            TorrentDBEntities db = new TorrentDBEntities();
            return db.Users.Count();
        }
        public int getAmountOfFiles()
        {
            TorrentDBEntities db = new TorrentDBEntities();
            return db.Files.Count();
        }
        public int getAmountOfActiveUsers()
        {
            TorrentDBEntities db = new TorrentDBEntities();
            int count = 0;
            foreach(Users user in db.Users)
            {
                if (user.Connected==true)
                    count++;
            }
            return count;
        }
    }
}
