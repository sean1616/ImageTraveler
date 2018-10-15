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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using ImageTraveler.ViewModels;
using Microsoft.Win32;

namespace ImageTraveler.Pages
{
    /// <summary>
    /// Image_Page.xaml 的互動邏輯
    /// </summary>
    public partial class Image_Page : Page
    {
        Main_Command main_Command;

        public Image_Page(Main_Command main_Command)
        {
            InitializeComponent();

            this.DataContext = main_Command;
            this.main_Command = main_Command;
        }        
    }
}
