using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using System.IO;

namespace WMPv2
{
    public class ColorStyleModel : ViewModelBase
    {
        public ColorStyle _ColorStyle { get; set; }

        public ColorStyleModel()
        {
            _ColorStyle = new ColorStyle();
        }
    }
}
