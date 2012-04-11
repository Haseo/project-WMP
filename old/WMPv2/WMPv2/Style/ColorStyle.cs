using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using GalaSoft.MvvmLight;

namespace WMPv2
{
    public class ColorStyle : ViewModelBase
    {
        public string _MenuBackgroundColor;
        //{
        //    get { return _MenuBackgroundColor; }
        //    set {
        //        _MenuBackgroundColor = value;
        //        _MenuBackgroundBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_MenuBackgroundColor));
        //        }
        //}
        public Brush _MenuBackgroundBrush;

        public ColorStyle()
        {
            _MenuBackgroundColor = "#FF1A1A1A";
        }
    }
}
