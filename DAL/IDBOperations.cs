using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    interface IDBOperations
    {
        void AddUser(string username, string password);
        void RemoveUser(string userDetails);
        void GetAllUsers();
        void ClearAll();
        List<File> getAllFiles();
        File getFileByName(string name);
        int getAmountOfUsers();
        int getAmountOfFiles();
        int getAmountOfActiveUsers();
    }
}
