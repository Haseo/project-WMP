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
    public enum Type_librarydisp
    {
        all_playlist,
        playlist,
        all_music,
        all_video,
        all_image
    };

    public partial class MainWindow : Window
    {

        private bool isPlaylistExpand = false;
        private bool isMusiqueExpand = false;
        private bool isVideoExpand = false;
        private bool isImageExpand = false;
        private Type_librarydisp type_disp = Type_librarydisp.all_playlist;

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

        #region disp

        void dispAllPlaylist()
        {
           // if (type_disp != Type_librarydisp.all_playlist)
            {
                type_disp = Type_librarydisp.all_playlist;
                ContentLibraryGrid.ColumnFromDisplayIndex(1).IsReadOnly = true;
                ContentLibraryGrid.ColumnFromDisplayIndex(2).IsReadOnly = true;
                ContentLibraryGrid.ColumnFromDisplayIndex(4).IsReadOnly = true;
                ContentLibraryGrid.ColumnFromDisplayIndex(5).IsReadOnly = true;
                ContentLibraryGrid.ColumnFromDisplayIndex(6).IsReadOnly = true;
                LibraryGrid.BeginInit();
                LibraryGrid.DataContext = _playlists;
                LibraryGrid.EndInit();
            }
        }

        void dispPlaylist()
        {
            type_disp = Type_librarydisp.playlist;
            ContentLibraryGrid.ColumnFromDisplayIndex(1).IsReadOnly = false;
            ContentLibraryGrid.ColumnFromDisplayIndex(2).IsReadOnly = false;
            ContentLibraryGrid.ColumnFromDisplayIndex(4).IsReadOnly = false;
            ContentLibraryGrid.ColumnFromDisplayIndex(5).IsReadOnly = false;
            ContentLibraryGrid.ColumnFromDisplayIndex(6).IsReadOnly = false;
        }

        void dispMusic()
        {
            if (type_disp != Type_librarydisp.all_music)
            {
                type_disp = Type_librarydisp.all_music;
                LibraryGrid.BeginInit();
                LibraryGrid.DataContext = _music;
                LibraryGrid.EndInit();
                ContentLibraryGrid.ColumnFromDisplayIndex(1).IsReadOnly = false;
                ContentLibraryGrid.ColumnFromDisplayIndex(2).IsReadOnly = false;
                ContentLibraryGrid.ColumnFromDisplayIndex(4).IsReadOnly = false;
                ContentLibraryGrid.ColumnFromDisplayIndex(5).IsReadOnly = false;
                ContentLibraryGrid.ColumnFromDisplayIndex(6).IsReadOnly = false;
            }
        }

        void dispVideo()
        {
            if (type_disp != Type_librarydisp.all_video)
            {
                type_disp = Type_librarydisp.all_video;
                LibraryGrid.BeginInit();
                LibraryGrid.DataContext = _video;
                LibraryGrid.EndInit();
                ContentLibraryGrid.ColumnFromDisplayIndex(1).IsReadOnly = false;
                ContentLibraryGrid.ColumnFromDisplayIndex(2).IsReadOnly = false;
                ContentLibraryGrid.ColumnFromDisplayIndex(4).IsReadOnly = false;
                ContentLibraryGrid.ColumnFromDisplayIndex(5).IsReadOnly = false;
                ContentLibraryGrid.ColumnFromDisplayIndex(6).IsReadOnly = false;
            }
        }

        void dispImage()
        {
            if (type_disp != Type_librarydisp.all_image)
            {
                type_disp = Type_librarydisp.all_image;
                LibraryGrid.BeginInit();
                LibraryGrid.DataContext = _image;
                LibraryGrid.EndInit();
                ContentLibraryGrid.ColumnFromDisplayIndex(1).IsReadOnly = false;
                ContentLibraryGrid.ColumnFromDisplayIndex(2).IsReadOnly = false;
                ContentLibraryGrid.ColumnFromDisplayIndex(4).IsReadOnly = false;
                ContentLibraryGrid.ColumnFromDisplayIndex(5).IsReadOnly = false;
                ContentLibraryGrid.ColumnFromDisplayIndex(6).IsReadOnly = false;
            }
        }


        #endregion

        #region Expand
        void ExpandPlaylist(object sender, EventArgs e)
        {
            if (!isPlaylistExpand)
            {
                double size;

                size = 8 + ((_playlists._PlaylistList.Count + 2) * 16);
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
          //  dispAllPlaylist();
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
            dispMusic();
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
            dispVideo();
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
            dispImage();
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
            _playlists.play_playlist(PlaylistBox.SelectedIndex);
            UpdatePannelPlaylist();
        }

        private void DoubleClickLibMusique(Object sender, MouseEventArgs e)
        {

        }

        private void DoubleClickLibVideo(Object sender, MouseEventArgs e)
        {

        }

        private void DoubleClickLibImage(Object sender, MouseEventArgs e)
        {

        }

        #endregion

        #region RightClick
        private void RightClickLibPlaylist(Object sender, MouseEventArgs e)
        {
            PlaylistBox.BeginInit();
            LibraryGrid.BeginInit();
            if (_playlists.delete_playlist(PlaylistBox.SelectedIndex) == true)
            {
                PlaylistBox.UnselectAll();
                type_disp = Type_librarydisp.all_playlist;
                PlaylistBox.ItemsSource = _playlists._PlaylistList;
                LibraryGrid.DataContext = _playlists;
            }
            LibraryGrid.EndInit();
            PlaylistBox.EndInit();
        }

        private void RightClickLibMusique(Object sender, MouseEventArgs e)
        {
        }

        private void RightClickLibVideo(Object sender, MouseEventArgs e)
        {
        }

        private void RightClickLibImage(Object sender, MouseEventArgs e)
        {
        }

        #endregion

        #region LeftClick

        private void ClickLibPlaylist(Object sender, MouseEventArgs e)
        {
            if (_playlists.select_playlist(PlaylistBox.SelectedIndex) == true)
            {
                type_disp = Type_librarydisp.playlist;
                PlaylistBox.BeginInit();
                PlaylistBox.ItemsSource = _playlists._PlaylistList;
                PlaylistBox.EndInit();
                LibraryGrid.BeginInit();
                LibraryGrid.DataContext = _playlists;
                LibraryGrid.EndInit();
            }
        }

        private void ClickLibMusique(Object sender, MouseEventArgs e)
        {
            if (_music.activate_audio_filter(PlaylistBox.SelectedIndex) == true)
            {
                type_disp = Type_librarydisp.all_music;
                MusiqueBox.BeginInit();
                MusiqueBox.ItemsSource = _music._PlaylistList;
                MusiqueBox.EndInit();
                LibraryGrid.BeginInit();
                LibraryGrid.DataContext = _music;
                LibraryGrid.EndInit();
            }
        }

        private void ClickLibVideo(Object sender, MouseEventArgs e)
        {
            if (_video.activate_audio_filter(PlaylistBox.SelectedIndex) == true)
            {
                type_disp = Type_librarydisp.all_video;
                VideoBox.BeginInit();
                VideoBox.ItemsSource = _video._PlaylistList;
                VideoBox.EndInit();
                LibraryGrid.BeginInit();
                LibraryGrid.DataContext = _video;
                LibraryGrid.EndInit();
            }
        }

        private void ClickLibImage(Object sender, MouseEventArgs e)
        {
            if (_image.activate_image_filter(PlaylistBox.SelectedIndex) == true)
            {
                type_disp = Type_librarydisp.all_video;
                ImageBox.BeginInit();
                ImageBox.ItemsSource = _image._PlaylistList;
                ImageBox.EndInit();
                LibraryGrid.BeginInit();
                LibraryGrid.DataContext = _image;
                LibraryGrid.EndInit();
            }
        }

        private void Click_library_add(Object sender, EventArgs e)
        {
        }

        private void Click_library_remove(Object sender, EventArgs e)
        {
        }

        #endregion


        #region playlists
        private void create_playlist(String name)
        {
            if (_playlists.can_create_Playlist(name) == true)
            {
                _playlists.create_Playlist(name, new List<MediaContent>());
                PlaylistBox.BeginInit();
                PlaylistBox.ItemsSource = _playlists._PlaylistList;
                PlaylistBox.EndInit();

                if (type_disp == Type_librarydisp.all_playlist)
                {
                    LibraryGrid.BeginInit();
                    LibraryGrid.DataContext = _playlists;
                    LibraryGrid.EndInit();
                }
                _playlists.save_all_playlist();
            }
        }

        private void delete_playlist(String name)
        {
            if (_playlists.can_delete_Playlist(PlaylistBox.SelectedIndex) == true)
            {
                _playlists.delete_Playlist(PlaylistBox.SelectedIndex);
                PlaylistBox.BeginInit();
                PlaylistBox.ItemsSource = _playlists._PlaylistList;
                PlaylistBox.EndInit();

                if (type_disp == Type_librarydisp.all_playlist)
                {
                    LibraryGrid.BeginInit();
                    LibraryGrid.DataContext = _playlists;
                    LibraryGrid.EndInit();
                }
                _playlists.save_all_playlist();
            }
        }

        #endregion

        #region datagrid

        private void Library_CellEdit(object sender, EventArgs e)
        {
            switch (type_disp)
            {
                case Type_librarydisp.all_playlist :
                    break;
                case Type_librarydisp.playlist :
                    _playlists.save_playlist();
                    break;
                case Type_librarydisp.all_music :
                    _music.save_music();
                    break;
                case Type_librarydisp.all_video :
                    _video.save_video();
                    break;
                case Type_librarydisp.all_image :
                    _image.save_image();
                    break;
            }
        }

        #endregion

        void AddLibPlaylist(object sender, EventArgs e)
        {
            string name = "New...";

            create_playlist(name);
            if (isPlaylistExpand && true == false)
            {
                ExpandPlaylist(new object(), new EventArgs());
                PlaylistBox.ItemsSource = null;
                PlaylistBox.ItemsSource = Locator.WMPLocator._currentlist;
                ExpandPlaylist(new object(), new EventArgs());
            }
        }
    }
}
