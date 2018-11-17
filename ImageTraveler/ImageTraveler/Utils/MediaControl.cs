using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;
using ImageTraveler.ViewModels;

namespace ImageTraveler.Utils
{
    public class MediaControl
    {
        private Main_Command main_Command;

        TimeSpan timeSpan = new TimeSpan(0, 0, 5);
        
        DispatcherTimer timer_show;

        Duration mediaNaturalDuration;

        double mediaDurationHours;
        string mediaDuration;

        public MediaControl(Main_Command main_Command)
        {
            this.main_Command = main_Command;
        }

        #region MediaElement
              
        public void MediaPlay()
        {
            Thread.Sleep(100); //let animate start first.
            main_Command.media_Page.mediaElement.Play();
            //main_Command.media_Page.vlcPlayer.Play();
            main_Command.mediaState = true;
            main_Command.mediaBtn_play_pause = "../Resources/pause.png";
        }

        public void MediaPause()
        {
            main_Command.media_Page.mediaElement.Pause();
            //main_Command.media_Page.vlcPlayer.Pause();
            main_Command.mediaState = false;
            main_Command.mediaBtn_play_pause = "../Resources/下_1.png";
        }

        public void MediaJumpTo()
        {
            main_Command.media_Page.mediaElement.Position += timeSpan;
            //main_Command.media_Page.vlcPlayer.Position += timeSpan;
        }

        public void MediaBackTo()
        {
            main_Command.media_Page.mediaElement.Position -= timeSpan;
            //main_Command.media_Page.vlcPlayer.Position -= timeSpan;
        }
        #endregion

        #region VLC Player
        public void VLC_Setting()
        {
            //時間顯示timer
            timer_show = new DispatcherTimer();
            timer_show.Interval = TimeSpan.FromSeconds(1);

            //取得媒體總時間
            TimeSpan t = TimeSpan.FromSeconds(0);               
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
        }

        //Timer Setting
        private void timer_show_Tick(object sender, EventArgs e)
        {
            if (!main_Command.isDragging)
            {
                //TimeSpan t = TimeSpan.FromSeconds(Math.Round(main_Command.vlc_Page.vlcPlayer.Position* mediaNaturalDuration.TimeSpan.TotalSeconds));
                //main_Command.mediaBar_mediaDurationTime = string.Format("{0} / " + mediaDuration, t.ToString(@"mm\:ss"));
            }
        }

        //Timer Setting2
        private void timer_show_Tick_Hours(object sender, EventArgs e)
        {
            if (!main_Command.isDragging)
            {
                //TimeSpan t = TimeSpan.FromSeconds(Math.Round(main_Command.vlc_Page.vlcPlayer.Position * mediaNaturalDuration.TimeSpan.TotalSeconds));
                //main_Command.mediaBar_mediaDurationTime = string.Format("{0} / " + mediaNaturalDuration.ToString(), t.ToString(@"hh\:mm\:ss"));
            }
        }
        #endregion
                
        private void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            var viewModel = main_Command;
            if (viewModel.MediaEndedCommand.CanExecute(null))
                viewModel.MediaEndedCommand.Execute(null);
        }
    }
}
