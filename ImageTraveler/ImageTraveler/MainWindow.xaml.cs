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
using System.Drawing.Imaging;

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

            if (File.Exists(ini_path + "ImagTraver\\ImagTraver.ini"))
            {
                //讀取ini media volume
                main_Command.media_volume = Convert.ToDouble(main_Command.ini.IniReadValue("Bar", "volume", main_Command.ini_filename));
                this.Height = Convert.ToDouble(main_Command.ini.IniReadValue("Window", "Height", main_Command.ini_filename));
                this.Width = Convert.ToDouble(main_Command.ini.IniReadValue("Window", "Width", main_Command.ini_filename));

                try
                {
                    _isBackgroundImg_show = Convert.ToBoolean(ini.IniReadValue("Window", "Background_Image", ini_filename));
                    //設定初始背景圖片
                    if (!_isBackgroundImg_show)
                        img_girl_background.Visibility = Visibility.Collapsed;
                    else
                        img_girl_background.Visibility = Visibility.Visible;
                }
                catch { }
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
                        
            if (File.Exists(ini_path + "ImagTraver\\ImagTraver.ini") || main_Command.ImgOrMedia == 1)
            {
                //讀取ini media volume
                main_Command.media_volume = Convert.ToDouble(main_Command.ini.IniReadValue("Bar", "volume", main_Command.ini_filename));

                try
                {
                    _isBackgroundImg_show = Convert.ToBoolean(ini.IniReadValue("Window", "Background_Image", ini_filename));
                    //設定初始背景圖片
                    if (!_isBackgroundImg_show)
                        img_girl_background.Visibility = Visibility.Collapsed;
                    else
                        img_girl_background.Visibility = Visibility.Visible;
                }
                catch { }
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
            main_Command.ImgPaintMode = false;
            main_Command.EditingMode = InkCanvasEditingMode.None; //修改inkcanvas 模式
            Ink1.Visibility = Visibility.Collapsed;
            main_Command.zIndex_group[1] = 0;
        }

        private void Btn_Pen_Click(object sender, RoutedEventArgs e)
        {
            main_Command.ImgPaintMode = true;

            main_Command.EditingMode = InkCanvasEditingMode.None; //修改inkcanvas 模式

            Ink1.Visibility = Visibility.Visible;

            System.Drawing.Bitmap bitmap = ImageManager.ImageSourceToBitmap(PicBoxView.Source);

            //Ink1.Width = bitmap.Width;
            //Ink1.Height = bitmap.Height;
            
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            //將Image.source轉成bitmap
            System.Drawing.Bitmap bitmap = ImageManager.ImageSourceToBitmap(PicBoxView.Source);
            

            //get the dimensions of the ink control
            int margin = (int)this.Ink1.Margin.Left;
            int width = (int)this.Ink1.ActualWidth;
            int height = (int)this.Ink1.ActualHeight;
            
            if (width == 0 || height == 0) return;

            //render ink to bitmap
            RenderTargetBitmap rtb =
               new RenderTargetBitmap(width, height, 96d, 96d, PixelFormats.Default);
            rtb.Render(Ink1);

            //save the ink to a memory stream
            BmpBitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtb));
            byte[] bitmapBytesInk,bitmapBytes;            
                       
            using (MemoryStream ms = new MemoryStream())
            {
                //save stream to encoder
                encoder.Save(ms);

                //將Stream轉成Bitmap
                System.Drawing.Bitmap bmInk = (System.Drawing.Bitmap)System.Drawing.Image.FromStream(ms);

                //get the bitmap bytes from the memory stream
                ms.Position = 0;
                bitmapBytesInk = ms.ToArray();

                FileStream fileStream = new FileStream("C:\\Users\\user\\Pictures\\圖片1.png", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                               
                fileStream.Write(bitmapBytesInk, 0, (int)ms.Length);
                fileStream.Dispose();



                //將PictureBoxView內的圖存到BitmapEncoder中
                MemoryStream mms = new MemoryStream();
                System.Windows.Media.Imaging.BmpBitmapEncoder bbe = new BmpBitmapEncoder();
                bbe.Frames.Add(BitmapFrame.Create(new Uri(PicBoxView.Source.ToString(), UriKind.RelativeOrAbsolute)));

                //將BitmapEncoder轉成stream
                bbe.Save(mms);
                //將stream轉成image
                System.Drawing.Image img2 = System.Drawing.Image.FromStream(mms);
                //儲存Image
                img2.Save("C:\\Users\\user\\Pictures\\Test1.png");




                #region 將已存在的圖讀取成stream後修改再儲存

                //自圖檔路徑讀取成FileStream
                MemoryStream mmss = new MemoryStream();
                Stream stream1 = new FileStream("C:\\Users\\user\\Pictures\\圖片1 - copy.png", FileMode.Open, FileAccess.Read, FileShare.Read);

                //將FileStream轉成MemoryStream
                stream1.CopyTo(mmss);
                //stream1.Dispose();

                //將Stream轉成陣列
                bitmapBytes = mmss.ToArray();

                //將Stream轉成Bitmap
                System.Drawing.Bitmap bm = (System.Drawing.Bitmap)System.Drawing.Image.FromStream(mmss);

                System.Drawing.Color color_tranparent = System.Drawing.Color.FromArgb(255, 0, 0, 0);

                for (int i = 0; i < bmInk.Width; i++)
                {
                    for (int j = 0; j < bmInk.Height; j++)
                    {                        
                        if (bmInk.GetPixel(i, j) != color_tranparent)
                        {
                            bm.SetPixel(i, j, bmInk.GetPixel(i, j));
                        }
                    }
                }

                //將bitmap轉成
                bm.Save("C:\\Users\\user\\Pictures\\Test3.png");

                //將陣列轉成System.Drawing.Image
                System.Drawing.Image image = BufferToImage(bitmapBytes);

                // Get the color of a pixel within myBitmap.
                System.Drawing.Color pixelColor = bm.GetPixel(50, 50);

                // Transform color to solidbrush
                System.Drawing.SolidBrush pixelBrush = new System.Drawing.SolidBrush(pixelColor);

                //儲存Image
                image.Save("C:\\Users\\user\\Pictures\\Test2.png");
                #endregion                
            }
        }

        

        private System.Drawing.Image BufferToImage(byte[] Buffer)
        {
            byte[] data = null;
            System.Drawing.Image oImage = null;
            MemoryStream oMemoryStream = null;
            System.Drawing.Bitmap oBitmap = null;
            //建立副本
            data = (byte[])Buffer.Clone();
            try
            {
                oMemoryStream = new MemoryStream(data);
                //設定資料流位置
                oMemoryStream.Position = 0;
                oImage = System.Drawing.Image.FromStream(oMemoryStream);
                //建立副本
                oBitmap = new System.Drawing.Bitmap(oImage);
            }
            catch
            {
                throw;
            }
            finally
            {
                oMemoryStream.Close();
                oMemoryStream.Dispose();
                oMemoryStream = null;
            }
            return oImage;
            //return oBitmap;
        }

        //private void inkCanvas_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Escape)
        //        main_Command.EditingMode = InkCanvasEditingMode.None;
        //}

        bool _isBackgroundImg_show = false;
        private void Btn_Background_Click(object sender, RoutedEventArgs e)
        {
            _isBackgroundImg_show = !_isBackgroundImg_show;

            //設定初始背景圖是否顯示
            if (!_isBackgroundImg_show)
                img_girl_background.Visibility = Visibility.Collapsed;
            else
                img_girl_background.Visibility = Visibility.Visible;

            ini.IniWriteValue("Window", "Background_Image", (_isBackgroundImg_show).ToString(), ini_filename);
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

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ini.IniWriteValue("Window", "Height", this.Height.ToString(), ini_filename);
            ini.IniWriteValue("Window", "Width", this.Width.ToString(), ini_filename);
        }

        private void PicBoxView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!main_Command.ImgPaintMode)
            {
                if (main_Command.picSource != null)
                {
                    if (!string.IsNullOrEmpty(main_Command.picSource.ToString()))
                    {
                        //mouse_P = Mouse.GetPosition(this);
                        mouse_P = e.GetPosition(mainGrid);
                        PicP.X = main_Command.picX;
                        PicP.Y = main_Command.picY;
                    }
                }
            } 
        }

        private void Img_girl_background_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isBackgroundImg_show = !_isBackgroundImg_show;

            //設定初始背景圖是否顯示
            if (!_isBackgroundImg_show)
                img_girl_background.Visibility = Visibility.Collapsed;
            else
                img_girl_background.Visibility = Visibility.Visible;                        

            ini.IniWriteValue("Window", "Background_Image", (_isBackgroundImg_show).ToString(), ini_filename);
        }

        private void PicBoxView_MouseMove(object sender, MouseEventArgs e)
        {
            if (!main_Command.ImgPaintMode)
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
