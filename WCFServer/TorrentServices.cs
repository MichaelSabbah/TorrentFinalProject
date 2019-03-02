using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Entities;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using DAL;
using System.IO;
using WCFServer.TO;

namespace WCFServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Services" in both code and config file together.
    public class TorrentServices : ITorrentServices
    {

        private DBOperations dbOperations = new DBOperations();
        private Dictionary<string,User> connectedUsers = new Dictionary<string, User>();

        public string FileRequest(string jsonFileRequest)
        {
            throw new NotImplementedException();
        }

        public bool SignIn(string jsonUserDetails)
        {
            Console.WriteLine("In SignIn...");
            
            try
            {
                UserTO userTO = JsonConvert.DeserializeObject<UserTO>(jsonUserDetails);
                JObject jsonUserDetailsObject = JObject.Parse(jsonUserDetails);
                string username = userTO.Username;
                string password = userTO.Password;

                User userEntity = dbOperations.GetUserByUsername(username);

                if (userEntity != null)
                {
                    if (userEntity.Enabled && userEntity.Password.Equals(password))
                    {
                        userEntity.Connected = true;
                        userEntity.IP = userTO.IP;
                        userEntity.Port = userTO.Port;
                        //connectedUsers.Add(username,userEntity);
                        dbOperations.UpdateUser(userEntity, username);
                        dbOperations.AddFilesByUser(WCFServerUtils.FilesListByUser(userTO));
                        Console.WriteLine("SignIn succssfully");
                        return true;
                    }
                    Console.WriteLine("The password {0} is incorrect for username {1}",password, username);
                }
                Console.WriteLine("User with username {0} no exist", username);
                return false;
            }
            catch (JsonReaderException ex)
            {
                Console.WriteLine("jsonUserDetails is not a valid JSON format");
                Console.WriteLine(ex.StackTrace);
            }

            return true;
        }

        public bool SignOut(string jsonUserDetails)
        {
            Console.WriteLine("In SignIn...");

            try
            {
                JObject jsonUserDetailsObject = JObject.Parse(jsonUserDetails);
                string username = (string)jsonUserDetailsObject.GetValue(AppConstants.USERNAME_ATTRIBUTE);
                string password = (string)jsonUserDetailsObject.GetValue(AppConstants.PASSWORD_ATTRIBUTE);
                User user = dbOerations.GetUserByUsername(username);
                if (user != null)
                {
                    if (user.Enabled && user.Password.Equals(password))
                    {
                        user.Connected = true;
                        dbOerations.UpdateUser(user, username);
                        Console.WriteLine("SignIn succssfully");
                        return true;
                    }
                    Console.WriteLine("The password {0} is incorrect for username {1}", password, username);
                }
                Console.WriteLine("User with username {0} no exist", username);
                return false;
            }
            catch (JsonReaderException ex)
            {
                Console.WriteLine("jsonUserDetails is not a valid JSON format");
                Console.WriteLine(ex.StackTrace);
            }

            return true;
        }
    }
    }
}
