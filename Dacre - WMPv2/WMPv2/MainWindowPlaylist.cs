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
            Locator.WMPLocator.MainStaticListPlaylists.XMLSavePlaylist();
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
            Locator.WMPLocator.MainStaticListPlaylists.OpenPlaylistfromXML(openwin.FileName);
            UpdatePannelPlaylist();
        }

        public void PlaylistNameEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                toChange = true;
                NewPlaylistName(sender);
                UnfocusGrid.IsEnabled = false;
            }

        }

        public void NewPlaylistName(object sender, TextChangedEventArgs e = null)
        {
            if (toChange)
                Locator.WMPLocator.MainStaticListPlaylists._Current._Name_s = PannelPlaylistName.Text;
            toChange = false;
        }

        private void DoubleClickPannelList(Object sender, MouseEventArgs e)
        {
            string name;
            string source;
            int from;
            //List<string> test;
            //test = Locator.WMPLocator.MainStaticListPlaylists._Current._Playlist;
            source = e.Source.ToString();
            from = source.IndexOf(": ") + 2;
            name = source.Substring(from);
            LoadFile(name);
        }

        private void OnWindowClick(Object sender, MouseEventArgs e)
        {
            if (!PannelPlaylistName.IsMouseOver)
            {
                UnfocusGrid.IsEnabled = false;
            }
        }

        private void UpdatePannelPlaylist()
        {
            BitmapImage logo = new BitmapImage();

            logo.BeginInit();
            logo.UriSource = new Uri(Locator.WMPLocator.MainStaticListPlaylists._Current._Image_s, UriKind.Relative);
            logo.EndInit();
            PlaylistImage.Source = logo;
            PannelPlaylistName.Text = Locator.WMPLocator.MainStaticListPlaylists._Current._Name_s;
            PannelPlaylistList.ItemsSource = Locator.WMPLocator.MainStaticListPlaylists._Current._Playlist;
        }
    }
}
