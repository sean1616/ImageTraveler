using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;
using ImageTraveler;
using ImageTraveler.Utils;
using ImageTraveler.Pages;
using Cinch;
using Microsoft.Win32;
using Microsoft.VisualBasic.FileIO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace ImageTraveler.ViewModels
{
    public class Main_Command : Main_VM
    {
        //ICommand
        #region ICommand
        public ICommand WindowLoadedCommand { get { return new Delegatecommand(WindowLoaded); } }
        
        public ICommand LoadCommand { get { return new Delegatecommand(LoadPic); } }
       
        public ICommand DeleteCommand { get { return new Delegatecommand(DeleteImage); } }

        public ICommand MaximumCommand { get { return new Delegatecommand(Window_Maximum); } }
        
        public ICommand FitCommand { get { return new Delegatecommand(fit_image); } }

        public ICommand PreCommand { get { return new Delegatecommand(PrePic); } }
       
        public ICommand NextCommand { get { return new Delegatecommand(NextPic); } }
        
        public ICommand BackToCommand { get { return new Delegatecommand(BackTo); } }
        
        public ICommand JumpToCommand { get { return new Delegatecommand(JumpTo); } }
       
        public ICommand JumpToPositionCommand { get { return new Delegatecommand(JumpToPostion); } }
       
        public ICommand mediaPlayPauseCommand { get { return new Delegatecommand(mediaElement_play_pause); } }
        
        public ICommand MediaStopCommand { get { return new Delegatecommand(mediaElement_Stop); } }
       
        public ICommand MediaMuteCommand { get { return new Delegatecommand(mediaElement_mute); } }
        
        public ICommand RotaCommand { get { return new Delegatecommand(RotaPic); } }
        
        public ICommand MediaEndedCommand { get { return new Delegatecommand(mediaEnded); } }

        public ICommand MouseMoveCommand { get { return new Delegatecommand(MouseMove); } }
        
        public ICommand MouseLeaveCommand { get { return new Delegatecommand(MouseLeave); } }
        
        public ICommand EscKey { get { return new Delegatecommand(Esc); } }
       
        public ICommand EscKey_InCanvas { get { return new DelegateCommand<KeyEventArgs>(Esc_InCanvas); } }
        
        public ICommand WindowKey { get { return new DelegateCommand<KeyEventArgs>(WindowKeyEventHandler); } }
       
        public ICommand WindowMouseDown { get { return new DelegateCommand<MouseButtonEventArgs>(windowMouseDown); } }
        
        public ICommand WindowMouseWheel { get { return new DelegateCommand<MouseWheelEventArgs>(windowMouseWheel); } }
        
        public ICommand TitleBar_MouseLeftButtonUp { get { return new DelegateCommand<EventToCommandArgs>(titleBar_MouseLeftButtonUp); } }
       
        public ICommand TitleBar_MouseLeftButtonDown { get { return new DelegateCommand<MouseButtonEventArgs>(titleBar_MouseLeftButtonDown); } }
        
        public ICommand TitleBar_MouseMove { get { return new DelegateCommand<MouseEventArgs>(titleBar_MouseMove); } }
        
        public ICommand MouseLeftButtonUp { get { return new Delegatecommand(mouseLeftButtonUp); } }
       
        public ICommand Grid_generalize_maximum_MouseDown { get { return new Delegatecommand(grid_generalize_maximum_MouseDown); } }
        
        public ICommand Grid_minimize_MouseDown { get { return new Delegatecommand(grid_minimize_MouseDown); } }
        
        public ICommand Grid_close_MouseDown { get { return new Delegatecommand(grid_close_MouseDown); } }   
        
        public ICommand MediaTimeBar_DragStarted { get { return new Delegatecommand(mediaTimeBar_Drag); } }
        #endregion

        #region Commands
        private void mediaTimeBar_Drag()
        {
            if (!isDragging)
                isDragging = true;
            else
            {
                isDragging = false;
            }
        }

        private void mediaEnded()
        {
            mediaBtn_play_pause = "../Resources/下_1.png";
        }

        public double mediaVolumeSaved_mode1, mediaVolumeSaved_mode2 = 0.1;
        private void mediaElement_mute()
        {
            if (mediaSource == null)
                return;

            if (mediaBar_Page.Slider_volume.Maximum == 1)
            {
                mediaVolumeSaved_mode1 = media_Page.mediaElement.Volume;
                mediaBar_Page.Slider_volume.Maximum = 0.2;
                media_volume = mediaVolumeSaved_mode2;
                mediaBar_volume_btn_sourcce = "../Resources/Volume-3.png"; //small volume
            }

            else if (mediaBar_Page.Slider_volume.Maximum == 0.2)
            {
                mediaVolumeSaved_mode2 = media_Page.mediaElement.Volume;
                media_volume = 0;
                mediaBar_Page.Slider_volume.Maximum = 0.1;                
                mediaBar_volume_btn_sourcce = "../Resources/Volume-1.png"; //Mute
            }

            else if (mediaBar_Page.Slider_volume.Maximum == 0.1)
            {
                mediaBar_Page.Slider_volume.Maximum = 1;
                media_volume = mediaVolumeSaved_mode1;
                mediaBar_volume_btn_sourcce = "../Resources/Volume-2.png"; //General volume
            }           
        }

        private void mediaElement_play_pause()
        {
            if (media_Page.mediaElement.HasVideo)
            {
                if (mediaState == true)
                {
                    mediaControl.MediaPause();
                }
                else
                {                   
                    mediaControl.MediaPlay();
                }
            }
        }

        private void mediaElement_Stop()
        {
            if (media_Page.mediaElement.HasVideo)
            {
                media_Page.mediaElement.Stop();
                mediaState = false;
                mediaBtn_play_pause = "../Resources/下_1.png";
            }
        }

        //設定初始化載入功能頁面
        private void WindowLoaded()
        {
            imageBar_Page = new ImageBar_Page(this);
            if (string.IsNullOrEmpty(imgPath))
                App.mainWindow.Frame_bar.Content = imageBar_Page;
            else
            {
                //點擊媒體開始
                InitialLoadFile();                
            }

            ArgsInput = false;
        }

        private void mainWindowPageNavigation()
        {

        }

        private void grid_close_MouseDown()
        {            
            App.mainWindow.Close();
        }

        private void Window_Maximum()
        {
            if (!double.IsInfinity(App.mainWindow.MaxHeight) || windowState == WindowState.Normal)
            {
                App.mainWindow.MaxHeight = 17e307 + 1e307;
                App.mainWindow.MaxWidth = 17e307 + 1e307;
                App.mainWindow.Hide();
                windowState = WindowState.Normal;
                windowState = WindowState.Maximized;
                App.mainWindow.Show();
            }
            else
            {
                windowState = WindowState.Normal;
                //取得可獲得之工作視窗大小(不含工作列)                
                App.mainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight; var a = SystemParameters.WorkArea;
                App.mainWindow.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
                windowState = WindowState.Maximized;
            }               
        }

        private void grid_minimize_MouseDown()
        {
            windowState = WindowState.Minimized;

            if (media_Page != null)
            {
                if (media_Page.mediaElement.HasVideo)
                {
                    media_Page.mediaElement.Pause();
                    mediaBtn_play_pause = "../Resources/pause.png";
                }
            }
        }

        private void grid_generalize_maximum_MouseDown()
        {
            if (windowState == WindowState.Maximized)
                windowState = WindowState.Normal;
            else
            {                
                //取得可獲得之工作視窗大小(不含工作列)                
                App.mainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight; var a = SystemParameters.WorkArea;
                App.mainWindow.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;

                windowState = WindowState.Maximized;
                
                //AutoClosingMessageBox.Show("","",90);
                //fit_image();
            }           
        }

        private void mouseLeftButtonUp()
        {            
            mRestoreForDragMove = false;
        }

        private void titleBar_MouseMove(MouseEventArgs e)
        {
            if (mRestoreForDragMove && windowState == WindowState.Maximized)
            {
                mRestoreForDragMove = false;

                //取得最大化時之視窗大小
                var windowsize_X = Math.Round(App.mainWindow.ActualWidth);
                var windowsize_Y = Math.Round(App.mainWindow.ActualHeight);

                windowState = WindowState.Normal;

                //相對於視窗中的滑鼠位置
                var point = e.MouseDevice.GetPosition(App.mainWindow);

                //計算滑鼠在視窗X方向上的位置(以百分比計算)
                var percentOfpoint = (point.X / windowsize_X) * App.mainWindow.RestoreBounds.Width;

                //滑鼠在螢幕中的位置                
                //var point = ((Window)Main_e.Sender).PointToScreen(e.MouseDevice.GetPosition((Window)Main_e.Sender));
                App.mainWindow.Left = point.X - percentOfpoint;
                App.mainWindow.Top = 0;
                //((Window)Main_e.Sender).Left = point.X - (((Window)Main_e.Sender).RestoreBounds.Width * 0.5);
                //((Window)Main_e.Sender).Top = point.Y;

                App.mainWindow.Height = App.mainWindow.RestoreBounds.Height;
                App.mainWindow.Width = App.mainWindow.RestoreBounds.Width;

                App.mainWindow.DragMove();
                                
                //((Window)Main_e.Sender).DragMove();
            }
            else if (mRestoreForDragMove && windowState == WindowState.Normal)
            {
                mRestoreForDragMove = false;
                
                App.mainWindow.DragMove();
            }
        }

        private bool mRestoreForDragMove;

        //MVVM傳遞object sender的方法
        private EventToCommandArgs Main_e;
        private void titleBar_MouseLeftButtonUp(EventToCommandArgs e)
        {
            Main_e = e;
        }

        private void titleBar_MouseLeftButtonDown(MouseButtonEventArgs args)
        {
            //判斷滑鼠點擊次數
            if (args.ClickCount == 2)
            {
                if ((App.mainWindow.ResizeMode != ResizeMode.CanResize) && (App.mainWindow.ResizeMode != ResizeMode.CanResizeWithGrip))
                {
                    return;
                }

                windowState = windowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized; //雙擊最大化

                //fit_image();
                //AutoClosingMessageBox.Show("Text", "Caption", 80);
            }
            else
            {
                mRestoreForDragMove = windowState == WindowState.Maximized || windowState == WindowState.Normal;
                //App.mainWindow.DragMove();  //拖曳結束後會激發mouseEnter事件
                //App.mainWindow.TitleBar_ControlGrid.MouseMove+=
                //((Window)Main_e.Sender).DragMove();
            }
        }

        private void fit_image()
        {
            scaleXY = 1;
            picX = 0;
            picY = 0;
            //Thread.Sleep(500);
            //MessageBox.Show("123");
            //AutoClosingMessageBox.Show("Text", "Caption", 30);
        }

        private void windowMouseWheel(MouseWheelEventArgs e)
        {
            if (picSource == null)
                return;

            if (scaleXY >= 0.3 && scaleXY <= 3.3)
                scaleXY = e.Delta > 0 ? scaleXY + .1 : scaleXY - .1;
            else if (scaleXY < 0.3 && e.Delta > 0)
                scaleXY += 0.1;
            //else if (scaleXY < 0.3 && e.Delta < 0)
            //    scaleXY = 0.3;
            //else if (scaleXY > 3.3 && e.Delta > 0)
            //    scaleXY = 3.3;
            else if (scaleXY > 3.3 && e.Delta < 0)
                scaleXY -= 0.1;
        }
                
        private void windowMouseDown(MouseButtonEventArgs e)
        {
            if (picSource != null)
            {
                if (e.MiddleButton == MouseButtonState.Pressed)
                {
                    fit_image();
                }                  
                else if (e.XButton1 == MouseButtonState.Pressed)
                    PrePic();
                else if (e.XButton2 == MouseButtonState.Pressed)
                    NextPic();                
            }
            else if (mediaSource != null)
            {
                if (e.MiddleButton == MouseButtonState.Pressed)
                {
                    if (mediaState)
                    {
                        mediaControl.MediaPause();
                    }
                    else
                    {
                        mediaControl.MediaPlay();
                    }
                }

                else if (e.XButton1 == MouseButtonState.Pressed)
                    mediaControl.MediaJumpTo();
                else if (e.XButton2 == MouseButtonState.Pressed)
                    BackTo();
            }
        }


        public bool mediaState = true;
        string NumKeyin;

        public void WindowKeyEventHandler(KeyEventArgs args)
        {
            if (args.Key == Key.Right)
                NextPic();

            else if (args.Key == Key.Down)
                NextPic();

            else if (args.Key == Key.Left)
                PrePic();

            else if (args.Key == Key.Up)
                PrePic();

            else if (args.Key == Key.Delete)
                DeleteImage();

            else if (args.Key == Key.Space)
            {
                if (media_Page.mediaElement.HasVideo)
                {
                    if (mediaState == true)
                    {
                        //media_Page.mediaElement.Pause();
                        //mediaState = false;
                        mediaControl.MediaPause();
                    }
                    else
                    {
                        //media_Page.mediaElement.Play();
                        //mediaState = true;
                        mediaControl.MediaPlay();
                    }
                }
            }

            //輸入數字後Enter進行Image轉換
            else if (args.Key == Key.Enter)
            {
                int IKey;
                bool result = int.TryParse(NumKeyin, out IKey);

                if (result == true && IKey > 0 && IKey <= imgArray.Count)
                {
                    SwitchImg(IKey - 1);

                    titleBar = string.Format("{0} - {1} / {2} - ImageTraverler", Path.GetFileName(imgArray[IKey - 1]), IKey, imgArray.Count);
                    //titleBar = Path.GetFileName(imgArray[IKey - 1]) + " - " +
                    //(IKey) + " / " + imgArray.Count + " - ImageTraveler";
                }
                NumKeyin = null;
            }
            //Key in 數字鍵
            else
            {
                var key_input = args.Key.ToString();
                string intStr = Regex.Replace(key_input, "[^0-9]", "");
                NumKeyin = NumKeyin + intStr;
            }
        }

        LoadFileClass loadFileClass;

        // 打開圖片的目錄
        public string directory = null;
        // 目錄下圖片的集合
        public List<string> imgArray = null;

        int currentIndex, preIndex, nextIndex, rotation_index = 1;

        private void LoadPic()
        {
            if (ArgsInput == false)
            {
                loadFileClass = new LoadFileClass();

                //取得對話框訊息
                OpenFileDialog fileDialog = loadFileClass.openFileDialog();

                if (string.IsNullOrEmpty(fileDialog.FileName))
                    return;

                //取得完整路徑
                imgPath = fileDialog.FileName;
                //取得檔名
                fileName = fileDialog.SafeFileName;
            }

            InitialLoadFile(); //進行載入檔案並進行初始化設定
        }

        //進行載入檔案並進行初始化設定
        private void InitialLoadFile()
        {
            //取得副檔名
            fileName_Extension = Path.GetExtension(imgPath);

            //先判斷選取物件種類
            //Image            
            if (string.Compare(fileName_Extension, ".png", true) == 0 || string.Compare(fileName_Extension, ".jpg", true) == 0
                || string.Compare(fileName_Extension, ".bmp", true) == 0 || string.Compare(fileName_Extension, ".gif", true) == 0)
            {

                //image_Page = new Image_Page(this);
                imageBar_Page = new ImageBar_Page(this);

                //Navigate to Media Page
                if (true)
                {
                    //App.mainWindow.Frame_main.Content = image_Page;
                    App.mainWindow.Frame_bar.Content = imageBar_Page;
                }

                UpdateTitleBarText();

                try
                {
                    picSource = BitmapFromUri(new Uri(imgPath));
                }
                catch
                {
                    pic_error_code = 1; //image is not exist
                    //picSource = null;
                }
                //picSource = new BitmapImage(new Uri(imgPath, UriKind.RelativeOrAbsolute));                               

                mediaSource = null;
                zIndex_group = new int[] { 0, 0, 0 };

                //設定視窗至螢幕中央
                Rect workArea = System.Windows.SystemParameters.WorkArea;
                var height_dif = workArea.Height - App.mainWindow.Height;
                var width_dif = workArea.Width - App.mainWindow.Width;
                if (height_dif >= 0 && width_dif >= 0)
                {
                    App.mainWindow.Left = (workArea.Width - App.mainWindow.Width) / 2 + workArea.Left;
                    App.mainWindow.Top = (workArea.Height - App.mainWindow.Height) / 2 + workArea.Top;
                }
                fit_image();
                //取得可獲得之工作視窗大小(不含工作列)                
                //App.mainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight; var a = SystemParameters.WorkArea;
                //App.mainWindow.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
                //windowState = WindowState.Maximized;
            }

            //Media
            else if (string.Compare(fileName_Extension, ".mp3", true) == 0 || string.Compare(fileName_Extension, ".mp4", true) == 0
                 || string.Compare(fileName_Extension, ".avi", true) == 0 || string.Compare(fileName_Extension, ".wmv", true) == 0 
                )            
            {
                media_Page = new Media_Page(this);
                mediaBar_Page = new MediaBar_Page(this);
                mediaControl = new MediaControl(this);
                //Navigate to Media Page
                if (true)
                {
                    App.mainWindow.Frame_main.Content = media_Page;
                    App.mainWindow.Frame_bar.Content = mediaBar_Page;
                }

                //media_Page.mediaElement.BeginInit();
                mediaSource = imgPath;
               
                titleBar_ico_source = "../Resources/下_1.png";  //set title bar icon image
                mediaBtn_play_pause = "../Resources/pause.png";
                                           
                //Set MediaElement source

                picSource = null;
                zIndex_group = new int[] { 0, 0, 2 };
                sliderVisible = Visibility.Visible;

                titleBar = fileName + " - ImageTraveler";

                //media_Page.mediaElement.Play();                
            }
            
            GroupOpacity = new double[] { 0, 0, 0 };
            
            initial_picSource = null;
            
        }

        //計算圖片所在資料夾之圖片陣列並顯示TitleBar文字
        private void UpdateTitleBarText()
        {
            // 取得圖片集合目錄
            directory = Path.GetDirectoryName(imgPath);

            // 取得旋轉後的圖片對象
            imgArray = ImageManager.GetImgCollection(directory);

            titleBar = string.Format("{0} - {1} / {2} - ImageTraveler",
                    Path.GetFileName(imgArray[GetIndex(imgPath)]), (GetIndex(imgPath) + 1), imgArray.Count);
        }

        // load an image into memory and use it as an image source, and the image could be delete when it was used by process
        private ImageSource BitmapFromUri(Uri source)
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = source;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            try
            {
                bitmap.EndInit();   //when image is not exist, error will happen here.
            }
            catch
            {
                pic_error_code = 1; //image is not exist
                //bitmap = new BitmapImage();
            }
            return bitmap;
        }

        private void DeleteImage()
        {
            if (picSource == null)
                return;

            string destinationFile = imgPath;

            NextPic();

            try
            {
                UpdateTitleBarText();

                //刪除指定文件至資源回收筒，並顯示進度視窗
                FileSystem.DeleteFile(destinationFile, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
                //File.Delete(destinationFile);                                
            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
            }
        }

        private void PrePic()
        {
            if (picSource != null || pic_error_code == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (zIndex_group[i] != 0)
                        return;
                }

                currentIndex = GetIndex(imgPath);

                if (currentIndex > 0 && currentIndex < imgArray.Count)
                {
                    preIndex = currentIndex - 1;

                    //換上一張圖
                    SwitchImg(preIndex);

                    titleBar = Path.GetFileName(imgArray[preIndex]) + " - " +
                       (currentIndex) + " / " + imgArray.Count + " - ImageTraveler";

                }
                else
                {
                    SwitchImg(imgArray.Count - 1);

                    titleBar = Path.GetFileName(imgArray[imgArray.Count - 1]) + " - " +
                       (imgArray.Count) + " / " + imgArray.Count + " - ImageTraveler";
                }
            }

            //影片快轉
            else if (mediaSource != null && zIndex_group[2] == 2)
            {
                // Overloaded constructor takes the arguments days, hours, minutes, seconds, miniseconds.
                // Create a TimeSpan with miliseconds equal to the slider value.
                TimeSpan ts = new TimeSpan(0, 0, 0, 5);

                //MediaElement的Position為不可相依屬性，因此無法使用Binding方式更改
                media_Page.mediaElement.Position = media_Page.mediaElement.Position - ts;
                //App.mainWindow.mediaElement.Position = App.mainWindow.mediaElement.Position - ts;
            }
            //else
            //    Initial_PicBoxView.Source = new BitmapImage(new Uri(@"../Resources/1442760789 - 複製.jpg", UriKind.RelativeOrAbsolute)); ;
        }

        private void NextPic()
        {
            if (picSource != null || pic_error_code==1)
            {
                //SwitchImg(16);

                for (int i = 0; i < 3; i++)
                {
                    if (zIndex_group[i] != 0)
                        return;
                }

                currentIndex = GetIndex(imgPath);

                if (currentIndex < imgArray.Count - 1)
                {
                    nextIndex = currentIndex + 1;
                    SwitchImg(nextIndex);

                    titleBar = Path.GetFileName(imgArray[nextIndex]) + " - " +
                    (currentIndex + 2) + " / " + imgArray.Count + " - ImageTraveler";
                }
                else
                {
                    SwitchImg(0);

                    titleBar = Path.GetFileName(imgArray[0]) + " - " +
                    (1) + " / " + imgArray.Count + " - ImageTraveler";
                }

                picX = 0;
                picY = 0;
                scaleXY = 1;
            }

            //影片倒回
            else if (mediaSource != null && zIndex_group[2] == 2)
            {
                // Overloaded constructor takes the arguments days, hours, minutes, seconds, miniseconds.
                // Create a TimeSpan with miliseconds equal to the slider value.
                TimeSpan ts = new TimeSpan(0, 0, 0, 5);

                media_Page.mediaElement.Position = media_Page.mediaElement.Position + ts;
            }
        }

        private void JumpToPostion()
        {
            media_Page.mediaElement.Position = TimeSpan.FromSeconds(mediaBar_Page.Slider_mediabar.Value);
        }

        private void JumpTo()
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 5);

            media_Page.mediaElement.Position = media_Page.mediaElement.Position + ts;
        }

        private void BackTo()
        {
            // Overloaded constructor takes the arguments days, hours, minutes, seconds, miniseconds.
            // Create a TimeSpan with miliseconds equal to the slider value.
            TimeSpan ts = new TimeSpan(0, 0, 0, 5);

            media_Page.mediaElement.Position = media_Page.mediaElement.Position - ts;
        }

        private void RotaPic()
        {
            //RotateTransform rotateTransform = new RotateTransform(90 * rotation_index, 0.5, 0.5);
            //ViewBox_Image.RenderTransform = rotateTransform; //只影響控制項本身
            //ViewBox_Image.LayoutTransform = rotateTransform; //可影響整體Layout
            rotaAngle = rotation_index * 90;
            rotation_index++;
        }

        private void MouseMove()
        {
            if (picSource == null && mediaSource == null)
            {
                GroupOpacity = new double[] { 1, 1, 1 };
            }
            else
            {
                GroupOpacity = new double[] { 0.8, 0.8, 1 };
            }
        }

        private void MouseLeave()
        {
            GroupOpacity = new double[] { 0, 0, 0 };
        }

        private void Esc()
        {             
            if (zIndex_group[1] >= 1)
            {
                EditingMode = InkCanvasEditingMode.None;
                zIndex_group = new int[] { 0, 0, 0 };
            }
            else if (windowState==WindowState.Maximized)
            {
                windowState = WindowState.Normal;
            }
            else
            {                
                App.mainWindow.Close();
            }
        }

        private void Esc_InCanvas(KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                EditingMode = InkCanvasEditingMode.None;
                zIndex_group = new int[] { 0, 0, 0 };
            }
        }

        
        // 獲得打開圖片在圖片集合中的索引
        public int GetIndex(string imagepath)
        {
            int index = 0;
            for (int i=0; i < imgArray.Count; i++)
            {
                if (imgArray[i].Equals(imagepath))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        // 切換圖片的方法
        private void SwitchImg(int index)
        {
            if (index < 0)
            {
                var newbitmap = imgArray[imgArray.Count - 1];
               
                try
                {
                    picSource = BitmapFromUri(new Uri(newbitmap));
                }
                catch
                {
                    picSource = null;
                }
                imgPath = newbitmap;
            }
            else
            {
                var newbitmap = imgArray[index];
                //picSource = BitmapFromUri(new Uri(newbitmap));
                try
                {
                    picSource = BitmapFromUri(new Uri(newbitmap));
                }
                catch
                {
                    picSource = null;
                }
                imgPath = newbitmap;
            }
        }
        #endregion
    }

    public class AutoClosingMessageBox
    {
        System.Threading.Timer _timeoutTimer;
        string _caption;
        AutoClosingMessageBox(string text, string caption, int timeout)
        {
            _caption = caption;
            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout, System.Threading.Timeout.Infinite);
            using (_timeoutTimer)                
                MessageBox.Show(text, caption);
        }
        public static void Show(string text, string caption, int timeout)
        {
            new AutoClosingMessageBox(text, caption, timeout);
        }
        void OnTimerElapsed(object state)
        {
            IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
            if (mbWnd != IntPtr.Zero)
                SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            _timeoutTimer.Dispose();
        }
        const int WM_CLOSE = 0x0010;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    }



}
