using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Input;

namespace WMPv2
{
    public partial class MainWindow : Window
    {

        private bool isPlaylistExpand = false;
        private bool isMusiqueExpand = false;
        private bool isVideoExpand = false;
        private bool isImageExpand = false;

        void changeExpandLogo(Image image, bool expanded)
        {
            BitmapImage logo = new BitmapImage();

            logo.BeginInit();
            if (expanded)
                logo.UriSource = new Uri(@"Images\LibraryExpanded.png", UriKind.Relative);
            else
                logo.UriSource = new Uri(@"Images\LibraryExpand.png", UriKind.Relative);
            logo.EndInit();
            image.Source = logo;
        }

        #region Expand
        void ExpandPlaylist(object sender, EventArgs e)
        {
            if (!isPlaylistExpand)
            {
                double size;

                size = 8 + ((Locator.WMPLocator.MainStaticListPlaylists._Names.Count + 1) * 16);
                if (size == 0.0)
                    size = 21;
                changeExpandLogo(MenuLibPlaylistOpen, true);
                MenuLibraryRow0.Height = new System.Windows.GridLength(size);
                isPlaylistExpand = true;
            }
            else
            {
                isPlaylistExpand = false;
                changeExpandLogo(MenuLibPlaylistOpen, false);
                MenuLibraryRow0.Height = new System.Windows.GridLength(20.0);
            }
        }

        void ExpandMusique(object sender, EventArgs e)
        {
            if (!isMusiqueExpand)
            {
                changeExpandLogo(MenuLibMusiqueOpen, true);
                MenuLibraryRow1.Height = new System.Windows.GridLength(60.0);
                isMusiqueExpand = true;
            }
            else
            {
                isMusiqueExpand = false;
                changeExpandLogo(MenuLibMusiqueOpen, false);
                MenuLibraryRow1.Height = new System.Windows.GridLength(20.0);
            }
        }

        void ExpandVideo(object sender, EventArgs e)
        {
            if (!isVideoExpand)
            {
                changeExpandLogo(MenuLibVideoOpen, true);
                MenuLibraryRow2.Height = new System.Windows.GridLength(60.0);
                isVideoExpand = true;
            }
            else
            {
                isVideoExpand = false;
                changeExpandLogo(MenuLibVideoOpen, false);
                MenuLibraryRow2.Height = new System.Windows.GridLength(20.0);
            }
        }

        void ExpandImage(object sender, EventArgs e)
        {
            if (!isImageExpand)
            {
                changeExpandLogo(MenuLibImageOpen, true);
                MenuLibraryRow3.Height = new System.Windows.GridLength(60.0);
                isImageExpand = true;
            }
            else
            {
                isImageExpand = false;
                changeExpandLogo(MenuLibImageOpen, false);
                MenuLibraryRow3.Height = new System.Windows.GridLength(20.0);
            }
        }
        #endregion

        #region Show
        void ShowLibraryPlaylist(object sender, EventArgs e)
        {

        }

        void ShowLibraryMusique(object sender, EventArgs e)
        {

        }

        void ShowLibraryVideo(object sender, EventArgs e)
        {

        }

        void ShowLibraryImage(object sender, EventArgs e)
        {

        }
        #endregion

        #region DoubleClick
        private void DoubleClickLibPlaylist(Object sender, MouseEventArgs e)
        {
            string name;
            string source;
            int from;

            source = e.Source.ToString();
            from = source.IndexOf(": ") + 2;
            name = source.Substring(from);
            //name = nom ou chemin de l'élément cliqué
            //Mettre ici l'action à réaliser
        }

        private void DoubleClickLibMusique(Object sender, MouseEventArgs e)
        {
            string name;
            string source;
            int from;

            source = e.Source.ToString();
            from = source.IndexOf(": ") + 2;
            name = source.Substring(from);
            //name = nom ou chemin de l'élément cliqué
            //Mettre ici l'action à réaliser
        }

        private void DoubleClickLibVideo(Object sender, MouseEventArgs e)
        {
            string name;
            string source;
            int from;

            source = e.Source.ToString();
            from = source.IndexOf(": ") + 2;
            name = source.Substring(from);
            //name = nom ou chemin de l'élément cliqué
            //Mettre ici l'action à réaliser
        }

        private void DoubleClickLibImage(Object sender, MouseEventArgs e)
        {
            string name;
            string source;
            int from;

            source = e.Source.ToString();
            from = source.IndexOf(": ") + 2;
            name = source.Substring(from);
            //name = nom ou chemin de l'élément cliqué
            //Mettre ici l'action à réaliser
        }

        #endregion


        void AddLibPlaylist(object sender, EventArgs e)
        {
            string name = "New...";

            if (isPlaylistExpand)
                ExpandPlaylist(new object(), new EventArgs());
            Locator.WMPLocator.MainStaticListPlaylists._Names.Add(name);
            PlaylistBox.ItemsSource = null;
            PlaylistBox.ItemsSource = Locator.WMPLocator.MainStaticListPlaylists._Names;
            ExpandPlaylist(new object(), new EventArgs());
        }
    }
}
