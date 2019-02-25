using Entities;
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

            //Users newUser = new Users();
            //newUser.UserName = "SHOSHI";
            //newUser.Password = "1235";
            Files f = new Files();
            f.FileName = "dido2.txt";
            f.Id = 1234;
            f.IP = "192";
            f.Port = "8081";
            f.Size = 39.5;

            TorrentDBEntities db = new TorrentDBEntities();
           // DBOperations dop = new DBOperations();
            //    db.Users.Add(newUser);
                db.Files.Add(f);
                db.SaveChanges();
                //List<File> list = dop.getAllFiles();

            //Console.WriteLine("User added");

            //var result = from fi in list
            //             select fi.Size;
            //    foreach(float userName in result)
            //    {
            //        Console.WriteLine("{0}", userName);
            //    }
        }
    }
}
