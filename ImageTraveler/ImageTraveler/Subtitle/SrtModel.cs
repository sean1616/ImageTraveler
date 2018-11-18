using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ImageTraveler.Subtitle
{
    //接收從srt文件讀取的文件格式
    public class SrtModel
    {
        private int beginTime;
        private int endTime;
        private string srtString;
        private int index;
        public int BeginTime { get => beginTime; set => beginTime = value; }
        public int EndTime { get => endTime; set => endTime = value; }
        public string SrtString { get => srtString; set => srtString = value; }
        public int Index { get => index; set => index = value; }
    }

    //解析字幕文件
    public class SrtHelper
    {
        //定义一个ModelList的列表用于接受从文件读取的内容
        private static List<SrtModel> mySrtModelList;        

        //定义一个获取当前时间显示的string的方法
        public static string GetTimeString(int timeMile)
        {
            String currentTimeTxt = "";
            if (mySrtModelList != null)
            {
                foreach (SrtModel sm in mySrtModelList)
                {
                    if (timeMile > sm.BeginTime && timeMile < sm.EndTime)
                    {
                        currentTimeTxt = sm.SrtString;
                    }
                }

            }
            return currentTimeTxt;
        }

        //读取文件中的内容到mySrtModelList列表
        public static List<SrtModel> ParseSrt(string srtPath)
        {
            mySrtModelList = new List<SrtModel>();
            string line;
            using (FileStream fs = new FileStream(srtPath, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Default))
                {
                    StringBuilder sb = new StringBuilder();
                    while ((line = sr.ReadLine()) != null)
                    {

                        if (!line.Equals(""))
                        {
                            sb.Append(line).Append("@");
                            continue;
                        }

                        string[] parseStrs = sb.ToString().Split('@');
                        if (parseStrs.Length < 3)
                        {
                            sb.Remove(0, sb.Length);// 清空，否则影响下一个字幕元素的解析</i>  
                            continue;
                        }

                        SrtModel srt = new SrtModel();
                        string strToTime = parseStrs[1];
                        int beginHour = int.Parse(strToTime.Substring(0, 2));
                        int begin_mintue = int.Parse(strToTime.Substring(3, 2));
                        int begin_scend = int.Parse(strToTime.Substring(6, 2));
                        int begin_milli = int.Parse(strToTime.Substring(9, 3));
                        int beginTime = (beginHour * 3600 + begin_mintue * 60 + begin_scend) * 1000 + begin_milli;

                        int end_hour = int.Parse(strToTime.Substring(17, 2));
                        int end_mintue = int.Parse(strToTime.Substring(20, 2));
                        int end_scend = int.Parse(strToTime.Substring(23, 2));
                        int end_milli = int.Parse(strToTime.Substring(26, 2));
                        int endTime = (end_hour * 3600 + end_mintue * 60 + end_scend) * 1000 + end_milli;

                        srt.BeginTime = beginTime;
                        srt.EndTime = endTime;
                        string strBody = null;
                        for (int i = 2; i < parseStrs.Length; i++)
                        {
                            strBody += parseStrs[i];
                        }
                        srt.SrtString = strBody;
                        mySrtModelList.Add(srt);
                        sb.Remove(0, sb.Length);
                    }


                }

            }
            return mySrtModelList;
        }
    }
}
