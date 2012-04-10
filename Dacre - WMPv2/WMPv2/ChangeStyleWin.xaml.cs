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
        public event EventHandler<EventArgs> End_window;
        private string _saveMenuBackground;
        private string _saveMenuForeground;
        private string _savePannelBackground;
        private string _savePannelForeground;
        private string _saveLibraryBackground;
        private string _saveLibraryForeground;

        public ChangeStyleWin()
        {
            InitializeComponent();

            _saveMenuBackground = Locator.WMPLocator.MainStaticStyle._ColorStyle._MenuBackground;
            _saveMenuForeground = Locator.WMPLocator.MainStaticStyle._ColorStyle._MenuForeground;
            _savePannelBackground = Locator.WMPLocator.MainStaticStyle._ColorStyle._PannelBackground;
            _savePannelForeground = Locator.WMPLocator.MainStaticStyle._ColorStyle._PannelForeground;
            _saveLibraryBackground = Locator.WMPLocator.MainStaticStyle._ColorStyle._LibraryBackground;
            _saveLibraryForeground = Locator.WMPLocator.MainStaticStyle._ColorStyle._LibraryForeground;
            CanvasMenuBackground.SelectedColor = (Color)ColorConverter.ConvertFromString(_saveMenuBackground);
            CanvasMenuForeground.SelectedColor = (Color)ColorConverter.ConvertFromString(_saveMenuForeground);
            CanvasPannelBackground.SelectedColor = (Color)ColorConverter.ConvertFromString(_savePannelBackground);
            CanvasPannelForeground.SelectedColor = (Color)ColorConverter.ConvertFromString(_savePannelForeground);
            CanvasLibraryBackground.SelectedColor = (Color)ColorConverter.ConvertFromString(_saveLibraryBackground);
            CanvasLibraryForeground.SelectedColor = (Color)ColorConverter.ConvertFromString(_saveLibraryForeground);
        }

        private void SetMenuBackground(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            ColorConverter.ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._MenuBackground = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}",
                MenuBackgroundRect.Color.A, MenuBackgroundRect.Color.R, MenuBackgroundRect.Color.G, MenuBackgroundRect.Color.B));
            if (sender != null && End_window != null)
                End_window(sender, new EventArgs());
        }

        private void SetMenuForeground(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            ColorConverter.ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._MenuForeground = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}",
                MenuForegroundRect.Color.A, MenuForegroundRect.Color.R, MenuForegroundRect.Color.G, MenuForegroundRect.Color.B));
            if (sender != null && End_window != null)
                End_window(sender, new EventArgs());
        }

        private void SetPannelBackground(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            ColorConverter.ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._PannelBackground = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}",
                PannelBackgroundRect.Color.A, PannelBackgroundRect.Color.R, PannelBackgroundRect.Color.G, PannelBackgroundRect.Color.B));
            if (sender != null && End_window != null)
                End_window(sender, new EventArgs());
        }

        private void SetPannelForeground(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            ColorConverter.ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._PannelForeground = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}",
                PannelForegroundRect.Color.A, PannelForegroundRect.Color.R, PannelForegroundRect.Color.G, PannelForegroundRect.Color.B));
            if (sender != null && End_window != null)
                End_window(sender, new EventArgs());
        }

        private void SetLibraryBackground(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            ColorConverter.ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._LibraryBackground = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}",
                LibraryBackgroundRect.Color.A, LibraryBackgroundRect.Color.R, LibraryBackgroundRect.Color.G, LibraryBackgroundRect.Color.B));
            if (sender != null && End_window != null)
                End_window(sender, new EventArgs());
        }

        private void SetLibraryForeground(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            ColorConverter.ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._LibraryForeground = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}",
                LibraryForegroundRect.Color.A, LibraryForegroundRect.Color.R, LibraryForegroundRect.Color.G, LibraryForegroundRect.Color.B));
            if (sender != null && End_window != null)
                End_window(sender, new EventArgs());
        }
        
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Locator.WMPLocator.MainStaticStyle._ColorStyle._MenuBackground = _saveMenuBackground;
            Locator.WMPLocator.MainStaticStyle._ColorStyle._MenuForeground = _saveMenuForeground;
            Locator.WMPLocator.MainStaticStyle._ColorStyle._PannelBackground = _savePannelBackground;
            Locator.WMPLocator.MainStaticStyle._ColorStyle._PannelForeground = _savePannelForeground;
            Locator.WMPLocator.MainStaticStyle._ColorStyle._LibraryBackground = _saveLibraryBackground;
            Locator.WMPLocator.MainStaticStyle._ColorStyle._LibraryForeground = _saveLibraryForeground;
            End_window(this, new EventArgs());
            this.Close();
        }

    }
}
