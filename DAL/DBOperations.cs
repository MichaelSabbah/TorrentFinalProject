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

        public User GetUserByUsername(string userName)
        {
            User userResult = null;

            using (TorrentDBEntities db = new TorrentDBEntities())
            {
                Users receivedUser = (from user in db.Users
                                    where user.UserName.Equals(userName)
                                    select user).FirstOrDefault();

                if(receivedUser != null)
                {
                    userResult = DBUtils.UsersToUser(receivedUser);
                }
            }
            return userResult;
        }

        public void ClearAll()
        {
            using (TorrentDBEntities db = new TorrentDBEntities())
            {
                foreach (Users user in db.Users)
                {
                    db.Users.Remove(user);
                }

                foreach (Files file in db.Files)
                {
                    db.Files.Remove(file);
                }

                db.SaveChanges();
            }
        }

        public List<File> GetAllFiles()
        {
            List<File> list = new List<File>();
            using (TorrentDBEntities db = new TorrentDBEntities())
            {
                foreach(Files f in db.Files)
                {
                    list.Add(DBUtils.FilesToFile(f));
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

        public File GetFileByName(string name)
        {
            using (TorrentDBEntities db = new TorrentDBEntities())
            {
                 Files fileInDB = (from f in db.Files
                                 where f.FileName == name
                                 select f).FirstOrDefault();
                return DBUtils.FilesToFile(fileInDB);
            }
        }

        public void RemoveUser(string username)
        {
            using (TorrentDBEntities db = new TorrentDBEntities())
            {
                Users user = db.Users.Find(username);
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        public int GetAmountOfFiles()
        {
            TorrentDBEntities db = new TorrentDBEntities();
            return db.Files.Count();
        }

        public int GetAmountOfUsers()
        {
            TorrentDBEntities db = new TorrentDBEntities();
            return db.Users.Count();
        }

        public int GetAmountOfActiveUsers()
        {
            TorrentDBEntities db = new TorrentDBEntities();
            int count = 0;
            foreach (Users user in db.Users)
            {
                if (user.Connected == true)
                    count++;
            }
            return count;
        }

        public void UpdateUser(User updatedUser, string existingUsername)
        {
            using (TorrentDBEntities db = new TorrentDBEntities())
            {
                var receivedUser = db.Users.Find(existingUsername);
                //var receivedUser = (from user in db.Users
                //                   where user.UserName.Equals(updatedUser.UserName)
                //                   select user).Single();
                receivedUser.UserName = updatedUser.UserName;
                receivedUser.Password = updatedUser.Password;
                receivedUser.Enabled = updatedUser.Enabled;
                receivedUser.Connected = updatedUser.Connected;

                db.SaveChanges();
            }
        }

        public void AddFile()
        {
            using (TorrentDBEntities db = new TorrentDBEntities())
            {
                try
                {
                    Files file = new Files();
                    file.Id = 1;
                    file.FileName = "filename";
                    file.IP = "11";
                    file.Port = "11";
                    file.Size = 123;
                    db.Files.Add(file);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception = " + e.StackTrace);
                }
            }
        }
    }
}
