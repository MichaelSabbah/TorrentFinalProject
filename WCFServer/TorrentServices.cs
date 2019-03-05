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
using SharedObjects;

namespace WCFServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Services" in both code and config file together.
    public class TorrentServices : ITorrentServices
    {

        private DBOperations dbOperations = new DBOperations();
        private static Dictionary<string, UserTO> connectedUsers = new Dictionary<string, UserTO>();

        public string FileRequest(string jsonFileRequest)
        {
            FileRequestTO fileRequestTO = JsonConvert.DeserializeObject<FileRequestTO>(jsonFileRequest);
            string jsonFileSharingDetailsList = null;
            User userEntity = dbOperations.GetUserByUsername(fileRequestTO.Username);
            if(userEntity != null) //User exist
            {
                if(userEntity.Enabled && userEntity.Password.Equals(fileRequestTO.Password))//Correct password
                {
                    List<File> files = null;
                    List<FileSharingDetailsTO> fileSharingDetailsTOs = new List<FileSharingDetailsTO>();
                    if (fileRequestTO.FileName.Equals("*"))
                    {
                        files = dbOperations.GetAllFiles();
                    }
                    else
                    {
                        files = dbOperations.GetAllFileSharingReferencesByFileName(fileRequestTO.FileName);
                    }

                    foreach(File file in files)
                    {
                        FileSharingDetailsTO fileSharingDetailsTO = new FileSharingDetailsTO();
                        fileSharingDetailsTO.FileName = file.FileName;
                        fileSharingDetailsTO.Size = files.First().Size;
                        fileSharingDetailsTO.Peers = WCFServerUtils.GetAllSharingPeers(files);
                        fileSharingDetailsTOs.Add(fileSharingDetailsTO);
                    }
                    jsonFileSharingDetailsList = JsonConvert.SerializeObject(fileSharingDetailsTOs);
                    return jsonFileSharingDetailsList;
                }
                Console.WriteLine("User is not enabled or password is incorrect");
            }
            Console.WriteLine("User with username {0} not exist.", fileRequestTO.Username);
            return jsonFileSharingDetailsList;
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
                        connectedUsers.Add(username, userTO);
                        dbOperations.UpdateUser(userEntity, username);
                        dbOperations.AddFilesByUser(WCFServerUtils.FilesListByUser(userTO));
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

        public bool SignOut(string jsonUserDetails)
        {
            try
            {
                JObject jsonUserDetailsObject = JObject.Parse(jsonUserDetails);
                string username = (string)jsonUserDetailsObject.GetValue("Username");
                string password = (string)jsonUserDetailsObject.GetValue("Password");

                User userEntity = dbOperations.GetUserByUsername(username);

                if (userEntity != null)
                {
                    if (userEntity.Enabled && userEntity.Password.Equals(password))
                    {
                        userEntity.Connected = false;
                        connectedUsers.Remove(username);
                        dbOperations.UpdateUser(userEntity, username);
                        dbOperations.RemoveFilesByUserName(username);

                        Console.WriteLine("SignOut succssfully");
                        return true;
                    }
                }
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
