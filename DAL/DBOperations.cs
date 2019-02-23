using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    db.SaveChanges();
                }
            }
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

        public void RemoveUser(string userDetails)
        {
            throw new NotImplementedException();
        }
    }
}
