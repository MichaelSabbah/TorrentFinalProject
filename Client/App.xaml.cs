using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("A unhandled exception occured: " + e.Exception.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
            ClientUtils.SignOut();
            ((Window)sender).Close();
            
        }
    }
}
