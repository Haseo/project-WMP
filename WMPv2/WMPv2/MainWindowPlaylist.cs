using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace WMPv2
{
    public partial class MainWindow : Window
    {
        private bool toChange;

        public void SavePlaylistClick(object sender, EventArgs e)
        {
            //     Locator.WMPLocator.MainStaticListPlaylists.XMLSavePlaylist();
            Locator.WMPLocator.SaveCurrent();
            PlaylistBox.BeginInit();
            PlaylistBox.ItemsSource = _playlists._PlaylistList;
            PlaylistBox.EndInit();

            if (type_disp == Type_librarydisp.all_playlist)
            {
                LibraryGrid.BeginInit();
                LibraryGrid.DataContext = _playlists;
                LibraryGrid.EndInit();
            }
        }

        public void OpenPlaylistClick(object sender, EventArgs e)
        {

            Microsoft.Win32.OpenFileDialog openwin;

            MediaTimeDisp.Text = null;
            openwin = new Microsoft.Win32.OpenFileDialog();
            openwin.AddExtension = true;
            openwin.DefaultExt = "*.xml*";
            openwin.Filter = "XML Files (*.xml)|*.xml|All (*.*)|*.*";
            openwin.ShowDialog();
            //  Locator.WMPLocator.MainStaticListPlaylists.OpenPlaylistfromXML(openwin.FileName);
            UpdatePannelPlaylist();
        }

        public void PlaylistKey(object sender, KeyEventArgs e)
        {
            if (PannelPlaylistList.Focus() == true || PannelPlaylistList.IsKeyboardFocused == true)
            {
                if (e.Key == Key.Enter)
                {
                    if (Locator.WMPLocator.Exist(PannelPlaylistList.SelectedIndex) == true)
                        LoadFile(Locator.WMPLocator.At(PannelPlaylistList.SelectedIndex));
                }
                if (e.Key == Key.Back)
                {
                    if (Locator.WMPLocator.Exist(PannelPlaylistList.SelectedIndex) == true)
                        Locator.WMPLocator.Remove(PannelPlaylistList.SelectedIndex);
                    UpdatePannelPlaylist();
                }
                if (e.Key == Key.Delete)
                {
                    if (Locator.WMPLocator.Exist(PannelPlaylistList.SelectedIndex) == true)
                        Locator.WMPLocator.Remove(PannelPlaylistList.SelectedIndex);
                    UpdatePannelPlaylist();
                }
            }
        }

        public void NewPlaylistName(object sender, TextChangedEventArgs e = null)
        {
            Locator.WMPLocator._currentName = PannelPlaylistName.Text;
        }

        private void DoubleClickPannelList(Object sender, MouseEventArgs e)
        {
            if (Locator.WMPLocator.Exist(PannelPlaylistList.SelectedIndex) == true)
            {
                LoadFile(Locator.WMPLocator.At(PannelPlaylistList.SelectedIndex));
            }
        }

        private void OnWindowClick(Object sender, MouseEventArgs e)
        {
            if (!PannelPlaylistName.IsMouseOver)
            {
              //  UnfocusGrid.IsEnabled = false;
            }
        }

        private void UpdatePannelPlaylist()
        {
            BitmapImage logo = new BitmapImage();

            logo.BeginInit();
            logo.UriSource = new Uri(Locator.WMPLocator._currentImg, UriKind.Relative);
            logo.EndInit();
            PlaylistImage.Source = logo;
            PannelPlaylistName.Text = Locator.WMPLocator._currentName;
            PannelPlaylistList.ItemsSource = null;
            PannelPlaylistList.ItemsSource = Locator.WMPLocator._currentlist;
        }
    }
}
