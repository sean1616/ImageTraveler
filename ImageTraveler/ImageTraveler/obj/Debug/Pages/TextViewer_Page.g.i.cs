﻿#pragma checksum "..\..\..\Pages\TextViewer_Page.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E6B10E4FCF548024C84DA2A6E22E2E7136B256181F11E6959847275568248947"
//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Rendering;
using ICSharpCode.AvalonEdit.Search;
using ImageTraveler;
using ImageTraveler.Pages;
using ImageTraveler.ViewModels;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
    /// TextViewer_Page
    /// </summary>
    public partial class TextViewer_Page : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 453 "..\..\..\Pages\TextViewer_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_txtMainGrid;
        
        #line default
        #line hidden
        
        
        #line 460 "..\..\..\Pages\TextViewer_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ICSharpCode.AvalonEdit.TextEditor avalonTxt;
        
        #line default
        #line hidden
        
        
        #line 471 "..\..\..\Pages\TextViewer_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Grid_Chapter_Content;
        
        #line default
        #line hidden
        
        
        #line 487 "..\..\..\Pages\TextViewer_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_CloseChapterView;
        
        #line default
        #line hidden
        
        
        #line 504 "..\..\..\Pages\TextViewer_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listbox_Chapters;
        
        #line default
        #line hidden
        
        
        #line 516 "..\..\..\Pages\TextViewer_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border grid_slider;
        
        #line default
        #line hidden
        
        
        #line 519 "..\..\..\Pages\TextViewer_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider Slider_mediabar;
        
        #line default
        #line hidden
        
        
        #line 534 "..\..\..\Pages\TextViewer_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_ChapterView_ToLastFinalChapt;
        
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
            System.Uri resourceLocater = new System.Uri("/ImageTraveler;component/pages/textviewer_page.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\TextViewer_Page.xaml"
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
            this.grid_txtMainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.avalonTxt = ((ICSharpCode.AvalonEdit.TextEditor)(target));
            
            #line 466 "..\..\..\Pages\TextViewer_Page.xaml"
            this.avalonTxt.Loaded += new System.Windows.RoutedEventHandler(this.txtbox_viewr_Loaded);
            
            #line default
            #line hidden
            
            #line 467 "..\..\..\Pages\TextViewer_Page.xaml"
            this.avalonTxt.PreviewMouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.avalonTxt_MouseWheel);
            
            #line default
            #line hidden
            
            #line 468 "..\..\..\Pages\TextViewer_Page.xaml"
            this.avalonTxt.AddHandler(System.Windows.Controls.Primitives.ScrollBar.ScrollEvent, new System.Windows.Controls.Primitives.ScrollEventHandler(this.avalonTxt_Scroll));
            
            #line default
            #line hidden
            return;
            case 3:
            this.Grid_Chapter_Content = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.Btn_CloseChapterView = ((System.Windows.Controls.Button)(target));
            
            #line 492 "..\..\..\Pages\TextViewer_Page.xaml"
            this.Btn_CloseChapterView.Click += new System.Windows.RoutedEventHandler(this.Btn_CloseChapterView_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.listbox_Chapters = ((System.Windows.Controls.ListBox)(target));
            
            #line 508 "..\..\..\Pages\TextViewer_Page.xaml"
            this.listbox_Chapters.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.listbox_Chapters_Selected);
            
            #line default
            #line hidden
            return;
            case 6:
            this.grid_slider = ((System.Windows.Controls.Border)(target));
            return;
            case 7:
            this.Slider_mediabar = ((System.Windows.Controls.Slider)(target));
            return;
            case 8:
            this.Btn_ChapterView_ToLastFinalChapt = ((System.Windows.Controls.Button)(target));
            
            #line 539 "..\..\..\Pages\TextViewer_Page.xaml"
            this.Btn_ChapterView_ToLastFinalChapt.Click += new System.Windows.RoutedEventHandler(this.Btn_ChapterView_ToLastFinalChapt_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

