﻿#pragma checksum "..\..\..\Pages\Media_Page.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6C9D207C08148D76B038F9FE82E377F95D13A5D9"
//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

using ImageTraveler.Pages;
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


namespace ImageTraveler.Pages {
    
    
    /// <summary>
    /// Media_Page
    /// </summary>
    public partial class Media_Page : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\Pages\Media_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement mediaElement;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Pages\Media_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContextMenu CM;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Pages\Media_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Subtitle_TextBlock;
        
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
            System.Uri resourceLocater = new System.Uri("/ImageTraveler;component/pages/media_page.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Media_Page.xaml"
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
            this.mediaElement = ((System.Windows.Controls.MediaElement)(target));
            
            #line 25 "..\..\..\Pages\Media_Page.xaml"
            this.mediaElement.BufferingEnded += new System.Windows.RoutedEventHandler(this.mediaElement_BufferingEnded);
            
            #line default
            #line hidden
            
            #line 26 "..\..\..\Pages\Media_Page.xaml"
            this.mediaElement.Loaded += new System.Windows.RoutedEventHandler(this.mediaElement_Loaded);
            
            #line default
            #line hidden
            
            #line 28 "..\..\..\Pages\Media_Page.xaml"
            this.mediaElement.MediaEnded += new System.Windows.RoutedEventHandler(this.mediaElement_MediaEnded);
            
            #line default
            #line hidden
            
            #line 29 "..\..\..\Pages\Media_Page.xaml"
            this.mediaElement.MediaOpened += new System.Windows.RoutedEventHandler(this.mediaElement_MediaOpened);
            
            #line default
            #line hidden
            
            #line 30 "..\..\..\Pages\Media_Page.xaml"
            this.mediaElement.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.mediaElement_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 31 "..\..\..\Pages\Media_Page.xaml"
            this.mediaElement.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.mediaElement_MouseLeftButtonUp);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\Pages\Media_Page.xaml"
            this.mediaElement.MouseMove += new System.Windows.Input.MouseEventHandler(this.mediaElement_MouseMove);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CM = ((System.Windows.Controls.ContextMenu)(target));
            return;
            case 3:
            
            #line 38 "..\..\..\Pages\Media_Page.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Subtitle_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Subtitle_TextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

