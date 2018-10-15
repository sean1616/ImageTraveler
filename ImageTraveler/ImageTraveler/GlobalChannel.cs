using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageTraveler.ViewModels;

namespace ImageTraveler
{
    public class GlobalChannel
    {
        public static Main_VM main_VM { get; set; } = new Main_VM();
    }
}
