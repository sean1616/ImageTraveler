using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace ImageTraveler
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        public static MainWindow mainWindow;

        [STAThread]
        public static void Main(string[] args)
        {
            Lierda.WPFHelper.LierdaCracker cracker = new Lierda.WPFHelper.LierdaCracker();
            cracker.Cracker(100);

            //多載寫法
            var application = new App();
            application.InitializeComponent();
            if (args.Length == 0)
            {
                //application.Run();
                mainWindow = new MainWindow();
                application.Run(mainWindow);
            }                
            else
            {                                               
                mainWindow = new MainWindow(args[0].ToString());
                application.Run(mainWindow);
            }
        }
    }
}
