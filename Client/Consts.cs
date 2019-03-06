using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Consts
    {
        //Dialogs Text
        public static string BROWSE_DOWNLOAD_FOLDER_DIALOG_DESCRIPTION = "Select folder for downloading files";
        public static string BROWSE_UPLOAD_FOLDER_DIALOG_DESCRIPTION = "Select folder for uploading files";
        public static string DOWNLOAD_CONFIRMATION_DIALOG_MESSAGE = "Are you sure you want to download this file?";
        public static string ABOUT_FILE_NOT_FOUND_MESSAGE = "Sorry, About file not exist";

        //Error Messages
        public static string CONFIGURATION_FILE_INVALID_ERROR_MESSAGE = "Configuration details file is invalid. \nPlease Sign In.";
        public static string SIGN_IN_FAILED_ERROR_MESSAGE = "Sign In failed. Try again";

        //User Details 
        public const string CLIENT_PORT = "8005";

        //Configuration File Fields - User Details 
        public const string CLIENT_DETAILS_ELEMENT_NAME = "ClientDetails";
        public const string USERNAME_ELEMENT_NAME = "Username";
        public const string PASSWORD_ELEMENT_NAME = "Password";
        public const string DOWNLOAD_PATH_ELEMENT_NAME = "DownloadPath";
        public const string UPLOAD_ELEMENT_NAME = "UplodaPath";
        public const string CLIENT_IP_ELEMENT_NAME = "IP";
        public const string PORT_ELEMENT_NAME = "Port";
        
        //Folders And Files Names
        public static string CONFIGURATION_FILE_NAME = "Config2018.xml";

        //Fils Sharing Status
        public const string UPLOADING_FILE_STATUS = "Uploading";
        public const string DOWNLOADING_FILE_STATUS = "Downlaoding";
        public const string NONE_STATUS = "None";
        public const string DOWNLOAD_FILE_COMPLETED_STATUS = "Complete";

        //Reflection file name
        public const string REFLECTION_FILE_NAME = "AboutReflectionDLL.dll";


    }
}
