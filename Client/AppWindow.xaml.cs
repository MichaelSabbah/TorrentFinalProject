using Client.Views;
using SharedObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        //List of files - For binding to ListViews
        private List<FileView> searchingFilesResultList = new List<FileView>();
        private List<UploadingFileView> uploadingFiles = new List<UploadingFileView>();
        private List<FileDownloadView> downloadingFiles = new List<FileDownloadView>();

        //private ObservableCollection<FileDownloadView> downloadingFilesDataCollection;


        public AppWindow()
        {
            //requestedFiles = new Dictionary<string, FileSharingDetailsTO>();
            //uploadingFiles = new Dictionary<string, FileSharingDetailsTO>();
            //downloadingFiles = new Dictionary<string, FileSharingDetailsTO>();
            InitializeComponent();
            BindingListViewToData();
            SetUploadListView();
            //StartListenToRequests();
        }

        private void SetUploadListView()
        {
            List<FileTO> clientFilesToUpload =  ClientUtils.LoadClientFiles();
            foreach(FileTO fileTO in clientFilesToUpload)
            {
                UploadingFileView uploadingFileView = new UploadingFileView();
                uploadingFileView.FileName = fileTO.Name;
                uploadingFileView.Size = fileTO.Size;
                uploadingFileView.Status = Consts.IDLE_STATUS;
                uploadingFiles.Add(uploadingFileView);
                ClientUtils.uploadingFilesDictionary.Add(uploadingFileView.FileName, uploadingFileView);
            }
            UploadingFilesListView.Items.Refresh();
        }

        private void BindingListViewToData()
        {
            FileSearchResultsListView.ItemsSource = searchingFilesResultList;
            UploadingFilesListView.ItemsSource = uploadingFiles;
            DownloadsFilesListView.ItemsSource = downloadingFiles;
        }

        private void SearchFileButton_Click(object sender, RoutedEventArgs e)
        {
            string fileName = FilesNameTextBox.Text;
            List<FileSharingDetailsTO> fileSharingDetailsTOList = ClientUtils.GetFilesByName(fileName);

            searchingFilesResultList.Clear();

            if (fileSharingDetailsTOList != null && fileSharingDetailsTOList.Count == 0)
            {
                MessageBox.Show("File not found");
            }
            else
            {
                foreach (FileSharingDetailsTO fileSharingDetails in fileSharingDetailsTOList)
                {
                    //Update requested files table
                    FileView fileView = new FileView(){
                        FileName = fileSharingDetails.FileName,
                        Size = fileSharingDetails.Size,
                        Peers = fileSharingDetails.Peers.Count
                    };

                    searchingFilesResultList.Add(fileView);
                    ClientUtils.searchingFilesResultDictionary.Add(fileView.FileName, fileView);
                }
                FileSearchResultsListView.Items.Refresh();
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
            foreach (FileView f in FileSearchResultsListView.Items)
            {
                FileDownloadView downloadTableView = new FileDownloadView()
                {
                    FileName = f.FileName,
                    Size = f.Size,
                    Status = Consts.DOWNLOADING_FILE_STATUS
                };
                //if(!DownloadsView.Items.Contains(downloadTableView))
                //    DownloadsView.Items.Add(downloadTableView);
            }
        }


        //private void SetUploadListView()
        //{
        //    List<FileTO> clientFiles = ClientUtils.LoadClientFiles();
        //}

        private void FileSearchResultsListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show(Consts.DOWNLOAD_CONFIRMATION_DIALOG_MESSAGE, "Download Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                FileView selectedFile = (FileView)FileSearchResultsListView.SelectedItem;
                ClientUtils.DownloadFile(selectedFile.FileName);
            }
        }

        private void WindowClosing(object sender, EventArgs e)
        {
            ClientUtils.SignOut();
        }

        private void ReflectionButton_Click(object sender, RoutedEventArgs e)
        {

            string aboutMessageToShow = ClientUtils.ShowAboutFileWithReflection();
            MessageBox.Show(aboutMessageToShow);
        }
    }
}
