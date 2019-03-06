using SharedObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public  MainWindow()
        {
            SetUp(false);
            //InitializeComponent();
        }

        public MainWindow(bool openedByAnotherWindow)
        {
            SetUp(openedByAnotherWindow);
        }

        public void SetUp(bool openedByAnotherWindow)
        {
            try
            {
                Client.ClientUtils.SetupServerConnection(); //Set connection to WCF Server

                ClientUtils.clientDetails = new ClientDetails();

                if (openedByAnotherWindow) //Open after 'SignedOut' button pressed - From SharingFilesWindow
                {
                    InitializeComponent();
                }
                else //Application opened from client computer
                {
                    InitializeComponent();
                    Hide();

                    //Get user details (from Config file or from GUI)
                    if (File.Exists(Consts.CONFIGURATION_FILE_NAME)) //Configurations file exist - Get details from file
                    {
                        try
                        {
                            ClientUtils.clientDetails = ClientUtils.GetDetailsFromConfigurationFile();
                            //Details get from configuration file - Try Sign In
                            ClientUtils.SignIn();
                            //Sign In success - Move to SharingFilesWindow
                            AppWindow appWindow = new AppWindow();
                            appWindow.Show();
                            Close();
                        }
                        catch (Exception ex) //Error occured - Get details from user
                        {
                            Show();
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                    else //Configuration file not exist - Get details from user
                    {
                        Show();
                    }
                }
            }
            catch (Exception)
            {
                ClientUtils.SignOut();
                Close();
            }
        }

        private void downlaodPathButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowsingDialog = 
                new System.Windows.Forms.FolderBrowserDialog();

            folderBrowsingDialog.Description = Consts.BROWSE_DOWNLOAD_FOLDER_DIALOG_DESCRIPTION;

            if (folderBrowsingDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ClientUtils.clientDetails.DownloadPath = folderBrowsingDialog.SelectedPath;
            }
        }

        private void uploadPathButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowsingDialog =
                new System.Windows.Forms.FolderBrowserDialog();

            folderBrowsingDialog.Description = Consts.BROWSE_DOWNLOAD_FOLDER_DIALOG_DESCRIPTION;

            if (folderBrowsingDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ClientUtils.clientDetails.UploadPath = folderBrowsingDialog.SelectedPath;
            }
        }

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            ClientUtils.clientDetails.Username = UsernameTextBox.Text;
            ClientUtils.clientDetails.Password = PasswordTextBox.Text;
            ClientUtils.clientDetails.IP = ClientUtils.GetIpLocalAddress();
            ClientUtils.clientDetails.Port = int.Parse(Consts.CLIENT_PORT);
            try
            {
                ClientUtils.SetConfigurationFile();
                ClientUtils.SignIn();
                //Signed In successfully - Show AppWindow
                AppWindow appWindow = new AppWindow();
                appWindow.Show();
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
