using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.ComponentModel;

namespace WMPv2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DispatcherTimer _timer = new DispatcherTimer();
        private bool isPlaying = false;
        private bool isPause = true;
        private Uri _LastVideoSource;
        private string _Time;
        private string _DefaultTime;
        private bool _DispTotalMediaTime;
        private ColorStyle _Style;

        public static LibraryViewModel _playlists;
        public static LibraryViewModel _music;
        public static LibraryViewModel _video;
        public static LibraryViewModel _image;

        String[] Img_type = new String[] 
        { ".bmp", ".efig", ".fits", ".gif",
          ".ief", ".jfif", ".jif", ".pcx",
          ".png", ".psid", ".ric", ".spf",
          ".sxd", ".tif", ".tiff", ".wmf",
          ".xbm", ".xpm", ".zei", ".jpg"};
        String[] Audio_type = new String[] 
        { ".aac", ".ac3", ".au", ".au3",
          ".avi", ".ac3", ".cda", ".m3u",
          ".m4a", ".m4r", ".maud", ".mp2",
          ".mp3", ".ogg", ".psid", ".raw",
          ".rso", ".sb", ".sf", ".smp",
          ".snd", ".voc", ".wav"};
        String[] Video_type = new String[] 
        { ".flv", ".mov", ".movie", ".mp4",
          ".qt", ".rv", ".vob", ".wmv"};
        String[] Streaming_type = new String[] 
        { ".asf", ".ra", ".rm", ".smil",
          ".ram", ".RMVB", ".rv"};

        public MainWindow()
        {
            InitializeComponent();

            _timer.Interval = TimeSpan.FromMilliseconds(50);
            _timer.Tick += new EventHandler(timer_Tick);
            _DefaultTime = "00:00:00";
            _DispTotalMediaTime = false;
            _Style = new ColorStyle();
            //this.WindowStyle = WindowStyle.None;

            MediaPlayer.MediaOpened += (o, e) =>
            {
                SeekBar.Maximum = MediaPlayer.NaturalDuration.TimeSpan.Seconds + (MediaPlayer.NaturalDuration.TimeSpan.Minutes * 60) + (MediaPlayer.NaturalDuration.TimeSpan.Hours * 360);
            };

            // Initialisation library
            MusiqueBox.ItemsSource = _music._PlaylistList;
            VideoBox.ItemsSource = _video._PlaylistList;
            ImageBox.ItemsSource = _image._PlaylistList;
            PlaylistBox.ItemsSource = _playlists._PlaylistList;
            LibraryGrid.DataContext = _playlists;
            dispAllPlaylist();

            // Initialisation Current Playlist
            BitmapImage logo = new BitmapImage();

            logo.BeginInit();
            logo.UriSource = new Uri(Locator.WMPLocator._currentImg, UriKind.Relative);
            logo.EndInit();
            PlaylistImage.Source = logo;
            PannelPlaylistName.Text = Locator.WMPLocator._currentName;
            PannelPlaylistList.ItemsSource = null;
            PannelPlaylistList.ItemsSource = Locator.WMPLocator._currentlist;

          
        }

        private void ShowVideo(object sender, EventArgs e)
        {
            MediaPlayer.Visibility = System.Windows.Visibility.Visible;
            ImagePlayer.Visibility = System.Windows.Visibility.Hidden;
            ImagePlayer.Source = null;
            if (_LastVideoSource != null)
                MediaPlayer.Source = _LastVideoSource;
        }

        private void ShowImage(object sender, EventArgs e)
        {
            ImagePlayer.Visibility = System.Windows.Visibility.Visible;
            MediaPlayer.Visibility = System.Windows.Visibility.Hidden;
            MediaPlayer.Source = null;
            Stop(sender, new RoutedEventArgs());
        }

        private void MediaEnd(object sender, EventArgs e)
        {
            this.Stop(sender, new RoutedEventArgs());
        }

        private void Quit(object sender = null, EventArgs e = null)
        {
            this.Close();
        }
    }
}
