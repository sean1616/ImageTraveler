﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using ImageTraveler.ViewModels;
using Microsoft.Win32;
using ImageTraveler.Utils;
using System.Collections.Generic;
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

            //aaa = main_Command.ini.IniReadValue("Bar", "volume", main_Command.ini_filename);
        }
                
        private void mediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
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
            timer.Interval = TimeSpan.FromMilliseconds(40);
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

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!main_Command.isDragging)
            {
                //動態更新media slider bar
                //main_Command.mediaBar_Page.Slider_mediabar.Value = mediaElement.Position.TotalSeconds;
                main_Command.mediaTimePosition = mediaElement.Position.TotalSeconds;
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
