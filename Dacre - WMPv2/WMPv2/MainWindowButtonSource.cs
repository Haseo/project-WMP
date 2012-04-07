using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WMPv2
{
    public partial class MainWindow : Window
    {

        private void ShowMediaControl(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                CommandGrid.Opacity = 100;
        }

        private void HideMediaControl(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                CommandGrid.Opacity = 0;
        }

        private void ShowLibrary(object sender, EventArgs e)
        {
            SwapPlayButton.Visibility = System.Windows.Visibility.Visible;
            SwapLibraryButton.Visibility = System.Windows.Visibility.Hidden;
            MediaGrid.Visibility = System.Windows.Visibility.Hidden;
            LibraryGrid.Visibility = System.Windows.Visibility.Visible;
        }

        private void ShowPlay(object sender, EventArgs e)
        {
            SwapPlayButton.Visibility = System.Windows.Visibility.Hidden;
            SwapLibraryButton.Visibility = System.Windows.Visibility.Visible;
            MediaGrid.Visibility = System.Windows.Visibility.Visible;
            LibraryGrid.Visibility = System.Windows.Visibility.Hidden;
        }

        private void ButtonEnter(object sender, EventArgs e)
        {
            BitmapImage logo = new BitmapImage();

            logo.BeginInit();
            if (sender == PlayButton)
            {
                if (isPause)
                    logo.UriSource = new Uri(@"Images\PlayOver.png", UriKind.Relative);
                else
                    logo.UriSource = new Uri(@"Images\PauseOver.png", UriKind.Relative);
                logo.EndInit();
                PlayButton.Source = logo;
            }
            if (sender == StopButton)
            {
                logo.UriSource = new Uri(@"Images\StopOver.png", UriKind.Relative);
                logo.EndInit();
                StopButton.Source = logo;
            }
            if (sender == VolumeButton)
            {
                if (MediaPlayer.Volume == 0)
                    logo.UriSource = new Uri(@"Images\SoundOffOver.png", UriKind.Relative);
                else
                    logo.UriSource = new Uri(@"Images\SoundOnOver.png", UriKind.Relative);
                logo.EndInit();
                VolumeButton.Source = logo;
            }
            if (sender == FullScreenButton)
            {
                if (this.WindowState == WindowState.Maximized)
                    logo.UriSource = new Uri(@"Images\LowScreenOver.png", UriKind.Relative);
                else
                    logo.UriSource = new Uri(@"Images\FullScreenOver.png", UriKind.Relative);
                logo.EndInit();
                FullScreenButton.Source = logo;
            }
            if (sender == ShowPannelButton)
            {
                if (!isPannelShow)
                    logo.UriSource = new Uri(@"Images\ShowPannelOver.png", UriKind.Relative);
                else
                    logo.UriSource = new Uri(@"Images\HidePannelOver.png", UriKind.Relative);
                logo.EndInit();
                ShowPannelButton.Source = logo;
            }
        }

        private void ButtonLeave(object sender, EventArgs e)
        {
            BitmapImage logo = new BitmapImage();

            logo.BeginInit();
            if (sender == PlayButton)
            {
                if (isPause)
                    logo.UriSource = new Uri(@"Images\Play.png", UriKind.Relative);
                else
                    logo.UriSource = new Uri(@"Images\Pause.png", UriKind.Relative);
                logo.EndInit();
                PlayButton.Source = logo;
            }
            if (sender == StopButton)
            {
                logo.UriSource = new Uri(@"Images\Stop.png", UriKind.Relative);
                logo.EndInit();
                StopButton.Source = logo;
            }
            if (sender == VolumeButton)
            {
                if (MediaPlayer.Volume == 0)
                    logo.UriSource = new Uri(@"Images\SoundOff.png", UriKind.Relative);
                else
                    logo.UriSource = new Uri(@"Images\SoundOn.png", UriKind.Relative);
                logo.EndInit();
                VolumeButton.Source = logo;
            }
            if (sender == FullScreenButton)
            {
                if (this.WindowState == WindowState.Maximized)
                    logo.UriSource = new Uri(@"Images\LowScreen.png", UriKind.Relative);
                else
                    logo.UriSource = new Uri(@"Images\FullScreen.png", UriKind.Relative);
                logo.EndInit();
                FullScreenButton.Source = logo;
            }
            if (sender == ShowPannelButton)
            {
                if (!isPannelShow)
                    logo.UriSource = new Uri(@"Images\ShowPannel.png", UriKind.Relative);
                else
                    logo.UriSource = new Uri(@"Images\HidePannel.png", UriKind.Relative);
                logo.EndInit();
                ShowPannelButton.Source = logo;
            }
        }

    }
}
