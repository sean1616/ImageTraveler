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
using ImageTraveler.ViewModels;

namespace ImageTraveler.Pages
{
    /// <summary>
    /// TextViewer_Page.xaml 的互動邏輯
    /// </summary>
    public partial class TextViewer_Page : Page
    {
        Main_Command main_Command;
        public TextViewer_Page(Main_Command main_Command)
        {
            InitializeComponent();

            this.main_Command = main_Command;

            this.DataContext = main_Command;
        }

        private void txtbox_viewr_Loaded(object sender, RoutedEventArgs e)
        {
            main_Command.UpdateTextViewer();
            avalonTxt.Text = main_Command.txtbox_content;
        }

        private void avalonTxt_TextChanged(object sender, EventArgs e)
        {
        }

        private void avalonTxt_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            txt_process_msg();
        }

        private void avalonTxt_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            txt_process_msg();
        }

        private void txt_process_msg()
        {
            main_Command.mediaTimePosition =
                main_Command.textViewer_Page.avalonTxt.VerticalOffset / main_Command.textViewer_Page.avalonTxt.ExtentHeight * 500;
           
        }
    }
}
