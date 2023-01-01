using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.Ports;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Runtime.InteropServices;
using ImageTraveler.ViewModels;
using System.Globalization;

namespace ImageTraveler.Pages
{
    /// <summary>
    /// MediaBar_Page.xaml 的互動邏輯
    /// </summary>
    public partial class MediaBar_Page : Page
    {
        Main_Command main_Command;
        public static SetupIniIP ini = new SetupIniIP();

        double width, height, radius;
        double[] L = new double[7];
        Point c;
        Point[] p = new Point[7];
        Point[] s = new Point[7];
        
        string s_arduinoRecord = "";
        
        public MediaBar_Page(Main_Command main_Command)
        {
            InitializeComponent();

            this.DataContext = main_Command;
            this.main_Command = main_Command;
                       
            main_Command.port_Arduino = new SerialPort("COM8", 9600);
            main_Command.timer_Arduino = new System.Timers.Timer();
            main_Command.timer_Arduino.Interval = 200;
            main_Command.timer_Arduino.Elapsed += TimerArduino_Elapsed;
                       
        }
                       
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            width = Btn_Load.ActualWidth / 2;
            height = Btn_Load.ActualHeight / 2;

            //radius of button
            radius = Math.Sqrt(Math.Pow(width, 2) + Math.Pow(height, 2)) + 6;

            //Center of btn
            c.X = width;
            c.Y = height;

            //動態改變storyboard的特性值
            EasingDoubleKeyFrame keyFrame = ((this.Resources["Bar_Volumn"]
                as Storyboard).Children[1]
                as DoubleAnimationUsingKeyFrames).KeyFrames[0]
                as EasingDoubleKeyFrame;

            keyFrame.Value = Slider_volume.ActualWidth * -1;

            EasingDoubleKeyFrame keyFrame2 = ((this.Resources["Bar_Volumn_mouse_leave"]
                as Storyboard).Children[1]
                as DoubleAnimationUsingKeyFrames).KeyFrames[0]
                as EasingDoubleKeyFrame;

            keyFrame2.Value = Slider_volume.ActualWidth * -1;

            //await main_Command.mediaVolume_ReadArduino();   //開始讀Arduino旋鈕
        }

        private void TimerArduino_Elapsed(object sender, ElapsedEventArgs e)
        {
            string s = main_Command.port_Arduino.ReadLine();

            s = s.Replace("\r", "");

            main_Command.media_volume = Convert.ToInt32(s) * 100 / 378;

            //Action methodDelegate = delegate ()
            //{
            //    //if (s != s_arduinoRecord)
            //        main_Command.media_volume = Convert.ToInt32(s) * 100 / 378;
            //};
            //this.Dispatcher.BeginInvoke(methodDelegate);

            s_arduinoRecord = s;
        }

        private void mediaTimeBar_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            main_Command.isDragging = true;
        }

        private void mediaTimeBar_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            main_Command.isDragging = false;
            main_Command.media_Page.mediaElement.Position = TimeSpan.FromSeconds(Slider_mediabar.Value);
        }

        private void Slider_mediabar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            main_Command.media_Page.mediaElement.Position = TimeSpan.FromSeconds(Slider_mediabar.Value);            
        }

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

        private void Btn_volume_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.XButton1 == MouseButtonState.Pressed)
            {
                main_Command.mediaVolumeSaved_mode1 = main_Command.media_Page.mediaElement.Volume;
                Slider_volume.Maximum = 0.1;
                main_Command.media_volume = 0.05;
            }
            else if (e.XButton2 == MouseButtonState.Pressed)
            {
                Slider_volume.Maximum = 1;
                main_Command.media_volume = main_Command.mediaVolumeSaved_mode1;
            }
        }

        private void Btn_Load_MouseEnter(object sender, MouseEventArgs e)
        {            
            //main_Command.rec_brush_color = new Color[] { Colors.White, Colors.White, Colors.White };
        }

        private void Btn_Load_MouseLeave(object sender, MouseEventArgs e)
        {
            //main_Command.rec_brush_color = new Color[] { Colors.Transparent, Colors.White, Color.FromArgb(50, 255, 255, 255) };
        }

        // Creating a FocusNavigationDirection object and setting it to a
        // local field that contains the direction selected.
        FocusNavigationDirection focusDirection = new FocusNavigationDirection();

        private void Volume_txtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox obj = (TextBox)sender;
                //main_Command.media_volume = double.Parse(obj.Text);
                //volume_txt.Text = main_Command.media_volume.ToString();
                string a = main_Command.media_volume.ToString();
                string b = obj.Text;

                main_Command.media_Page.grid_mediaElement.Focus();               
            }
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
                       
        private void BackBorer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            main_Command.bool_mediaSpeed = false;
        }

       

        private void Media_Speed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox obj = (TextBox)sender;
                main_Command.media_speed = double.Parse(obj.Text);

                main_Command.media_Page.grid_mediaElement.Focus();

                main_Command.bool_mediaSpeed = false;

                //main_Command.MediaSpeed_sliderVisible = Visibility.Collapsed;

                //grid_slider.Visibility = Visibility.Visible;              
            }
        }

        //mediabar position jump to mouse position
        private void Slider_mediabar_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var slider_ActualWidth = Slider_mediabar.ActualWidth;

            //相對於視窗中的滑鼠位置
            var point = e.MouseDevice.GetPosition(Slider_mediabar);

            //計算滑鼠在Slider X方向上的位置(以百分比計算)
            var percentOfpoint = (point.X / slider_ActualWidth);

            //移動slider至滑鼠位置
            Slider_mediabar.Value = percentOfpoint * Slider_mediabar.Maximum;

            main_Command.media_Page.mediaElement.Position = TimeSpan.FromSeconds(Slider_mediabar.Value);
        }
    }

    public class SetupIniIP
    {
        public string path;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string section,
        string key, string val, string filePath);
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section,
        string key, string def, StringBuilder retVal,
        int size, string filePath);

        //ini write
        public void IniWriteValue(string Section, string Key, string Value, string inipath)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "ImagTraver\\" + inipath;
            WritePrivateProfileString(Section, Key, Value, path);
        }

        //ini read
        public string IniReadValue(string Section, string Key, string inipath)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "ImagTraver\\" + inipath;
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, path);
            return temp.ToString();
        }
    }

    public class DoubleToString_Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            value = (double)value;
            string str = value.ToString();

            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
