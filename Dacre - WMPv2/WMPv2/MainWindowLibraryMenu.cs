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
            if (MenuLibraryRow0.ActualHeight < 21)
            {
                double size;

                size = Locator.WMPLocator.MainStaticListPlaylists._Names.Count * 28;
                changeExpandLogo(MenuLibPlaylistOpen, true);
                MenuLibraryRow0.Height = new System.Windows.GridLength(size);
            }
            else
            {
                changeExpandLogo(MenuLibPlaylistOpen, false);
                MenuLibraryRow0.Height = new System.Windows.GridLength(20.0);
            }
        }

        void ExpandMusique(object sender, EventArgs e)
        {
            if (MenuLibraryRow1.ActualHeight < 21)
            {
                changeExpandLogo(MenuLibMusiqueOpen, true);
                MenuLibraryRow1.Height = new System.Windows.GridLength(60.0);
            }
            else
            {
                changeExpandLogo(MenuLibMusiqueOpen, false);
                MenuLibraryRow1.Height = new System.Windows.GridLength(20.0);
            }
        }

        void ExpandVideo(object sender, EventArgs e)
        {
            if (MenuLibraryRow2.ActualHeight < 21)
            {
                changeExpandLogo(MenuLibVideoOpen, true);
                MenuLibraryRow2.Height = new System.Windows.GridLength(60.0);
            }
            else
            {
                changeExpandLogo(MenuLibVideoOpen, false);
                MenuLibraryRow2.Height = new System.Windows.GridLength(20.0);
            }
        }

        void ExpandImage(object sender, EventArgs e)
        {
            if (MenuLibraryRow3.ActualHeight < 21)
            {
                changeExpandLogo(MenuLibImageOpen, true);
                MenuLibraryRow3.Height = new System.Windows.GridLength(60.0);
            }
            else
            {
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
    }
}
