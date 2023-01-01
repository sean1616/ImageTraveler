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
using ImageTraveler.Utils;

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

            //string chap_content = "";

            for (int i = 0; i < main_Command.chapter_dictionary.Count; i++)
            {
                string chap_content = main_Command.chapter_dictionary[i][1].Trim().Replace("\n", "").Replace("\r", "");
                int iii = chap_content.Length;
                if (!string.IsNullOrEmpty(chap_content))
                    listbox_Chapters.Items.Add(chap_content);
                //listbox_Chapters.Items.Add(chap_content.Substring(0,14));
            }
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

       

        private void listbox_Chapters_Selected(object sender, RoutedEventArgs e)
        {
            var obj = listbox_Chapters.SelectedItem;
            int selected_Chapter_Index = listbox_Chapters.SelectedIndex;
            if (selected_Chapter_Index < 0) return;
            string s = main_Command.chapter_dictionary[selected_Chapter_Index][0];
            if(!string.IsNullOrEmpty(s))
            {
                int index = int.Parse(s);

                //avalonTxt.ScrollToLine(index); //Txt content jump to the selected chapter position

                //await Task.Delay(200);

                //main_Command.TxtViewer_Position = avalonTxt.VerticalOffset;
                main_Command.TxtVerJumpToLine(index);

            }

        }

        private void Btn_CloseChapterView_Click(object sender, RoutedEventArgs e)
        {
            main_Command.bool_txtChapter = !main_Command.bool_txtChapter;

            GridLengthAnimation gla = new GridLengthAnimation();  //Custom Animation Class
            gla.From = new GridLength(main_Command.bool_txtChapter ? 0 : 1.5, GridUnitType.Star);
            gla.To = new GridLength(main_Command.bool_txtChapter ? 1.5 : 0, GridUnitType.Star); ;
            gla.Duration = new TimeSpan(0, 0, 0, 0, 100);
            main_Command.textViewer_Page.grid_txtMainGrid.ColumnDefinitions[0].BeginAnimation(ColumnDefinition.WidthProperty, gla);
        }

        private void Btn_ChapterView_ToLastFinalChapt_Click(object sender, RoutedEventArgs e)
        {
            //listbox_Chapters.se = 20;
            listbox_Chapters.Items.MoveCurrentToLast();
            listbox_Chapters.ScrollIntoView(listbox_Chapters.Items.CurrentItem);
        }

        
    }
}
