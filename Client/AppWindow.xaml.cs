﻿using Client.Views;
using SharedObjects;
using System;
using System.Collections.Generic;
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
        public AppWindow()
        {
            InitializeComponent();
        }

        private void SearchFileButton_Click(object sender, RoutedEventArgs e)
        {
            string fileName = FilesNameTextBox.Text;
            List<FileSharingDetailsTO> fileSharingDetailsTOList = ClientUtils.GetFilesByName(fileName);
            FileSearchResultsView.Items.Clear();
            foreach (FileSharingDetailsTO fileSharingDetails in fileSharingDetailsTOList)
            {
                FileTableView fileTableView = new FileTableView(){
                    FileName = fileSharingDetails.FileName,
                    Size = fileSharingDetails.Size,
                    Peers = fileSharingDetails.Peers.Count
                };

                FileSearchResultsView.Items.Add(fileTableView);
            }
        }
    }
}