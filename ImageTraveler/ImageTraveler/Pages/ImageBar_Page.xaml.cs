using System;
using System.IO;
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
    /// ImageBar_Page.xaml 的互動邏輯
    /// </summary>
    public partial class ImageBar_Page : Page
    {
        Main_Command main_Command;        
        bool isDragging;
        double width, height, radius;        
        double[] L = new double[7];
        Point c;
        Point[] p = new Point[7];
        Point[] s = new Point[7];

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            width = Btn_Load.ActualWidth / 2;
            height = Btn_Load.ActualHeight / 2;

            //radius of button
            radius = Math.Sqrt(Math.Pow(width, 2) + Math.Pow(height, 2)) + 6;

            //Center of btn
            c.X = width;
            c.Y = height;
        }

        public ImageBar_Page(Main_Command main_Command)
        {
            InitializeComponent();

            isDragging = false;
            this.DataContext = main_Command;
            this.main_Command = main_Command;               
        }

        private void mediaTimeBar_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            isDragging = true;
        }

       

        private void mediaTimeBar_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            isDragging = false;
            //mediaElement.Position = TimeSpan.FromSeconds(Slider_mediabar.Value);            
        }

        private void Btn_group_MouseMove(object sender, MouseEventArgs e)
        {
            p[0] = e.GetPosition(Btn_Load);
            p[1] = e.GetPosition(Btn_Fit);
            p[2] = e.GetPosition(Btn_Previous);
            p[3] = e.GetPosition(Btn_Next);
            p[4] = e.GetPosition(Btn_Rotation);
            p[5] = e.GetPosition(Btn_Detele);
            p[6] = e.GetPosition(Btn_Fullscreen);

            for (int i = 0; i < 7; i++)
            {
                L[i]= Math.Sqrt(Math.Pow(p[i].X - c.X, 2) + Math.Pow(p[i].Y - c.Y, 2));

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
    }
}
