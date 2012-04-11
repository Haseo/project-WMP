using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.Windows.Controls.Primitives;
using System.IO;
using System.Xml.Serialization;

namespace WMPv2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GridLength spliterWidth;
        private bool isPannelShow = false;
        private double panelSize = 225.0;

        private void KeyAction(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if ((e.Key == Key.F4 && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Alt) ||
                (e.Key == Key.Q && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control))
                Quit();
            if (e.Key == Key.O && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                this.Load(sender, e);
            if (e.Key == Key.Escape && this.WindowState.Equals(WindowState.Maximized))
                this.ChangeScreen(sender, e);
            if (e.Key == Key.Space)
                this.Play(sender, e);
        }

        private void ShowPannel(object sender, EventArgs e)
        {
            BitmapImage logo = new BitmapImage();

            logo.BeginInit();
            if (!isPannelShow)
            {
                spliterWidth = new GridLength(panelSize);
                isPannelShow = true;
                logo.UriSource = new Uri(@"Images\HidePannel.png", UriKind.Relative);
                PannelDrag.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                spliterWidth = new GridLength(0.0);
                isPannelShow = false;
                logo.UriSource = new Uri(@"Images\ShowPannel.png", UriKind.Relative);
                PannelDrag.Visibility = System.Windows.Visibility.Hidden;
            }
            logo.EndInit();

            this.ShowPannelButton.Source = logo;
            PannelGrid.Width = spliterWidth.Value;
            MediaGrid.Margin = new System.Windows.Thickness(0, 0, spliterWidth.Value, 0);
            LibraryGrid.Margin = new System.Windows.Thickness(0, 0, spliterWidth.Value, 0);
            PannelDrag.Margin = new System.Windows.Thickness(0, 0, spliterWidth.Value - 2, 0);
        }

        private void SetPannelSize(object sender, DragDeltaEventArgs e)
        {
            panelSize = -e.HorizontalChange + PannelDrag.Margin.Right;

            if (panelSize >= 150.0 && panelSize < ((PlayerWindow.Width / 10) * 6))
            {
                MediaGrid.Margin = new System.Windows.Thickness(0, 0, panelSize, 0);
                LibraryGrid.Margin = new System.Windows.Thickness(0, 0, panelSize, 0);
                PannelDrag.Margin = new System.Windows.Thickness(0, 0, panelSize - 2, 0);
                spliterWidth = new GridLength(PannelDrag.Margin.Right);
                PannelGrid.Width = panelSize;
            }
            else if (panelSize < 50.0)
            {
                panelSize = 225.0;
                ShowPannel(sender, e);
            }
        }

        private void UnfocusText(object sender, EventArgs e)
        {
            var scope = FocusManager.GetFocusScope(PannelPlaylistName); // elem is the UIElement to unfocus
            FocusManager.SetFocusedElement(scope, null); // remove logical focus
            Keyboard.ClearFocus();
            //            UnfocusPanel.Focus();
        }

        private void ChangeStyle(object sender, EventArgs e)
        {
            ChangeStyleWin style_win = new ChangeStyleWin();

            style_win.End_window += new EventHandler<EventArgs>(apply_style);
            style_win.Show();
        }

        public void apply_style(object sender, EventArgs value)
        {
            MenuGrid.BeginInit();
            CommandGrid.BeginInit();
            MenuLibraryGrid.BeginInit();
            PannelGrid.BeginInit();
            PannelDrag.BeginInit();
            PlaylistNameGrid.BeginInit();
            PlaylistNameBorder.BeginInit();
            PannelPlaylistList.BeginInit();
            PannelPlaylistName.BeginInit();
            MenuFile.BeginInit();
            MenuWindow.BeginInit();
            MenuStyle.BeginInit();
            MenuHelp.BeginInit();
            MenuLibPlaylistText.BeginInit();
            MenuLibMusiqueText.BeginInit();
            MenuLibVideoText.BeginInit();
            MenuLibImageText.BeginInit();

            MenuGrid.Background = new BrushConverter().ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._MenuBackground) as SolidColorBrush;
            CommandGrid.Background = new BrushConverter().ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._MenuBackground) as SolidColorBrush;
            MenuLibraryGrid.Background = new BrushConverter().ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._PannelBackground) as SolidColorBrush;
            PannelGrid.Background = new BrushConverter().ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._PannelBackground) as SolidColorBrush;
            PannelDrag.Background = new BrushConverter().ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._MenuBackground) as SolidColorBrush;
            PlaylistNameGrid.Background = new BrushConverter().ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._PannelBackground) as SolidColorBrush;
            PlaylistNameBorder.BorderBrush = new BrushConverter().ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._MenuBackground) as SolidColorBrush;
            PannelPlaylistList.Background = new BrushConverter().ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._PannelBackground) as SolidColorBrush;
            PannelPlaylistList.Foreground = new BrushConverter().ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._PannelForeground) as SolidColorBrush;
            PannelPlaylistName.Foreground = new BrushConverter().ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._PannelForeground) as SolidColorBrush;
            MenuFile.Foreground = new BrushConverter().ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._MenuForeground) as SolidColorBrush;
            MenuWindow.Foreground = new BrushConverter().ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._MenuForeground) as SolidColorBrush;
            MenuStyle.Foreground = new BrushConverter().ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._MenuForeground) as SolidColorBrush;
            MenuHelp.Foreground = new BrushConverter().ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._MenuForeground) as SolidColorBrush;
            MenuLibPlaylistText.Foreground = new BrushConverter().ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._LibraryForeground) as SolidColorBrush;
            MenuLibMusiqueText.Foreground = new BrushConverter().ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._LibraryForeground) as SolidColorBrush;
            MenuLibVideoText.Foreground = new BrushConverter().ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._LibraryForeground) as SolidColorBrush;
            MenuLibImageText.Foreground = new BrushConverter().ConvertFromString(Locator.WMPLocator.MainStaticStyle._ColorStyle._LibraryForeground) as SolidColorBrush;

            MenuGrid.EndInit();
            CommandGrid.EndInit();
            MenuLibraryGrid.EndInit();
            PannelGrid.EndInit();
            PannelDrag.EndInit();
            PlaylistNameGrid.EndInit();
            PlaylistNameBorder.EndInit();
            PannelPlaylistList.EndInit();
            PannelPlaylistName.EndInit();
            MenuFile.EndInit();
            MenuWindow.EndInit();
            MenuStyle.EndInit();
            MenuHelp.EndInit();
            MenuLibPlaylistText.EndInit();
            MenuLibMusiqueText.EndInit();
            MenuLibVideoText.EndInit();
            MenuLibImageText.EndInit();
        }

        private void About(object sender, EventArgs e)
        {
            var aboutWindow = new AboutWin();
            aboutWindow.Show();
        }

        private void SeekBarMoveOn(object sender, EventArgs e)
        {
            _timer.Stop();
            MediaPlayer.Position = TimeSpan.FromSeconds(SeekBar.Value);
            _timer.Start();
        }

    }
}