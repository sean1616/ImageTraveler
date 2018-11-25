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
using System.Windows.Media.Animation;
using ImageTraveler.ViewModels;

namespace ImageTraveler.Pages
{
    /// <summary>
    /// MediaBar_Page.xaml 的互動邏輯
    /// </summary>
    public partial class MediaBar_Page : Page
    {
        Main_Command main_Command;

        double width, height, radius;
        double[] L = new double[7];
        Point c;
        Point[] p = new Point[7];
        Point[] s = new Point[7];

        public MediaBar_Page(Main_Command main_Command)
        {
            InitializeComponent();

            this.DataContext = main_Command;
            this.main_Command = main_Command;
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
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
                //else
                //{
                //    p[i].X = 0;
                //}

                if (p[i].Y < 0)
                {
                    p[i].Y = Math.Pow(((p[i].Y - c.Y) / (2 * height)) + 0.5, 3);
                }
                else if (p[i].Y > 1)
                {
                    p[i].Y = Math.Pow(((p[i].Y - c.Y) / (2 * height)) - 0.5, 3) + 1;
                }
                //else
                //{
                //    p[i].Y = 0;
                //}

                //p[i].X = (p[i].X - c.X) / (2 * width) +0.5;
                //p[i].Y = (p[i].Y - c.Y) / (2 * height) +0.5;
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
            //if (Slider_volume.Maximum == 1)
            //{
            //    main_Command.mediaVolumeSaved = main_Command.media_Page.mediaElement.Volume;
            //    Slider_volume.Maximum = 0.2;
            //    main_Command.media_volume = 0.1;
            //}
            //else if (Slider_volume.Maximum == 0.2)
            //{
            //    Slider_volume.Maximum = 0;
            //    main_Command.media_volume = 0;
            //}
            //else
            //{
            //    Slider_volume.Maximum = 1;
            //    main_Command.media_volume = main_Command.mediaVolumeSaved;
            //}

            if (e.XButton1 == MouseButtonState.Pressed)
            {
                main_Command.mediaVolumeSaved_mode1 = main_Command.media_Page.mediaElement.Volume;
                Slider_volume.Maximum = 0.2;
                main_Command.media_volume = 0.1;
            }
            else if (e.XButton2 == MouseButtonState.Pressed)
            {
                Slider_volume.Maximum = 1;
                main_Command.media_volume = main_Command.mediaVolumeSaved_mode1;
            }
        }

        private void Btn_Load_MouseEnter(object sender, MouseEventArgs e)
        {
            main_Command.rec_brush_color = new Color[] { Colors.White, Colors.White, Colors.White };
        }

        private void Btn_Load_MouseLeave(object sender, MouseEventArgs e)
        {
            main_Command.rec_brush_color = new Color[] { Colors.Transparent, Colors.White, Color.FromArgb(50, 255, 255, 255) };
        }
        
        private void Slider_volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            main_Command.media_Page.mediaElement.Volume = Slider_volume.Value;
            volume_txt.Text = Math.Round(main_Command.media_volume * 100).ToString();
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
}
