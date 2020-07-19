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

namespace ImageTraveler.ViewModels
{
    public class Main_Command : Main_VM
    {
        //ICommand
        #region ICommand
        public ICommand WindowLoadedCommand { get { return new Delegatecommand(WindowLoaded); } }
        
        public ICommand LoadCommand { get { return new Delegatecommand(Load_Camera_Page); } }
       
        public ICommand DeleteCommand { get { return new Delegatecommand(DeleteImage); } }

        public ICommand MaximumCommand { get { return new Delegatecommand(Window_Maximum); } }
        
        public ICommand FitCommand { get { return new Delegatecommand(fit_image); } }

        public ICommand PreCommand { get { return new Delegatecommand(PrePic); } }
       
        public ICommand NextCommand { get { return new Delegatecommand(NextPic); } }

        public ICommand PreMedia { get { return new Delegatecommand(preMedia); } }

        public ICommand NextMedia { get { return new Delegatecommand(nextMedia); } }

        public ICommand BackToCommand { get { return new Delegatecommand(BackTo); } }
        
        public ICommand JumpToCommand { get { return new Delegatecommand(JumpTo); } }
        
        public ICommand JumpToPositionCommand { get { return new Delegatecommand(JumpToPostion); } }
       
        public ICommand mediaPlayPauseCommand { get { return new Delegatecommand(mediaElement_play_pause); } }

        public ICommand mediaPlayCommand { get { return new Delegatecommand(mediaElement_play); } }

        public ICommand mediaPauseCommand { get { return new Delegatecommand(mediaElement_pause); } }

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

        public double mediaVolumeSaved_mode1 = 0;
        private void mediaElement_mute()
        {
            if (mediaSource == null)
                return;

            if (media_volume > 0)
            {
                mediaVolumeSaved_mode1 = media_volume;
                media_volume = 0;
                mediaBar_volume_btn_sourcce = "../Resources/Volume-1.png"; //Mute
            }
                        
            else
            {
                media_volume = mediaVolumeSaved_mode1;
                mediaBar_volume_btn_sourcce = "../Resources/Volume-2.png"; //General volume
            }           
        }

        private void mediaElement_play_pause()
        {
            if (media_Page != null)
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
                    return;
                }
            }

            if (camera_Page != null)
            {
                if (camera_Page.LocalWebCam.IsRunning) camera_Page.LocalWebCam.Stop();
                else camera_Page.LocalWebCam.Start();
            }
           
        }

        private void mediaElement_play()
        {
            if (media_Page.mediaElement.HasVideo)
            {
                if (mediaState == true)
                {
                    //mediaControl.MediaPause();
                }
                else
                {
                    mediaControl.MediaPlay();
                }
            }
        }

        private void mediaElement_pause()
        {
            if (media_Page.mediaElement.HasVideo)
            {
                if (mediaState == true)
                {
                    mediaControl.MediaPause();
                }
                else
                {
                    //mediaControl.MediaPlay();
                }
            }
        }

        private void mediaElement_Stop()
        {
            if (media_Page != null)
                if (media_Page.mediaElement.HasVideo)
                {
                    media_Page.mediaElement.Stop();
                    mediaState = false;
                    mediaBtn_play_pause = "../Resources/下_1.png";

                    return;
                }

            if (camera_Page != null)
            {
                if (camera_Page.LocalWebCam.IsRunning) camera_Page.LocalWebCam.Stop();
                else camera_Page.LocalWebCam.Start();
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
                ImgOrMedia = InitialLoadFile();                
            }

            ArgsInput = false;
        }

        private void mainWindowPageNavigation()
        {

        }

        private void grid_close_MouseDown()
        {
            try
            {
                port_Arduino.Write("0");
                port_Arduino.DiscardInBuffer();
                port_Arduino.DiscardOutBuffer();
                port_Arduino.Close();
            }
            catch { }

            if (camera_Page != null)
                if (camera_Page.LocalWebCam.IsRunning) camera_Page.LocalWebCam.Stop();

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
            //取得可獲得之工作視窗大小(不含工作列)                
            App.mainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            App.mainWindow.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            Rect workArea = new Rect(0, 0, App.mainWindow.MaxWidth, App.mainWindow.MaxHeight);  //transfer max-height and max-width to a work area rectangular

            if (windowState == WindowState.Maximized)
            {                
                //設定視窗至螢幕中央         
                if (App.mainWindow.Left >= 0)
                {
                    App.mainWindow.MaxHeight = App.mainWindow.MaxHeight * 2 / 3; //Set Max Screen size
                    App.mainWindow.MaxWidth = App.mainWindow.MaxWidth * 2 / 3;
                    App.mainWindow.Left = workArea.Width / 7;
                    App.mainWindow.Top = workArea.Height / 7;
                }
                else
                {
                    Rect minor_screen = new Rect(App.mainWindow.Width * -1, 0, App.mainWindow.Width, App.mainWindow.Height);
                    App.mainWindow.MaxHeight = minor_screen.Height * 2 / 3; //Set Max Screen size
                    App.mainWindow.MaxWidth = minor_screen.Width * 2 / 3;
                    //App.mainWindow.Left = minor_screen.X * 8 / 9;
                    //App.mainWindow.Top = workArea.Height / 7;
                }
                windowState = WindowState.Normal;

                fit_image();
            }      
            else
                windowState = WindowState.Maximized;
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
                if ((App.mainWindow.ResizeMode != ResizeMode.CanResize) && (App.mainWindow.ResizeMode != ResizeMode.CanResizeWithGrip)) return;
                windowState = windowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized; //雙擊最大化
            }
            else mRestoreForDragMove = windowState == WindowState.Maximized || windowState == WindowState.Normal;
        }

        private void fit_image()
        {
            scaleXY = 1;
            picX = 0;
            picY = 0;
        }

        private void windowMouseWheel(MouseWheelEventArgs e)
        {
            if (picSource == null) return;
            if (scaleXY >= 0.3 && scaleXY <= 3.3) scaleXY = e.Delta > 0 ? scaleXY + .1 : scaleXY - .1;
            else if (scaleXY < 0.3 && e.Delta > 0) scaleXY += 0.1;
            else if (scaleXY > 3.3 && e.Delta < 0) scaleXY -= 0.1;
        }
                
        private void windowMouseDown(MouseButtonEventArgs e)
        {
            if (picSource != null)
            {
                if (e.MiddleButton == MouseButtonState.Pressed) fit_image();
                else if (e.XButton1 == MouseButtonState.Pressed) PrePic();
                else if (e.XButton2 == MouseButtonState.Pressed) NextPic();
            }
            else if (mediaSource != null)
            {
                if (e.MiddleButton == MouseButtonState.Pressed)
                {
                    if (mediaState) mediaControl.MediaPause();
                    else mediaControl.MediaPlay();                    
                }
                else if (e.XButton1 == MouseButtonState.Pressed) mediaControl.MediaJumpTo();
                else if (e.XButton2 == MouseButtonState.Pressed) BackTo();
            }
        }
        
        public bool mediaState = true;
        string NumKeyin;
                
        public void WindowKeyEventHandler(KeyEventArgs args)
        {
            
            if (args == null)   //因使用KeyBinding的方法來避免特殊鍵，在此定義為空白鍵的暫停動作
            {
                if (media_Page.mediaElement.HasVideo)
                {
                    if (mediaState == true) { mediaControl.MediaPause(); }
                    else { mediaControl.MediaPlay(); }
                }

                return;
            }

            if ((Keyboard.IsKeyDown(Key.RightCtrl) || Keyboard.IsKeyDown(Key.LeftCtrl)) && args.Key == Key.Right) { nextMedia(); }

            else if ((Keyboard.IsKeyDown(Key.RightCtrl) || Keyboard.IsKeyDown(Key.LeftCtrl)) && args.Key == Key.Left) { preMedia(); }

            else
            {
                if (args.Key == Key.Right)
                {
                    NextPic();
                    //FocusManager.SetFocusedElement(main, mediaBar_Page.BackBorer);
                    //MessageBox.Show(FocusManager.GetFocusedElement(mediaBar_Page).ToString());
                }

                else if (args.Key == Key.Left)
                {
                    PrePic();
                    //FocusManager.SetFocusedElement(mediaBar_Page, mediaBar_Page.BackBorer);
                    //MessageBox.Show(FocusManager.GetFocusedElement(mediaBar_Page).ToString());
                }

                else if (args.Key == Key.Up)
                {
                    if(ImgOrMedia==1)
                        media_speed = media_speed + 0.1;
                }
                    

                else if (args.Key == Key.Down)
                {
                    if(ImgOrMedia==1)
                        media_speed = media_speed - 0.1;
                }
                   

                else if (args.Key == Key.Delete)
                    DeleteImage();

                //else if (args.Key == Key.Space)
                //{
                //    if (media_Page.mediaElement.HasVideo)
                //    {
                //        if (mediaState == true) { mediaControl.MediaPause(); }
                //        else { mediaControl.MediaPlay(); }
                //    }
                //}

                else
                {
                    var key_input = args.Key.ToString();
                    string intStr = Regex.Replace(key_input, "[^0-9]", "");
                    NumKeyin = NumKeyin + intStr;
                }
            }            
        }

        LoadFileClass loadFileClass;
                
        public string directory = null;  // 打開圖片的目錄
        public List<string> imgArray = null;  // 目錄下圖片的集合
        string[] FldArray = null;
        int currentIndex, preIndex, nextIndex, rotation_index = 1;

        private void LoadPic()
        {
           
            if (ArgsInput == false)
            {                
                loadFileClass = new LoadFileClass();

                //取得對話框訊息
                OpenFileDialog fileDialog = loadFileClass.openFileDialog();

                if (string.IsNullOrEmpty(fileDialog.FileName)) return;
                                
                imgPath = fileDialog.FileName;  //取得完整路徑
               
                fileName = fileDialog.SafeFileName;  //取得檔名
            }
            ImgOrMedia = InitialLoadFile(); //進行載入檔案並進行初始化設定
        }

        //進行載入檔案並進行初始化設定
        private int InitialLoadFile()
        {
            int ImgOrMedia = 0;  //0 is Img, 1 is Media

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

                try { picSource = BitmapFromUri(new Uri(imgPath)); }
                catch {  pic_error_code = 1; }  //image is not exist

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

                imgManager = new ImageManager();

                ImgOrMedia = 0;
            }

            //Media
            else if (string.Compare(fileName_Extension, ".mp3", true) == 0 || string.Compare(fileName_Extension, ".mp4", true) == 0
                 || string.Compare(fileName_Extension, ".avi", true) == 0 || string.Compare(fileName_Extension, ".wmv", true) == 0)
            {
                if (media_Page == null)
                {
                    media_Page = new Media_Page(this);
                    mediaBar_Page = new MediaBar_Page(this);
                    mediaControl = new MediaControl(this);

                    //Navigate to Media Page
                    App.mainWindow.Frame_main.Content = media_Page;
                    App.mainWindow.Frame_bar.Content = mediaBar_Page;
                }
                else
                    fileName = Path.GetFileName(imgPath);

                mediaSource = imgPath;
               
                titleBar_ico_source = "../Resources/下_1.png";  //set title bar icon image
                mediaBtn_play_pause = "../Resources/pause.png";
                                
                picSource = null;
                zIndex_group = new int[] { 0, 0, 2 };
                //sliderVisible = Visibility.Visible;

                titleBar = fileName + " - ImageTraveler";

                ImgOrMedia = 1;
            }            
            GroupOpacity = new double[] { 0, 0, 0 };            
            initial_picSource = null;

            return ImgOrMedia;
        }
                
        private void UpdateTitleBarText()  //計算圖片所在資料夾之圖片陣列並顯示TitleBar文字
        {
            // 取得此層資料夾路徑(圖片集合目錄)
            directory = Path.GetDirectoryName(imgPath);

            //取得父層資料夾路徑
            string parentFld = "";
            try
            {
                parentFld = System.IO.Directory.GetParent(System.IO.Directory.GetParent(imgPath).FullName.ToString()).FullName.ToString();

                //取得父層資料夾中所有資料夾
                FldArray = System.IO.Directory.GetDirectories(parentFld);

                // 取得旋轉後的圖片對象(取得此層資料夾中的所有圖片)
                imgArray = ImageManager.GetImgCollection(directory);

                titleBar = string.Format("{0} - {1} / {2} - ImageTraveler",
                        Path.GetFileName(imgArray[GetIndex(imgPath)]), (GetIndex(imgPath) + 1), imgArray.Count);
            }
            catch { }            
        }

        private void FindNextMedia_in_thisFld(bool pre_or_next)
        {            
            try
            {
                //取得本資料夾路徑
                string thisFld = System.IO.Directory.GetParent(imgPath).FullName.ToString();

                //取得本層資料夾中所有資料夾
                //FldArray = System.IO.Directory.GetDirectories(thisFld);

                //if (FldArray.Length == 0) return;

                //int count_Fld = 0;
                //foreach (string s in FldArray)
                //{
                //    if (s != directory) count_Fld++;
                //    else break;
                //}

                string nextMedia="";  //下一個影片               

                // 取得旋轉後的圖片對象(取得此層資料夾中的所有影片)
                imgArray = MediaManager.GetMediaCollection(thisFld);

                int mediaIndex = imgArray.FindIndex(x => x == imgPath);
                                
                if (pre_or_next == true)   //找下一個
                {
                    mediaIndex++;
                    if (mediaIndex > imgArray.Count)  //超出陣列
                        nextMedia = imgArray[0];
                    else //陣列內
                        nextMedia = imgArray[mediaIndex];
                }
                else   //找上一個
                {
                    mediaIndex--;
                    if (mediaIndex < 0)  //超出陣列
                        nextMedia = imgArray[imgArray.Count - 1];
                    else //陣列內
                        nextMedia = imgArray[mediaIndex];
                }
                imgPath = nextMedia;
            }
            catch { }
        }

        private void FindNextFld_in_parentFld(bool pre_or_next)
        {
            // 取得此層資料夾路徑(圖片集合目錄)
            directory = Path.GetDirectoryName(imgPath);

            try
            {
                //取得父層資料夾路徑
                string parentFld = System.IO.Directory.GetParent(System.IO.Directory.GetParent(imgPath).FullName.ToString()).FullName.ToString();

                //取得父層資料夾中所有資料夾
                FldArray = System.IO.Directory.GetDirectories(parentFld);

                if (FldArray.Length == 0) return;

                int count_Fld = 0;
                foreach (string s in FldArray)
                {
                    if (s != directory) count_Fld++;
                    else break;
                }

                string nextFld;  //下一個資料夾
                if (pre_or_next == true)   //找下一個
                {
                    if (count_Fld >= FldArray.Length - 1)  //超出陣列
                        nextFld = FldArray[0];
                    else //陣列內
                        nextFld = FldArray[count_Fld + 1];
                }
                else   //找上一個
                {
                    if (count_Fld <= 0)  //超出陣列
                        nextFld = FldArray[FldArray.Length - 1];
                    else //陣列內
                        nextFld = FldArray[count_Fld - 1];
                }
                
                // 取得旋轉後的圖片對象(取得此層資料夾中的所有圖片)
                if (ImgOrMedia == 0) imgArray = ImageManager.GetImgCollection(nextFld);
                else imgArray = MediaManager.GetMediaCollection(nextFld);

                //如果此資料夾內無圖片檔
                for (int i = 0; i < FldArray.Length; i++)
                {
                    if (imgArray.Count == 0)
                    {                      
                        if (pre_or_next == true)   //找下一個
                        {
                            count_Fld++;
                            if (count_Fld >= FldArray.Length - 1)  //超出陣列
                                nextFld = FldArray[0];
                            else //陣列內
                                nextFld = FldArray[count_Fld + 1];
                        }
                        else   //找上一個
                        {
                            count_Fld--;
                            if (count_Fld <= 0)  //超出陣列
                                nextFld = FldArray[FldArray.Length - 1];
                            else //陣列內
                                nextFld = FldArray[count_Fld - 1];
                        }
                        if (ImgOrMedia == 0) imgArray = ImageManager.GetImgCollection(nextFld);
                        else imgArray = MediaManager.GetMediaCollection(nextFld);
                    }
                    else
                    {
                        imgPath = imgArray[0];
                        break;
                    }
                }                
            }
            catch { }
        }

        private void Load_Camera_Page()
        {
            if (camera_Page == null) camera_Page = new Camera_Page();
            if (mediaBar_Page == null) mediaBar_Page = new MediaBar_Page(this);

            //Navigate to Media Page
            App.mainWindow.Frame_main.Content = camera_Page;
            App.mainWindow.Frame_bar.Content = mediaBar_Page;
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
                //刪除指定文件至資源回收筒，並顯示進度視窗
                FileSystem.DeleteFile(destinationFile, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
                //File.Delete(destinationFile);           

                //更新imgArray和titlebar
                UpdateTitleBarText();                
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

        private void nextMedia()
        {
            //if (media_Page == null) return;

            if (ImgOrMedia == 0)  //Picture
                FindNextFld_in_parentFld(true);
            else
                FindNextMedia_in_thisFld(true);

            InitialLoadFile();
        }

        private void preMedia()
        {
            //if (media_Page == null) return;

            if (ImgOrMedia == 0)   //Picture
                FindNextFld_in_parentFld(false);
            else
                FindNextMedia_in_thisFld(false);

            InitialLoadFile();
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
                TimeSpan ts = new TimeSpan(0, 0, 0, 4);

                media_Page.mediaElement.Position = media_Page.mediaElement.Position + ts;
            }
        }

        private void JumpToPostion()
        {
            if (media_Page == null) return;

            media_Page.mediaElement.Position = TimeSpan.FromSeconds(mediaBar_Page.Slider_mediabar.Value);
        }

        private void JumpTo()
        {
            if (media_Page == null) return;

            TimeSpan ts = new TimeSpan(0, 0, 0, 5);

            media_Page.mediaElement.Position = media_Page.mediaElement.Position + ts;
        }

       

        private void BackTo()
        {
            if (media_Page == null) return;

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

        private void SwitchFolder(int index)
        {
            
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
