using System;
using System.IO;
using System.IO.Ports;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Text.RegularExpressions;

using ImageTraveler.ViewModels;
using Microsoft.Win32;
using ImageTraveler.Utils;
using ImageTraveler.Subtitle;

namespace ImageTraveler.Pages
{
    /// <summary>
    /// Media_Page.xaml 的互動邏輯
    /// </summary>
    public partial class Media_Page : Page
    {
        Main_Command main_Command;

        DispatcherTimer timer, timer_show;
                
        Duration mediaNaturalDuration;

        LoadFileClass loadFileClass;

        FormattedText formattedText;

        List<SrtModel> srtModel;

        double mediaDurationHours;
        string mediaDuration, sub_path, sub_name;
        bool is_drag_to_control_media = false;
        Point click_position, new_position;

        

        public Media_Page(Main_Command main_Command)
        {
            InitializeComponent();

            this.DataContext = main_Command;
            this.main_Command = main_Command;

            Arduino_Setting();   //Arduino rotator連線設定
        }

        private async void Arduino_Setting()
        {
            await Task.Run(() =>
            {
                try
                {
                    var searcher = new ManagementObjectSearcher("SELECT DeviceID,Caption FROM WIN32_SerialPort");

                    foreach (ManagementObject port in searcher.Get())  //取得所有Comport / Comport名稱
                    {
                        string description = port.GetPropertyValue("Caption").ToString();
                        // ex: Arduino Uno (COM7)                    

                        string[] port_description = description.Split(' ');
                        List<string> list_description = new List<string>(port_description);
                        if (list_description.Contains("Arduino"))
                        {
                            // ex: COM7
                            string comport = port.GetPropertyValue("DeviceID").ToString();
                            main_Command.port_Arduino = new SerialPort(comport, 9600);
                            break;
                        }
                    }                    

                    main_Command.port_Arduino.Open();

                    main_Command.port_Arduino.DiscardInBuffer();
                    main_Command.port_Arduino.DiscardOutBuffer();

                    main_Command.port_Arduino.Write("0");

                    Task.Delay(100);

                    string port_read= main_Command.port_Arduino.ReadLine();

                    if (port_read.Replace("\r", "") == "Rotator")
                    {
                        main_Command.port_Arduino.Write("1");
                        Task.Delay(100);
                        _isPort_Arduino_Open = true;
                    }                        
                    else _isPort_Arduino_Open = false;
                }
                catch { _isPort_Arduino_Open = false; }
            });
        }
                
        private void mediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            mediaElement.Volume = main_Command.media_volume / 100;

            //設定視窗為影片原始寬高
            //App.mainWindow.Height = mediaElement.NaturalVideoHeight;
            //App.mainWindow.Width = mediaElement.NaturalVideoWidth;

            //設定視窗至螢幕中央
            Rect workArea = System.Windows.SystemParameters.WorkArea;
            var height_dif = workArea.Height - App.mainWindow.Height;
            var width_dif = workArea.Width - App.mainWindow.Width;
            if (height_dif >= 0 && width_dif >= 0)
            {
                App.mainWindow.Left = (workArea.Width - App.mainWindow.Width) / 2 + workArea.Left;
                App.mainWindow.Top = (workArea.Height - App.mainWindow.Height) / 2 + workArea.Top;
            }
            else
            {
                //取得可獲得之工作視窗大小(不含工作列)                
                App.mainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight; var a = SystemParameters.WorkArea;
                App.mainWindow.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
                main_Command.windowState = WindowState.Maximized;
            }

            //時間顯示timer
            timer_show = new DispatcherTimer();
            timer_show.Interval = TimeSpan.FromSeconds(1);
            
            //取得媒體總時間
            TimeSpan t = TimeSpan.FromSeconds(0);
            mediaNaturalDuration = mediaElement.NaturalDuration;
            //mediaNaturalDuration = vlcPlayer.VlcMediaPlayer.Length;
            mediaDurationHours = mediaNaturalDuration.TimeSpan.TotalHours; //總時數
            
            if (mediaDurationHours >= 1)
            {
                mediaDuration = mediaNaturalDuration.ToString();
                main_Command.mediaBar_mediaDurationTime = string.Format("{0} / " + mediaDuration, t.ToString(@"hh\:mm\:ss"));
                
                timer_show.Tick += new EventHandler(timer_show_Tick_Hours);
                timer_show.Start();
            }
            else
            {
                mediaDuration = mediaNaturalDuration.TimeSpan.ToString(@"mm\:ss");
                main_Command.mediaBar_mediaDurationTime = string.Format("{0} / " + mediaDuration, t.ToString(@"mm\:ss"));
                timer_show.Tick += new EventHandler(timer_show_Tick);

                timer_show.Start();
            }             

            //時間軸timer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(120);
            timer.Tick += new EventHandler(timer_Tick);

            if (mediaElement.NaturalDuration.HasTimeSpan)
            {
                TimeSpan ts = mediaElement.NaturalDuration.TimeSpan;
                main_Command.mediaBar_Page.Slider_mediabar.Maximum = ts.TotalSeconds;
                main_Command.mediaBar_Page.Slider_mediabar.SmallChange = 0.01;
                main_Command.mediaBar_Page.Slider_mediabar.LargeChange = Math.Min(10, ts.Seconds / 10);
            }
            timer.Start();            
        }

        bool _isPort_Arduino_Open = false;
        string savedArduinoValue = "";
        private void timer_Tick(object sender, EventArgs e)
        {
            if (!main_Command.isDragging)
            {
                //動態更新media slider bar
                //main_Command.mediaBar_Page.Slider_mediabar.Value = mediaElement.Position.TotalSeconds;
                main_Command.mediaTimePosition = mediaElement.Position.TotalSeconds;

                if (_isPort_Arduino_Open)
                {
                    #region 分析Arduino讀回訊息
                    string s = main_Command.port_Arduino.ReadLine();
                    
                    s = s.Replace("\r", "");
                    if (string.IsNullOrEmpty(s)) return;

                    int result = 1;
                    int.TryParse(s, out result);  //失敗為0，成功為1
                    if (result == 0) return;

                    if (savedArduinoValue != s) main_Command.media_volume = Convert.ToInt32(s) * 100 / 378;

                    savedArduinoValue = s;
                    #endregion
                }
            }
        }
                
        private void timer_show_Tick(object sender, EventArgs e)
        {
            if (!main_Command.isDragging)
            {
                TimeSpan t = TimeSpan.FromSeconds(Math.Round(mediaElement.Position.TotalSeconds));
                main_Command.mediaBar_mediaDurationTime = string.Format("{0} / " + mediaDuration, t.ToString(@"mm\:ss"));

                subtitle_calculator();
            }
        }

        private void timer_show_Tick_Hours(object sender, EventArgs e)
        {
            if (!main_Command.isDragging)
            {
                TimeSpan t = TimeSpan.FromSeconds(Math.Round(mediaElement.Position.TotalSeconds));
                main_Command.mediaBar_mediaDurationTime = string.Format("{0} / " + mediaNaturalDuration.ToString(), t.ToString(@"hh\:mm\:ss"));
                                
                subtitle_calculator();
            }
        }

        private void subtitle_calculator()
        {
            if (srtModel != null)
            {
                int timeMiles = (int)main_Command.mediaTimePosition * 1000 + 800;

                string timeString = SrtHelper.GetTimeString(timeMiles);

                Subtitle_TextBlock.Text = timeString;
            }
        }

        private void mediaElement_BufferingEnded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("123");
            //main_Command.media_Page.mediaElement.Play();
        }

        private void mediaElement_Loaded(object sender, RoutedEventArgs e)
        {            
            //設定視窗為影片原始寬高
            //App.mainWindow.Height = mediaElement.NaturalVideoHeight;
            //App.mainWindow.Width = mediaElement.NaturalVideoWidth;

            //取得可獲得之工作視窗大小(不含工作列)                
            App.mainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight; var a = SystemParameters.WorkArea;
            App.mainWindow.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;

            //設定視窗至螢幕中央
            Rect workArea = System.Windows.SystemParameters.WorkArea;
            var height_dif = workArea.Height - App.mainWindow.Height;
            var width_dif = workArea.Width - App.mainWindow.Width;
            if (height_dif >= 0 && width_dif >= 0)
            {
                App.mainWindow.Left = (workArea.Width - App.mainWindow.Width) / 2 + workArea.Left;
                App.mainWindow.Top = (workArea.Height - App.mainWindow.Height) / 2 + workArea.Top;
            }
            else
            {
                //取得可獲得之工作視窗大小(不含工作列)                
                App.mainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
                //a = SystemParameters.WorkArea;
                App.mainWindow.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
                main_Command.windowState = WindowState.Maximized; 
            }

            main_Command.media_Page.mediaElement.Play(); //在大影片開始前先做視窗調整的動作可先對其進行提前緩衝，原因不明
        }

        private void mediaElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            is_drag_to_control_media = true;
            click_position = Mouse.GetPosition(this);
        }
        
        private static Regex unit = new Regex(
            @"(?<sequence>\d+)\r\n(?<start>\d{2}\:\d{2}\:\d{2},\d{3}) --\> (?<end>\d{2}\:\d{2}\:\d{2},\d{3})\r\n(?<text>[\s\S]*?\r\n\r\n)",
            RegexOptions.Compiled | RegexOptions.ECMAScript);

        private void MenuItem_tune_subtitle_Click(object sender, RoutedEventArgs e)
        {
            string[] args = new string[] { "///", "" };

                if (args.Length != 1)
                throw new ArgumentException("filename is missing");

            if (!File.Exists(args[0]))
                throw new FileNotFoundException("file not found", args[0]);

            int sequence = 1;
            double offset = 0;
            Console.Write("offset, in seconds (+1.1, -2.75): ");
            while (!Double.TryParse(Console.ReadLine(), out offset))
            {
                Console.WriteLine("Invalid value, try again");
            }

            using (StreamReader file = new StreamReader(args[0], Encoding.Default))
            {
                using (StreamWriter output = new StreamWriter(args[0] + ".srt", false, Encoding.Default))
                {
                    output.Write(
                        unit.Replace(file.ReadToEnd(), delegate (Match m)
                        {
                            return m.Value.Replace(
                                String.Format("{0}\r\n{1} --> {2}\r\n",
                                    m.Groups["sequence"].Value,
                                    m.Groups["start"].Value,
                                    m.Groups["end"].Value),
                                String.Format("{0}\r\n{1:HH\\:mm\\:ss\\,fff} --> {2:HH\\:mm\\:ss\\,fff}\r\n",
                                    sequence++,
                                    DateTime.Parse(m.Groups["start"].Value.Replace(",", ".")).AddSeconds(offset),
                                    DateTime.Parse(m.Groups["end"].Value.Replace(",", ".")).AddSeconds(offset)));
                        }));
                }
            }
            Console.WriteLine("Done ({0} units).", sequence);


        }

        private void mediaElement_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (is_drag_to_control_media == true)
            {
                if (new_position.X - click_position.X > 50)
                {
                    var viewModel = (Main_Command)DataContext;
                    if (viewModel.NextCommand.CanExecute(null))
                        viewModel.NextCommand.Execute(null);
                }
                else if (new_position.X - click_position.X < -50)
                {
                    var viewModel = (Main_Command)DataContext;
                    if (viewModel.PreCommand.CanExecute(null))
                        viewModel.PreCommand.Execute(null);
                }
                is_drag_to_control_media = false;
            }
            
        }
        
        private void MenuItem_Subtitle_Click(object sender, RoutedEventArgs e)
        {
            loadFileClass = new LoadFileClass();

            //取得對話框訊息
            OpenFileDialog fileDialog = loadFileClass.openFileDialog();

            if (string.IsNullOrEmpty(fileDialog.FileName))
                return;

            //取得完整路徑
            sub_path = fileDialog.FileName;
            //取得檔名
            sub_name = fileDialog.SafeFileName;

            srtModel = SrtHelper.ParseSrt(sub_path);

            int timeMiles = (int)main_Command.mediaTimePosition * 1000;

            string timeString = SrtHelper.GetTimeString(timeMiles);

            Subtitle_TextBlock.Text = timeString;
        }

        private void mediaElement_MouseMove(object sender, MouseEventArgs e)
        {
            if (is_drag_to_control_media == true)
            {
                new_position = Mouse.GetPosition(this);               
            }
        }

        private void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            var viewModel = (Main_Command)DataContext;
            if (viewModel.MediaEndedCommand.CanExecute(null))
                viewModel.MediaEndedCommand.Execute(null);
        }                     
    }
}
