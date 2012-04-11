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
    [Serializable]
    public class ColorStyle : ViewModelBase
    {
        public string _MenuBackground { get; set; }
        public string _MenuForeground { get; set; }
        public string _PannelBackground { get; set; }
        public string _PannelForeground { get; set; }
        public string _LibraryBackground { get; set; }
        public string _LibraryForeground { get; set; }

        //{
        //    get { return _MenuBackgroundColor; }
        //    set {
        //        _MenuBackgroundColor = value;
        //        _MenuBackgroundBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(_MenuBackgroundColor));
        //        }
        //}
        //public Brush _MenuBackgroundBrush;

        public ColorStyle()
        {
            _MenuBackground = "#FF1A1A1A";
            _MenuForeground = "#FF707070";
            _PannelBackground = "#FF212121";
            _PannelForeground = "#FFA7A7A7";
            _LibraryBackground = "#FFB8B8B8";
            _LibraryForeground = "#FFA7A7A7";
        }

    }
}
