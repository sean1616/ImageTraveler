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
using System.Windows.Threading;
using ImageTraveler.Utils;
using ImageTraveler.ViewModels;
using System.Windows.Media.Animation;

namespace ImageTraveler.Pages
{
    /// <summary>
    /// TextViewerBar_Page.xaml 的互動邏輯
    /// </summary>
    public partial class TextViewerBar_Page : Page
    {
        Main_Command main_Command;
        
        double txtline_count = 0;

        Storyboard sb;

        public TextViewerBar_Page(Main_Command main_Command)
        {
            InitializeComponent();

            this.main_Command = main_Command;
            this.DataContext = main_Command;

            main_Command.tm = new DispatcherTimer();
            main_Command.tm.Interval = TimeSpan.FromSeconds(0.1/ main_Command.media_speed);
            main_Command.tm.Tick += Tm_Tick; ;

            sb = this.FindResource("Btn_group_StoryBoard1") as Storyboard;
        }

        private void Tm_Tick(object sender, EventArgs e)
        {
            main_Command.TxtViewer_Position += 0.5;  //defaul:2

            main_Command.textViewer_Page.avalonTxt.ScrollToVerticalOffset(main_Command.TxtViewer_Position);

        }

        double width, height, radius;
        double[] L = new double[7];
        Point c;
        Point[] p = new Point[7];
        Point[] s = new Point[7];

        private void BackBorer_MouseMove(object sender, MouseEventArgs e)
        {
            p[0] = e.GetPosition(Btn_Load);
            p[1] = e.GetPosition(Btn_Stop);
            p[2] = e.GetPosition(Btn_Back);
            p[3] = e.GetPosition(Btn_paly_pause);
            p[4] = e.GetPosition(Btn_Jump);
            p[5] = e.GetPosition(rectangle);
            p[6] = e.GetPosition(Btn_fullscreen);

            for (int i = 0; i < 7; i++)
            {
                L[i] = Math.Sqrt(Math.Pow(p[i].X - c.X, 2) + Math.Pow(p[i].Y - c.Y, 2));

                s[i].X = (c.X + ((c.X - p[i].X) / L[i]) * radius) / radius;
                s[i].Y = (c.X + ((c.Y - p[i].Y) / L[i]) * radius) / radius;

                if (p[i].X < 0)
                {
                    p[i].X = Math.Pow(((p[i].X - c.X) / (2 * width)) + 0.5, 3);
                }
                else if (p[i].X > 1)
                {
                    p[i].X = Math.Pow(((p[i].X - c.X) / (2 * width)) - 0.5, 3) + 1;
                }

                if (p[i].Y < 0)
                {
                    p[i].Y = Math.Pow(((p[i].Y - c.Y) / (2 * height)) + 0.5, 3);
                }
                else if (p[i].Y > 1)
                {
                    p[i].Y = Math.Pow(((p[i].Y - c.Y) / (2 * height)) - 0.5, 3) + 1;
                }
            }

            main_Command.Posi = p;
            main_Command.sPosi = s;
        }

        private void grid_slider_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            main_Command.sliderThumb_size = grid_slider.ActualHeight;
        }

        double percentage = 0;
        private void Slider_mediabar_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var slider_ActualWidth = Slider_mediabar.ActualWidth;

            //相對於視窗中的滑鼠位置
            var point = e.MouseDevice.GetPosition(Slider_mediabar);

            //計算滑鼠在Slider X方向上的位置(以百分比計算)
            percentage = (point.X / slider_ActualWidth);

            //移動slider至滑鼠位置
            Slider_mediabar.Value = percentage * Slider_mediabar.Maximum;
        }

        private void Slider_mediabar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {           
            percentage = (Slider_mediabar.Value / 500);

            double value = main_Command.textViewer_Page.avalonTxt.ExtentHeight * percentage;
            main_Command.textViewer_Page.avalonTxt.ScrollToVerticalOffset(value);

            main_Command.TxtViewer_Position = value;

            //Save to ini
            string NovelName = main_Command.fileName.Replace(".txt", "");

            if (!string.IsNullOrEmpty(NovelName))
                main_Command.ini.IniWriteValue("Novel_" + NovelName, "TxtViewer_Position", main_Command.TxtViewer_Position.ToString(), main_Command.ini_filename);


            main_Command.mediaBar_mediaDurationTime = string.Format("{0}%", Math.Round(percentage * 100, 2).ToString());
        }

        private void mediaTimeBar_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            main_Command.isDragging = true;
        }

        private void mediaTimeBar_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            main_Command.isDragging = false;
        }

        StackPanel focuseScope2 = new StackPanel();
        private void txt_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox obj = (TextBox)sender;
            obj.Background = new SolidColorBrush(Colors.Black);
        }

        private void txt_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox obj = (TextBox)sender;
            obj.Background = new SolidColorBrush(Colors.Transparent);

            FocusManager.SetIsFocusScope(focuseScope2, true);
            Keyboard.Focus(focuseScope2);
        }

        bool _isPlayOrPause = false;
        private void Btn_paly_pause_Click(object sender, RoutedEventArgs e)
        {
            if (!_isPlayOrPause)
            {
                main_Command.tm.Interval = TimeSpan.FromSeconds(0.1 / main_Command.txt_rolling_speed);

                txtline_count = main_Command.TxtViewer_Position;
                main_Command.tm.Start();

                main_Command.mediaBtn_play_pause = "../Resources/pause.png";
            }
            else
            {
                string NovelName = main_Command.fileName.Replace(".txt", "");

                if (!string.IsNullOrEmpty(NovelName))
                    main_Command.ini.IniWriteValue("Novel_" + NovelName, "TxtViewer_Position", main_Command.TxtViewer_Position.ToString(), main_Command.ini_filename);

                main_Command.tm.Stop();

                main_Command.mediaBtn_play_pause = "../Resources/下_1.png";

            }
            _isPlayOrPause = !_isPlayOrPause;
        }

        private void Btn_Stop_Click(object sender, RoutedEventArgs e)
        {
            main_Command.textViewer_Page.avalonTxt.ScrollToLine(main_Command.textViewer_Page.avalonTxt.LineCount);
        }

        private void Btn_Chapter_Click(object sender, RoutedEventArgs e)
        {
            

            //Animation of the Grid width of the chapter view
            //Because the Grid width (Height) is not a animation supported property
            //It can't setting by Blender

            GridLengthAnimation gla = new GridLengthAnimation();  //Custom Animation Class
            gla.From = new GridLength(main_Command.bool_txtChapter ? 0 : 1.5, GridUnitType.Star);
            gla.To = new GridLength(main_Command.bool_txtChapter ? 1.5 : 0, GridUnitType.Star); ;
            gla.Duration = new TimeSpan(0, 0, 0, 0, 100);
            main_Command.textViewer_Page.grid_txtMainGrid.ColumnDefinitions[0].BeginAnimation(ColumnDefinition.WidthProperty, gla);
        }

        private void grid_MouseEnter(object sender, MouseEventArgs e)
        {
            if (main_Command.isBarAnimation)
                sb.Begin();
        }

        private void Media_Speed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox obj = (TextBox)sender;
                main_Command.media_speed = double.Parse(obj.Text);

                main_Command.media_Page.grid_mediaElement.Focus();

                main_Command.bool_mediaSpeed = false;
            }
        }

        private void BackBorer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            main_Command.bool_mediaSpeed = false;
        }
    }
}
