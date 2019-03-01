using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IDBOperations
    {
        void AddUser(string username, string password);
        void RemoveUser(string userDetails);
        void GetAllUsers();
        void ClearAll();
        List<File> GetAllFiles();
        File GetFileByName(string name);
        int GetAmountOfUsers();
        int GetAmountOfFiles();
        int GetAmountOfActiveUsers();
        User GetUserByUsername(string userName);
        void UpdateUser(User user, string existingUsername);
    }
}
