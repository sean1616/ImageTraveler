using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ImageTraveler.Utils
{
    public class MediaManager
    {
        public static List<string> GetMediaCollection(string path)
        {
            string[] mediaarray = Directory.GetFiles(path);
            var result = from mediastring in mediaarray
                         where mediastring.EndsWith("mp4", StringComparison.OrdinalIgnoreCase)
                         select mediastring;            
            return result.ToList();
        }
    }
}
