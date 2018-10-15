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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageTraveler.Style_Resources
{
    /// <summary>
    /// ProgressBar_sty1.xaml 的互動邏輯
    /// </summary>
    public partial class ProgressBar_sty1 : UserControl
    {
        public ProgressBar_sty1()
        {
            InitializeComponent();
        }

        private void ProgressBarControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            MySlider.Value = Value;
        }
        #region 屬性
        /// <summary>
        /// 進度條值
        /// </summary>
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set
            {
                SetValue(ValueProperty, value);
            }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double)
        , typeof(ProgressBar_sty1), new PropertyMetadata(1.0));


        #endregion
    }
}
