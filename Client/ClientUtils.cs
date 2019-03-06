using Client.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharedObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Client
{
    class ClientUtils
    {
        public static ITorrentServices proxy = null;
        public static ClientDetails clientDetails = null;

        //Dictionary of files - To be found fast later
        public static Dictionary<string, FileView> searchingFilesResultDictionary = new Dictionary<string, FileView>();
        public static Dictionary<string, UploadingFileView> uploadingFilesDictionary = new Dictionary<string, UploadingFileView>();
        public static Dictionary<string, FileDownloadView> downloadingDictionarys = new Dictionary<string, FileDownloadView>();

        public static bool IsConfigurationFileValid()
        {
            return false;
        }

        public static ClientDetails GetDetailsFromConfigurationFile()
        {
            ClientDetails clientDetails = new ClientDetails();

            XmlTextReader xmlReader = new XmlTextReader(Consts.CONFIGURATION_FILE_NAME);

            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    switch (xmlReader.Name)
                    {
                        case Consts.USERNAME_ELEMENT_NAME:
                            xmlReader.Read();
                            clientDetails.Username = xmlReader.Value;
                            break;
                        case Consts.PASSWORD_ELEMENT_NAME:
                            xmlReader.Read();
                            clientDetails.Password = xmlReader.Value;
                            break;
                        case Consts.CLIENT_IP_ELEMENT_NAME:
                            xmlReader.Read();
                            clientDetails.IP = xmlReader.Value;
                            break;
                        case Consts.UPLOAD_ELEMENT_NAME:
                            xmlReader.Read();
                            clientDetails.UploadPath = xmlReader.Value;
                            break;
                        case Consts.DOWNLOAD_PATH_ELEMENT_NAME:
                            xmlReader.Read();
                            clientDetails.DownloadPath = xmlReader.Value;
                            break;
                        case Consts.PORT_ELEMENT_NAME:
                            xmlReader.Read();
                            clientDetails.Port = int.Parse(xmlReader.Value);
                            break;
                        default:
                            break;
                    }
                }
            }
            xmlReader.Close();

            return clientDetails;
        }

        public static List<FileSharingDetailsTO> GetFilesByName(string fileName)
        {
            FileRequestTO fileRequestTO = new FileRequestTO();
            fileRequestTO.FileName = fileName;
            fileRequestTO.Username = clientDetails.Username;
            fileRequestTO.Password = clientDetails.Password;

            string jsonFileRequest = JsonConvert.SerializeObject(fileRequestTO);
            string filesSharingDetails = proxy.FileRequest(jsonFileRequest);

            return JsonConvert.DeserializeObject<List<FileSharingDetailsTO>>(filesSharingDetails);
        }

        public static List<FileTO> LoadClientFiles()
        {
            var userFiles = new DirectoryInfo(clientDetails.UploadPath).GetFiles();
            List<FileTO> userFileTOList= new List<FileTO>();
            
            for (int i = 0; i < userFiles.Length; i++)
            {
                FileTO fileTO = new FileTO();
                fileTO.Name = userFiles[i].Name;
                fileTO.Size = userFiles[i].Length;
                userFileTOList.Add(fileTO);
            }
            return userFileTOList;
        }

        public static void SignOut()
        {
            string username = clientDetails.Username;
            string password = clientDetails.Password;
            JObject jsonUserDetailsObject = new JObject();
            jsonUserDetailsObject.Add(Consts.USERNAME_ELEMENT_NAME, username);
            jsonUserDetailsObject.Add(Consts.PASSWORD_ELEMENT_NAME, password);
            proxy.SignOut(JsonConvert.SerializeObject(jsonUserDetailsObject));
        }

        public static void DownloadFile(string fileName)
        {
            //Get the requested file
            FileRequestTO fileRequestTO = new FileRequestTO();
            fileRequestTO.FileName = fileName;
            fileRequestTO.Username = clientDetails.Username;
            fileRequestTO.Password = clientDetails.Password;
            string jsonFileRequest = JsonConvert.SerializeObject(fileRequestTO);

            //Downloading only one file - Get the firs one
            FileSharingDetailsTO requestedFile = 
                JsonConvert.DeserializeObject<List<FileSharingDetailsTO>>(proxy.FileRequest(jsonFileRequest))[0];


        }

        public static string ShowAboutFileWithReflection()
        {
            //Check if About dll file is exist (already downloaded)
            if (File.Exists(clientDetails.DownloadPath + "\\" + Consts.REFLECTION_FILE_NAME))
            {
                string details = "";
                Assembly assembly = Assembly.LoadFrom(clientDetails.DownloadPath + "\\" + Consts.REFLECTION_FILE_NAME);
                foreach(Type type in assembly.GetTypes())
                {
                    PersonAttribute personAttribute = type.GetCustomAttribute<PersonAttribute>(true);                      

                    if(personAttribute != null)
                    {
                        object currentPerson = Activator.CreateInstance(type);
                        string currentPersonName = type.GetProperty("Name").GetValue(currentPerson).ToString();
                        string currentPersonId = personAttribute.Id;
                        details += "Name: " + currentPersonName + "\n" + "Id: " + currentPersonId+"\n";
                        if (currentPersonName.Equals("Amir"))
                        {
                            details += "Amir: " + type.GetMethod("SaySomthing").Invoke(currentPerson,null);
                        }
                        details += "\n\n\n";
                    }
                }
                return details;
            }
            else
            {
                return Consts.ABOUT_FILE_NOT_FOUND_MESSAGE;
            }
        }

        public static void SetupServerConnection()
        {
            ChannelFactory < ITorrentServices > channelFactory =
                new ChannelFactory<ITorrentServices>("TorrentServiceEndpoint");

            proxy = channelFactory.CreateChannel();
        }

        public static void SignIn()
        {
            UserTO userTO = clientDetails.ToUserTo(); 
            userTO.Files = LoadClientFiles();
            string jsonUserDetails = JsonConvert.SerializeObject(userTO);
            bool signInSuccess = proxy.SignIn(jsonUserDetails);
            if (!signInSuccess)
            {
                throw new Exception(Consts.SIGN_IN_FAILED_ERROR_MESSAGE);
            }
        }

        internal static void SetConfigurationFile()
        {
            try
            {
                XmlWriterSettings xmlSetings = new XmlWriterSettings();
                xmlSetings.Indent = true;
                xmlSetings.IndentChars = "\t";
                using (XmlWriter xmlWriter = XmlWriter.Create(Consts.CONFIGURATION_FILE_NAME, xmlSetings))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement(Consts.CLIENT_DETAILS_ELEMENT_NAME);

                    xmlWriter.WriteStartElement(Consts.USERNAME_ELEMENT_NAME);
                    xmlWriter.WriteString(clientDetails.Username);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement(Consts.PASSWORD_ELEMENT_NAME);
                    xmlWriter.WriteString(clientDetails.Password);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement(Consts.CLIENT_IP_ELEMENT_NAME);
                    xmlWriter.WriteString(clientDetails.IP);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement(Consts.UPLOAD_ELEMENT_NAME);
                    xmlWriter.WriteString(clientDetails.UploadPath);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement(Consts.DOWNLOAD_PATH_ELEMENT_NAME);
                    xmlWriter.WriteString(clientDetails.DownloadPath);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteStartElement(Consts.PORT_ELEMENT_NAME);
                    xmlWriter.WriteString(clientDetails.Port.ToString());
                    xmlWriter.WriteEndElement();//Port

                    xmlWriter.WriteEndDocument();//End Doc

                    xmlWriter.Close();
                }
            }
            catch(Exception)
            {
                throw new Exception("Configuration file creation failed.");
            }
            
        }

        public static string GetIpLocalAddress()
        {
            IPHostEntry IPHost = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            string LocallIPAddress = "";
            foreach (var ipAddress in IPHost.AddressList)
            {
                if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork
                    && !IPAddress.IsLoopback(ipAddress))
                {
                    LocallIPAddress = ipAddress.ToString();
                }
            }
            return LocallIPAddress;
        }
        public static void DeleteConfigurationFile()
        {
            File.Delete(Consts.CONFIGURATION_FILE_NAME);
        }
    }
}
