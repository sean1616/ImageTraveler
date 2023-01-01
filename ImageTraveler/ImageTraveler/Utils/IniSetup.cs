using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ImageTraveler.Utils
{
    public class IniSetup
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
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            WritePrivateProfileString(Section, Key, Value, System.IO.Path.Combine(path + inipath));
            //WritePrivateProfileString(Section, Key, Value, @"d:\ImagTraver\" + inipath);

        }

        //ini read
        public string IniReadValue(string Section, string Key, string inipath)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, System.IO.Path.Combine(path + inipath));

            //int i = GetPrivateProfileString(Section, Key, "", temp, 255, @"d:\ImagTraver\" + inipath);
            return temp.ToString();
        }
    }
}
