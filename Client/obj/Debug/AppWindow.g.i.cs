
﻿#pragma checksum "..\..\AppWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "68CC0B38DDE2D0741206C912D04E06E21D249D48"

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Client;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Client {
    
    
    /// <summary>
    /// AppWindow
    /// </summary>
    public partial class AppWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\AppWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock FileNameText;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\AppWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FilesNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\AppWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchFileButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\AppWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView FileSearchResultsListView;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\AppWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView UploadingFilesListView;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\AppWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView DownloadsView;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\AppWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock FilesTableText;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\AppWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DownlaodsTableText;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\AppWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock UploadsTableText;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\AppWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SignOutButton;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\AppWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ReflectionButton;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\AppWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DownLoadButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Client;component/appwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AppWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.FileNameText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.FilesNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.SearchFileButton = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\AppWindow.xaml"
            this.SearchFileButton.Click += new System.Windows.RoutedEventHandler(this.SearchFileButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.FileSearchResultsListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:

            this.DownloadsView = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.FilesTableText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.DownlaodsTableText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.UploadsTableText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.SignOutButton = ((System.Windows.Controls.Button)(target));

            
            #line 47 "..\..\AppWindow.xaml"
            this.SignOutButton.Click += new System.Windows.RoutedEventHandler(this.SignOutButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ReflectionButton = ((System.Windows.Controls.Button)(target));
            return;
            case 11:
            this.DownLoadButton = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\AppWindow.xaml"
            this.DownLoadButton.Click += new System.Windows.RoutedEventHandler(this.DownLoadButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

