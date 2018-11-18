using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using ImageTraveler;

namespace ImageTraveler.Utils
{
    public class LoadFileClass
    {        
        //對話框
        OpenFileDialog fileDialog;
                
        //對話視窗
        public OpenFileDialog openFileDialog()
        {
            //string imgPathExtension;

            fileDialog = new OpenFileDialog();

            fileDialog.Filter = "(All file(*.*)|*.*|圖片文件(*.jpg;*.bmp;*.png..)|*.jpg;*.bmp;*.png;*.gif|影音文件(*.mp3;*.mp4;*.wmv..)|*.mp3;*.mp4;*.wmv;*.flv;*.avi;*.rmvb";
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            fileDialog.ShowDialog();
           
            return fileDialog;
        }                
    }            
}
