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
        private ListPlaylists _Playlists;
        private MediaPlaylist _CurrentPlaylist;
        private Uri _LastVideoSource;
        private string _Time;
        private string _DefaultTime;
        private bool _DispTotalMediaTime;
        private ColorStyle _Style;

        public MainWindow()
        {
            InitializeComponent();

            _timer.Interval = TimeSpan.FromMilliseconds(50);
            _timer.Tick += new EventHandler(timer_Tick);
            _Playlists = new ListPlaylists();
            _CurrentPlaylist = _Playlists._Current;
            _DefaultTime = "00:00:00";
            _DispTotalMediaTime = false;
            _Style = new ColorStyle();

            //this.WindowStyle = WindowStyle.None;

            MediaPlayer.MediaOpened += (o, e) =>
            {
                SeekBar.Maximum = MediaPlayer.NaturalDuration.TimeSpan.Seconds + (MediaPlayer.NaturalDuration.TimeSpan.Minutes * 60) + (MediaPlayer.NaturalDuration.TimeSpan.Hours * 360);
            };
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
