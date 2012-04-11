using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Windows.Input;

namespace WMPv2
{
    public partial class MainWindow : Window
    {

        private void Play(object sender, RoutedEventArgs e)
        {
            BitmapImage logo = new BitmapImage();

            logo.BeginInit();
            if (MediaPlayer.Source != null)
            {
                if (!isPause)
                {
                    logo.UriSource = new Uri(@"Images\Play.png", UriKind.Relative);
                    logo.EndInit();
                    PlayButton.Source = logo;
                    MediaPlayer.Pause();
                    _timer.Stop();
                    isPause = true;
                }
                else
                {
                    logo.UriSource = new Uri(@"Images\Pause.png", UriKind.Relative);
                    logo.EndInit();
                    PlayButton.Source = logo;
                    MediaPlayer.Visibility = System.Windows.Visibility.Visible;
                    MediaPlayer.Play();
                    _timer.Start();
                    isPlaying = true;
                    isPause = false;
                }
            }
            else if (_LastVideoSource != null)
            {
                MediaPlayer.Source = _LastVideoSource;
                Play(sender, e);
            }
        }

        private void Stop(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                BitmapImage logo = new BitmapImage();

                logo.BeginInit();
                logo.UriSource = new Uri(@"Images\Play.png", UriKind.Relative);
                logo.EndInit();
                PlayButton.Source = logo;
                MediaPlayer.Stop();
                MediaPlayer.Source = null;
                _timer.Stop();
                isPlaying = false;
                isPause = true;
                MediaTimeDisp.Text = null;
            }
        }

        //private void LoadStream(object sender, EventArgs e)
        //{
        //    Microsoft.Win32.OpenFileDialog openwin;
        //    string extension;

        //    openwin = new Microsoft.Win32.OpenFileDialog();
        //    openwin.AddExtension = true;
        //    openwin.DefaultExt = "*.*";
        //    openwin.Filter = "All (*.*)|*.*|Video (*.avi, *.mpg, *.wmv)|*.avi;*.mpg;*.wmv|Image (*.jpg, *.png)|*.jpg;*.png";
        //    openwin.ShowDialog();
        //    if (openwin.FileName.Length > 0)
        //    {
        //        extension = openwin.FileName.Substring(openwin.FileName.Length - 4);
        //        if (extension == ".avi" || extension == ".mpg" || extension == ".wmv")
        //        {
        //            _LastVideoSource = new Uri(openwin.FileName);
        //            ShowVideo(sender, e);
        //        }
        //        if (string.Equals(extension, ".jpg", StringComparison.CurrentCultureIgnoreCase) || string.Equals(extension, ".png", StringComparison.CurrentCultureIgnoreCase))
        //        {
        //            BitmapImage logo = new BitmapImage();

        //            logo.BeginInit();
        //            logo.UriSource = new Uri(openwin.FileName);
        //            logo.EndInit();
        //            this.ImagePlayer.Source = logo;
        //            ShowImage(sender, e);
        //        }
        //    }
        //}

        private void Load(object sender, EventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openwin;

            MediaTimeDisp.Text = null;
            openwin = new Microsoft.Win32.OpenFileDialog();
            openwin.AddExtension = true;
            openwin.DefaultExt = "*.*";
            openwin.Filter = "All (*.*)|*.*|Video (*.avi, *.mpg, *.wmv)|*.avi;*.mpg;*.wmv|Image (*.jpg, *.png)|*.jpg;*.png|Musique (*.wma, *.mp3, *.wav)|*.wma;*.mp3;*.wav" ;
            openwin.ShowDialog();
            LoadFile(openwin);
        }

        private void LoadFile(OpenFileDialog openwin)
        {
            string extension;

            if (openwin.FileName.Length > 0)
            {
                extension = openwin.FileName.Substring(openwin.FileName.Length - 4);
                if (extension == ".avi" || extension == ".mpg" || extension == ".wmv" || extension == ".wma" || extension == ".mp3" || extension == ".wav")
                {
                    calcMediaTime();
                    _LastVideoSource = new Uri(openwin.FileName);
                    ShowVideo(new object(), new EventArgs());
                    MediaTimeDisp.Text = _DefaultTime;
                }
                if (string.Equals(extension, ".jpg", StringComparison.CurrentCultureIgnoreCase) || string.Equals(extension, ".png", StringComparison.CurrentCultureIgnoreCase))
                {
                    BitmapImage logo = new BitmapImage();

                    logo.BeginInit();
                    logo.UriSource = new Uri(openwin.FileName);
                    logo.EndInit();
                    this.ImagePlayer.Source = logo;
                    ShowImage(new object(), new EventArgs());
                }
                Locator.WMPLocator.MainStaticListPlaylists._Current.addElemtoPlaylist(openwin.FileName);
                UpdatePannelPlaylist();
            }
        }

        private void LoadFile(string filename)
        {
            string extension;
            Microsoft.Win32.OpenFileDialog openwin = new Microsoft.Win32.OpenFileDialog();

            openwin.FileName = filename.ToString();
            if (openwin.FileName.Length > 0)
            {
                extension = openwin.FileName.Substring(openwin.FileName.Length - 4);
                if (extension == ".avi" || extension == ".mpg" || extension == ".wmv" || extension == ".wma" || extension == ".mp3" || extension == ".wav")
                {
                    calcMediaTime();
                    _LastVideoSource = new Uri(openwin.FileName);
                    ShowVideo(new object(), new EventArgs());
                    MediaTimeDisp.Text = _DefaultTime;
                }
                if (string.Equals(extension, ".jpg", StringComparison.CurrentCultureIgnoreCase) || string.Equals(extension, ".png", StringComparison.CurrentCultureIgnoreCase))
                {
                    BitmapImage logo = new BitmapImage();

                    logo.BeginInit();
                    logo.UriSource = new Uri(filename);
                    logo.EndInit();
                    this.ImagePlayer.Source = logo;
                    ShowImage(new object(), new EventArgs());
                }
                if (isPause)
                    Play(new object(), new RoutedEventArgs());
            }
        }
        
        private void ChangeScreen(object sender, EventArgs e)
        {
            BitmapImage logo = new BitmapImage();

            logo.BeginInit();
            if (this.WindowState.Equals(WindowState.Normal))
            {
                logo.UriSource = new Uri(@"Images\LowScreen.png", UriKind.Relative);
                logo.EndInit();
                this.FullScreenButton.Source = logo;
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
                CommandGrid.Opacity = 0;
                PlayGrid.Margin = new System.Windows.Thickness(0, 22, 0, 0);
                ActiveGrid.Margin = new System.Windows.Thickness(0, 30, 0, 0);
            }
            else
            {
                logo.UriSource = new Uri(@"Images\FullScreen.png", UriKind.Relative);
                logo.EndInit();
                this.FullScreenButton.Source = logo;
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.WindowState = WindowState.Normal;
                CommandGrid.Opacity = 100;
                PlayGrid.Margin = new System.Windows.Thickness(0, 22, 0, 30);
                ActiveGrid.Margin = new System.Windows.Thickness(0, 30, 0, 28);
                if (isPannelShow)
                {
                    panelSize = 225.0;
                    MediaGrid.Margin = new System.Windows.Thickness(0, 0, panelSize, 0);
                    LibraryGrid.Margin = new System.Windows.Thickness(0, 0, panelSize, 0);
                    PannelDrag.Margin = new System.Windows.Thickness(0, 0, panelSize, 0);
                    PannelGrid.Width = panelSize;
                }
            }
        }

        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            BitmapImage logo = new BitmapImage();

            logo.BeginInit();
            if (VolumeSlider.Value == 0 && MediaPlayer.Volume != 0)
            {
                logo.UriSource = new Uri(@"Images\SoundOff.png", UriKind.Relative);
                logo.EndInit();
                this.VolumeButton.Source = logo;
            }
            else if (VolumeSlider.Value > 0 && MediaPlayer.Volume == 0)
            {
                logo.UriSource = new Uri(@"Images\SoundOn.png", UriKind.Relative);
                logo.EndInit();
                this.VolumeButton.Source = logo;
            }
            MediaPlayer.Volume = (double)VolumeSlider.Value / 100;
        }

        private void SwapVolume(object sender, EventArgs e)
        {
            RoutedPropertyChangedEventArgs<double> even;

            if (MediaPlayer.Volume == 0)
            {
                even = new RoutedPropertyChangedEventArgs<double>(VolumeSlider.Value, 50.0);
                VolumeSlider.Value = 50;
            }
            else
            {
                even = new RoutedPropertyChangedEventArgs<double>(VolumeSlider.Value, 0.0);
                VolumeSlider.Value = 0;
            }
            ChangeMediaVolume(sender, even);
        }

        private void calcMediaTime()
        {
            string totalTime;

            if (MediaPlayer.Position.Hours < 10)
                _Time = "0" + MediaPlayer.Position.Hours + ":";
            else
                _Time = MediaPlayer.Position.Hours + ":";
            if (MediaPlayer.Position.Minutes < 10)
                _Time += "0";
            _Time += MediaPlayer.Position.Minutes + ":";
            if (MediaPlayer.Position.Seconds < 10)
                _Time += "0";
            _Time += MediaPlayer.Position.Seconds;

            if (_DispTotalMediaTime)
            {
                totalTime = MediaPlayer.NaturalDuration.ToString().Substring(0, 8);
                _Time += "/" + totalTime;
            }
            MediaTimeDisp.Text = _Time;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            double tPass = MediaPlayer.Position.TotalSeconds;

            SeekBar.Value = tPass;
            calcMediaTime();
        }

        private void DragStart(object sender, MouseEventArgs e)
        {
            _timer.Stop();
        }

        private void DragComplete(object sender, EventArgs e)
        {
            MediaPlayer.Position = TimeSpan.FromSeconds(SeekBar.Value);
            _timer.Start();
//            Play(sender, new RoutedEventArgs());
        }

    }
}
