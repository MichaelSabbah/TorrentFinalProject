using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Class1
    {
        public void Test()
        {
            Console.WriteLine("In Test");

            Users newUser = new Users();
            newUser.UserName = "Dani";
            newUser.Password = "12345";

            //using (TorrentDBEntities db = new TorrentDBEntities())
            //{
            TorrentDBEntities db = new TorrentDBEntities();

                //db.Users.Add(newUser);
                //db.SaveChanges();

                //Console.WriteLine("User added");

                var result = from user in db.Users
                             select user.UserName;

                Console.WriteLine("get result, result = " + result);

                foreach (string userName in result)
                {
                    Console.WriteLine("{0}", userName);
                }
            //}
        }
    }
}
