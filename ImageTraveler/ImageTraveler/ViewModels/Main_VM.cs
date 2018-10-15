using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.IO;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using Microsoft.Win32;
using ImageTraveler.Utils;
using ImageTraveler.Pages;
using Microsoft.Practices.Composite.Events;
using Cinch;

namespace ImageTraveler.ViewModels
{
    public class Main_VM : NotifyBase
    {
        private Color[] _rec_brush_color = new Color[3] { Colors.Transparent, Colors.White, Color.FromArgb(50,255,255,255) };
        public Color[] rec_brush_color
        {
            get { return _rec_brush_color; }
            set
            {
                _rec_brush_color = value;
                OnPropertyChanged("rec_brush_color");
            }
        }

        private IniSetup _ini = new IniSetup();
        public IniSetup ini
        {
            get { return _ini; }
            set
            {
                _ini = value;
                OnPropertyChanged("ini");
            }
        }

        private string _folderName = @"d:\ImagTraver";
        public string folderName
        {
            get { return _folderName; }
            set
            {
                _folderName = value;
                OnPropertyChanged("folderName");
            }
        }

        private string _ini_filename = "ImagTraver.ini";
        public string ini_filename
        {
            get { return _ini_filename; }
            set { _ini_filename = value;
                OnPropertyChanged("ini_filename");
            }
        }

        //private double _imgbar_border_opa = 0;
        //public double imgbar_border_opa
        //{
        //    get { return _imgbar_border_opa; }
        //    set
        //    {
        //        _imgbar_border_opa = value;
        //        OnPropertyChanged("imgbar_border_opa");
        //    }
        //}

        private double _imgbar_opa = 0.4;
        public double imgbar_opa
        {
            get { return _imgbar_opa; }
            set
            {
                _imgbar_opa = value;
                OnPropertyChanged("imgbar_opa");
            }
        }

        private Point[] _sPosi = new Point[7];
        public Point[] sPosi
        {
            get { return _sPosi; }
            set
            {
                _sPosi = value;
                OnPropertyChanged("sPosi");
            }
        }

        private Point[] _Posi = new Point[7];
        public Point[] Posi
        {
            get { return _Posi; }
            set
            {
                _Posi = value;
                OnPropertyChanged("Posi");
            }
        }

        //private int _volume_show_value;
        private string _volume_show;
        public string volume_show
        {
            get
            {
                _volume_show = Math.Round(media_volume * 100).ToString();                
                return _volume_show;
            }
            set
            {
                _volume_show = value;
                OnPropertyChanged("volume_show");
            }
        }

        private double _sliderThumb_size = 20;
        public double sliderThumb_size
        {
            get { return _sliderThumb_size; }
            set
            {
                _sliderThumb_size = value;
                OnPropertyChanged("sliderThumb_size");
            }
        }

        private double _mediaDuration = 0;
        public double mediaDuration
        {
            get { return _mediaDuration; }
            set
            {
                _mediaDuration = value;
                OnPropertyChanged("mediaDuration");
            }
        }

        private RepeatBehavior _repeatBehavior = RepeatBehavior.Forever;
        public RepeatBehavior RepeatBehavior
        {
            get { return _repeatBehavior; }
            set
            {
                _repeatBehavior = value;
                OnPropertyChanged("RepeatBehavior");
            }
        }

        private TimeSpan _mediaLength;
        public TimeSpan mediaLength
        {
            set
            {
                _mediaLength = value;
                OnPropertyChanged_Normal("mediaLength");
            }
            get { return _mediaLength; }
        }

        private int _escClickCount = 0;
        public int escClickCount
        {
            set
            {
                _escClickCount = value;
                OnPropertyChanged_Normal("escClickCount");
            }
            get { return _escClickCount; }
        }

        static private double _media_volume = 0.1;
        public double media_volume
        {
            set
            {
                volume_show = value.ToString();
                
                _media_volume = value;
                ini.IniWriteValue("Bar", "volume", _media_volume.ToString(), ini_filename); //覆寫ini音量設定
                OnPropertyChanged("media_volume");
            }
            get {
                //_media_volume = Convert.ToDouble(ini.IniReadValue("Bar", "volume", ini_filename));
                return _media_volume; }
        }

        private string _titleBar_ico_source = "../Resources/Image_icon.png";
        public string titleBar_ico_source
        {
            set
            {
                _titleBar_ico_source = value;
                OnPropertyChanged_Normal("titleBar_ico_source");
            }
            get { return _titleBar_ico_source; }
        }

        private string _mediaBar_volume_btn_sourcce = "../Resources/speaker.png";
        public string mediaBar_volume_btn_sourcce
        {
            set
            {
                _mediaBar_volume_btn_sourcce = value;
                OnPropertyChanged_Normal("mediaBar_volume_btn_sourcce");
            }
            get { return _mediaBar_volume_btn_sourcce; }
        }

        private string _mediaBar_mediaDurationTime ;
        public string mediaBar_mediaDurationTime
        {
            set
            {
                _mediaBar_mediaDurationTime = value;
                OnPropertyChanged_Normal("mediaBar_mediaDurationTime");
            }
            get { return _mediaBar_mediaDurationTime; }
        }

        private string _mediaBtn_play_pause = "../Resources/下_1.png";
        public string mediaBtn_play_pause
        {
            set
            {
                _mediaBtn_play_pause = value;
                OnPropertyChanged_Normal("mediaBtn_play_pause");
            }
            get { return _mediaBtn_play_pause; }
        }

        private bool _ArgsInput = false;
        public bool ArgsInput
        {
            set { SetProperty(ref _ArgsInput, value); }
            get { return _ArgsInput; }
        }

        private string _fileName_Extension;
        public string fileName_Extension
        {
            get { return _fileName_Extension; }
            set { SetProperty(ref _fileName_Extension, value); }
        }

        private string _fileName;
        public string fileName
        {
            get { return _fileName; }
            set { SetProperty(ref _fileName, value); }
        }

        private Image_Page _image_Page;
        public Image_Page image_Page
        {
            set { SetProperty(ref _image_Page, value); }
            get { return _image_Page; }
        }

        private ImageBar_Page _imageBar_Page;
        public ImageBar_Page imageBar_Page
        {
            set { SetProperty(ref _imageBar_Page, value); }
            get { return _imageBar_Page; }
        }

        private MediaBar_Page _mediaBar_Page;
        public MediaBar_Page mediaBar_Page
        {
            set { SetProperty(ref _mediaBar_Page, value); }
            get { return _mediaBar_Page; }
        }

        private Media_Page _media_Page;
        public Media_Page media_Page
        {
            set { SetProperty(ref _media_Page, value); }
            get { return _media_Page; }
        }
                
        private MediaControl _mediaControl;
        public MediaControl mediaControl
        {
            set { SetProperty(ref _mediaControl, value); }
            get { return _mediaControl; }
        }

        private WindowState _windowState = WindowState.Normal;
        public WindowState windowState
        {
            set
            {
                _windowState = value;
                OnPropertyChanged_Normal("windowState");
            }
            get { return _windowState; }
        }

        private string _SafeFileName;
        public string SafeFileName
        {
            set { SetProperty(ref _SafeFileName, value); }
            get { return _SafeFileName; }
        }

        private string _Directory;
        public string Directory
        {
            set { SetProperty(ref _Directory, value); }
            get { return _Directory; }
        }

        private InkCanvasEditingMode _EditingMode = InkCanvasEditingMode.None;
        public InkCanvasEditingMode EditingMode
        {
            set { SetProperty(ref _EditingMode, value); }
            get { return _EditingMode; }
        }

        private string _imgPath;
        public string imgPath
        {
            set { SetProperty(ref _imgPath, value); }
            get { return _imgPath; }
        }

        private int _picIndex;
        public int picIndex
        {
            set { SetProperty(ref _picIndex, value); }
            get { return _picIndex; }
        }

        private int _picCount;
        public int picCount
        {
            set { SetProperty(ref _picCount, value); }
            get { return _picCount; }
        }

        private double _picX = 0;
        public double picX
        {
            set { SetProperty(ref _picX, value); }
            get { return _picX; }
        }

        private double _picY = 0;
        public double picY
        {
            set { SetProperty(ref _picY, value); }
            get { return _picY; }
        }

        private double _scaleXY = 1;
        public double scaleXY
        {
            set { SetProperty(ref _scaleXY, value); }
            get { return _scaleXY; }
        }

        private int _rotaAngle;
        public int rotaAngle
        {
            set { SetProperty(ref _rotaAngle, value); }
            get { return _rotaAngle; }
        }

        //設定初始背景圖
        //private string _initial_picSource = "../Resources/cancel-music_1.png";
        private string _initial_picSource;
        public string initial_picSource
        {
            set { SetProperty(ref _initial_picSource, value); }
            get { return _initial_picSource; }
        }

        private string _mediaSource;
        public string mediaSource
        {
            set { SetProperty(ref _mediaSource, value); }
            get { return _mediaSource; }
        }

        private System.Windows.Media.ImageSource _picSource;
        public System.Windows.Media.ImageSource picSource
        {
            set { SetProperty(ref _picSource, value); }
            get { return _picSource; }
        }

        private string _titleBar = "ImageTraveler";
        public string titleBar
        {
            set { SetProperty(ref _titleBar, value); }
            get { return _titleBar; }
        }

        private double[] _GroupOpacity = new double[] { 1, 1, 1 };
        public double[] GroupOpacity
        {
            set
            {
                _GroupOpacity = value;
                OnPropertyChanged_Normal("GroupOpacity");
            }
            get { return _GroupOpacity; }
        }

        //[0]:InitialBorder
        //[1]:InkCanvas
        //[2]:mediaElement
        //value is 0 or 2
        private int[] _zIndex_group = { 2, 0, 0 };
        public int[] zIndex_group
        {
            set
            {
                _zIndex_group = value;
                OnPropertyChanged("zIndex_group");
            }
            get { return _zIndex_group; }
        }

        private double _mediaTimePosition = 0;
        public double mediaTimePosition
        {
            get { return _mediaTimePosition; }
            set
            {
                _mediaTimePosition = value;
                OnPropertyChanged_Normal("mediaTimePosition");
            }
        }

        private int _pic_error_code = 0;
        public int pic_error_code
        {
            get { return _pic_error_code; }
            set
            {
                _pic_error_code = value;
                OnPropertyChanged_Normal("pic_error_code");
            }
        }

        private Visibility _sliderVisible = Visibility.Collapsed;
        public Visibility sliderVisible
        {
            set
            {
                _sliderVisible = value;
                OnPropertyChanged_Normal("sliderOpa");
            }
            get { return _sliderVisible; }
        }

        private string _Btn_Group_Source = "ImageTraveler";
        public string Btn_Group_Source
        {
            set { SetProperty(ref _Btn_Group_Source, value); }
            get { return _Btn_Group_Source; }
        }

        private Visibility _Visible1 = Visibility.Collapsed;
        public Visibility Visible1
        {
            set
            {
                _Visible1 = value;
                OnPropertyChanged_Normal("Visible1");
            }
            get { return _Visible1; }
        }

        private bool _btnPre;
        public bool btnPre
        {
            set { SetProperty(ref _btnPre, value); }
            get { return _btnPre; }
        }

        private bool _btnNext;
        public bool btnNext
        {
            set { SetProperty(ref _btnNext, value); }
            get { return _btnNext; }
        }

        private bool _isDragging = false;
        public bool isDragging
        {
            set
            {
                _isDragging = value;
                OnPropertyChanged_Normal("isDragging");
            }
            get { return _isDragging; }
        }

        //非泛型寫法
        //private int _numOfLayers;
        //public int NumOfLayers
        //{
        //    get
        //    {
        //        return _numOfLayers;
        //    }

        //    set
        //    {
        //        this._numOfLayers = value;
        //        OnPropertyChanged("NumOfLayers");
        //    }
        //}
    }
}
