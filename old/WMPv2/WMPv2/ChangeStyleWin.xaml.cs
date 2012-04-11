using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WMPv2
{
    /// <summary>
    /// Interaction logic for ChangeStyleWin.xaml
    /// </summary>
    public partial class ChangeStyleWin : Window
    {

		public ColorStyle	myColors;
		
        public ChangeStyleWin(ColorStyle colors)
        {
            InitializeComponent();

			myColors = colors;
            CanvasMenuBackground.SelectedColor = (Color)ColorConverter.ConvertFromString(myColors._MenuBackgroundColor);
        }

        private void SetMenuBackground(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            myColors._MenuBackgroundColor = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}",
                MenuBackgroundRect.Color.A, MenuBackgroundRect.Color.R, MenuBackgroundRect.Color.G, MenuBackgroundRect.Color.B);
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            myColors._MenuBackgroundColor = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}",
                MenuBackgroundRect.Color.A, MenuBackgroundRect.Color.R, MenuBackgroundRect.Color.G, MenuBackgroundRect.Color.B);
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
