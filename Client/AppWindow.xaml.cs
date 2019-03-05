using Client.Views;
using SharedObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for AppWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {

        private Dictionary<string, FileSharingDetailsTO> requestedFiles;
        //private ObservableCollection<TimeStepData> downloadingFilesDataCollection;
        private Dictionary<string, FileSharingDetailsTO> downloadingFiles;
        private Dictionary<string, FileSharingDetailsTO> uploadingFiles;

        public AppWindow()
        {
            requestedFiles = new Dictionary<string, FileSharingDetailsTO>();
            uploadingFiles = new Dictionary<string, FileSharingDetailsTO>();
            downloadingFiles = new Dictionary<string, FileSharingDetailsTO>();
            InitializeComponent();
            SetUploadListView();
        }

        private void SearchFileButton_Click(object sender, RoutedEventArgs e)
        {
            string fileName = FilesNameTextBox.Text;
            List<FileSharingDetailsTO> fileSharingDetailsTOList = ClientUtils.GetFilesByName(fileName);

            FileSearchResultsListView.Items.Clear();
            if (fileSharingDetailsTOList.Count==0)
                MessageBox.Show("File not found");
            else
                foreach (FileSharingDetailsTO fileSharingDetails in fileSharingDetailsTOList)
                {
                    FileView fileTableView = new FileView(){
                        FileName = fileSharingDetails.FileName,
                        Size = fileSharingDetails.Size,
                        Peers = fileSharingDetails.Peers.Count
                    };

                    FileSearchResultsListView.Items.Add(fileTableView);
            }
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            ClientUtils.SignOut();
            ClientUtils.DeleteConfigurationFile();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void DownLoadButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(FileView f in FileSearchResultsListView.Items)
            {
                FileDownloadView downloadTableView = new FileDownloadView(){
                    FileName = f.FileName,
                    Size = f.Size,
                    Status = "Downloading"
                };
                if(!DownloadsView.Items.Contains(downloadTableView))
                    DownloadsView.Items.Add(downloadTableView);
            }
        }

        private void SetUploadListView()
        {
            List<FileTO> clientFiles = ClientUtils.LoadClientFiles();
        }
    }
}
