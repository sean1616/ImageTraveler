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
using System.Text.RegularExpressions;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.Windows.Threading;
using Microsoft.Expression.Interactivity.Input;
using ImageTraveler.ViewModels;
using ImageTraveler.Pages;
using System.Windows.Media.Animation;
using System.Runtime.InteropServices;

namespace ImageTraveler
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {        
        public static Main_Command main_Command { get; set; } = new Main_Command();        
        public static int aa;
        bool isDragging = false, media_state_check=false;      
        DispatcherTimer mousemove_timer;
        Point mouse_position;
        string ini_path = System.AppDomain.CurrentDomain.BaseDirectory;
        public string ini_filename = "ImagTraver.ini";
        public static SetupIniIP ini = new SetupIniIP();

        public MainWindow()
        {
            InitializeComponent();
            
            main_Command = (Main_Command)DataContext;
                        
            //時間軸timer
            mousemove_timer = new DispatcherTimer();
            mousemove_timer.Interval = TimeSpan.FromSeconds(4);
            mousemove_timer.Tick += new EventHandler(timer_Tick);

            mousemove_timer.Start();
            
            //string ini_path = main_Command.folderName + @"\" + main_Command.ini_filename;
            if (File.Exists(ini_path + "ImagTraver\\ImagTraver.ini"))
            {
                //讀取ini media volume
                main_Command.media_volume = Convert.ToDouble(main_Command.ini.IniReadValue("Bar", "volume", main_Command.ini_filename));
                this.Height = Convert.ToDouble(main_Command.ini.IniReadValue("Window", "Height", main_Command.ini_filename));
                this.Width = Convert.ToDouble(main_Command.ini.IniReadValue("Window", "Width", main_Command.ini_filename));
            }
            else
            {
                Directory.CreateDirectory(main_Command.folderName);  //建立資料夾      
                IniSetup(); //創建ini file並寫入基本設定
            }
               
        }

        //泛型初始化
        public MainWindow(string args)
        {
            InitializeComponent();
            
            main_Command = (Main_Command)DataContext;

            main_Command.media_volume = Convert.ToDouble(main_Command.ini.IniReadValue("Bar", "volume", main_Command.ini_filename));

            //圖片路徑、檔名、輸入狀態設定
            main_Command.imgPath = args;
            main_Command.fileName = Path.GetFileName(args);
            main_Command.fileName_Extension = Path.GetExtension(args);
            main_Command.ArgsInput = true;

            //時間軸timer
            mousemove_timer = new DispatcherTimer();
            mousemove_timer.Interval = TimeSpan.FromSeconds(2.2);
            mousemove_timer.Tick += new EventHandler(timer_Tick);

            mousemove_timer.Start();

            //string ini_path = main_Command.folderName + @"\" + main_Command.ini_filename;
            if (File.Exists(ini_path + "ImagTraver\\ImagTraver.ini"))
            {
                //讀取ini media volume
                main_Command.media_volume = Convert.ToDouble(main_Command.ini.IniReadValue("Bar", "volume", main_Command.ini_filename));
                //this.Height = Convert.ToDouble(main_Command.ini.IniReadValue("Window", "Height", main_Command.ini_filename));
                //this.Width = Convert.ToDouble(main_Command.ini.IniReadValue("Window", "Width", main_Command.ini_filename));                
            }
            else
            {
                Directory.CreateDirectory(main_Command.folderName);  //建立資料夾      
                IniSetup(); //創建ini file並寫入基本設定
                
            }
        }

        //Cursor disappear if mouse stay over 4 sec
        private void timer_Tick(object sender, EventArgs e)
        {
            var mp = Mouse.GetPosition(this);
            if (mouse_position == mp)
                Mouse.OverrideCursor = Cursors.None;
            else
                mouse_position = Mouse.GetPosition(this);
        }
        
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void Btn_Pointer_Click(object sender, RoutedEventArgs e)
        {
            main_Command.EditingMode = InkCanvasEditingMode.None; //修改inkcanvas 模式
            main_Command.zIndex_group[1] = 0;
        }
                       
        private void inkCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Escape)
            //    this.inkCanvas.EditingMode = InkCanvasEditingMode.None;
        }

        public void ExportToPng(string path, Image surface)
        {
            if (path == null) return;

            // Save current canvas transform
            Transform transform = surface.LayoutTransform;
            // reset current transform (in case it is scaled or rotated)
            surface.LayoutTransform = null;

            // Get the size of canvas
            Size size = new Size(surface.ActualWidth, surface.ActualHeight);
            // Measure and arrange the surface
            // VERY IMPORTANT
            surface.Measure(size);
            surface.Arrange(new Rect(size));

            // Create a render bitmap and push the surface to it
            RenderTargetBitmap renderBitmap =
              new RenderTargetBitmap(
                (int)size.Width,
                (int)size.Height,
                96d,
                96d,
                PixelFormats.Pbgra32);
            renderBitmap.Render(surface);

            String filePath;
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "圖片文件(*.jpg;*.bmp;*.png)|*.jpg;*.bmp;*.png|(All file(*.*)|*.*";
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (fileDialog.ShowDialog() == true)
            {
                filePath = fileDialog.FileName;
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    encoder.Save(stream);
            }                        

            // Restore previously saved layout
            surface.LayoutTransform = transform;
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

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (main_Command.mediaState == true && media_state_check == true)
            {
                ellipse_image.Source = new BitmapImage(new Uri(@"Resources/下_1.png", UriKind.Relative));

                if (main_Command.mediaPauseCommand.CanExecute(null))
                {
                    main_Command.mediaPauseCommand.Execute(null);
                }

                Storyboard mystoryboard = (this.FindResource("Ellipse_start") as Storyboard);
                mystoryboard.Begin();

                media_state_check = false;
            }
            
            //if (main_Command.mediaPauseCommand.CanExecute(null))
            //{
            //    main_Command.mediaPauseCommand.Execute(null);

            //    if (main_Command.mediaState == false)
            //    {
            //        ellipse_image.Source = new BitmapImage(new Uri(@"Resources/pause.png", UriKind.Relative));
            //    }
            //    else
            //    {
            //        ellipse_image.Source = new BitmapImage(new Uri(@"Resources/下_1.png", UriKind.Relative));
            //    }

            //    Storyboard mystoryboard = (this.FindResource("Ellipse_start") as Storyboard);
            //    mystoryboard.Begin();
            //}
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (main_Command.mediaState == false && media_state_check ==true)
            {
                ellipse_image.Source = new BitmapImage(new Uri(@"Resources/pause.png", UriKind.Relative));

                if (main_Command.mediaPlayCommand.CanExecute(null))
                {
                    main_Command.mediaPlayCommand.Execute(null);
                }

                Storyboard mystoryboard = (this.FindResource("Ellipse_start") as Storyboard);
                mystoryboard.Begin();

                media_state_check = false;
            }
            media_state_check = true;
        }

        Point mouse_P, PicP;
        double dx, dy;

        private void PicBoxView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ini.IniWriteValue("Window", "Height", this.Height.ToString(), ini_filename);
            ini.IniWriteValue("Window", "Width", this.Width.ToString(), ini_filename);
        }

        private void PicBoxView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!string.IsNullOrEmpty(main_Command.picSource.ToString()))
            {
                //mouse_P = Mouse.GetPosition(this);
                mouse_P = e.GetPosition(mainGrid);
                PicP.X = main_Command.picX;
                PicP.Y = main_Command.picY;
            }
        }

        

        private void PicBoxView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //dx = (Mouse.GetPosition(this).X - mouse_P.X) ;
                //dy = (Mouse.GetPosition(this).Y - mouse_P.Y) ;
                dx = (e.GetPosition(mainGrid).X - mouse_P.X);
                dy = (e.GetPosition(mainGrid).Y - mouse_P.Y);

                main_Command.picX += dx;
                main_Command.picY += dy;                              
                                
                mouse_P = e.GetPosition(mainGrid);
            }                        
        }
                
        //Transform Bitmap bytes into BitmapImage
        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        private void IniSetup()
        {
            ini.IniWriteValue("Bar", "btn_opa", main_Command.imgbar_opa.ToString(), ini_filename);
            ini.IniWriteValue("Bar", "volume", main_Command.media_volume.ToString(), ini_filename);
            ini.IniWriteValue("Window", "Height", this.Height.ToString(), ini_filename);
            ini.IniWriteValue("Window", "Width", this.Width.ToString(), ini_filename);
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
}
