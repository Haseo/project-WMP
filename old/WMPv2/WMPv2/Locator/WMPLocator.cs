using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace WMPv2.Locator
{
    public class WMPLocator
    {
        public static ColorStyle _mainStyle;
        public static List<MediaContent> _currentlist_media;
        public static List<string> _currentlist;
        public static String _currentName;
        public static String _currentImg;

        public WMPLocator()
        {
            WMPv2.MainWindow._playlists = new LibraryViewModel();
            WMPv2.MainWindow._playlists.load_all_playlist();
            WMPv2.MainWindow._music = new LibraryViewModel();
            WMPv2.MainWindow._music.load_music();
            WMPv2.MainWindow._video = new LibraryViewModel();
            WMPv2.MainWindow._video.load_video();
            WMPv2.MainWindow._image = new LibraryViewModel();
            WMPv2.MainWindow._image.load_image();

            _currentlist_media = new List<MediaContent>();
            _currentlist = new List<string>();
            _currentName = "Unnamed";
            _currentImg = @"Images\AlbumImage.png";
            CreateMainStyle();
        }

        public static void ClearMain()
        {
            _currentlist.Clear();
            _mainStyle.Cleanup();
            _mainStyle = null;
        }

        public static void Add(String test)
        {
            String[] stand = test.Split('\\');

            _currentlist.Add(stand.Last<string>());
            _currentlist_media.Add(new MediaContent(test));
        }

        public static bool Exist(int index)
        {
            if (index >= 0 && index < _currentlist.Count && index < _currentlist_media.Count)
                return (true);
            return (false);
        }

        public static String At(int index)
        {
            if (Exist(index) == true)
            {
                return _currentlist_media.ElementAt(index)._Titre;
            }
            return "";
        }

        public static void Remove(int index)
        {
            if (Exist(index) == true)
            {
                _currentlist.RemoveAt(index);
                _currentlist_media.RemoveAt(index);
            }
        }

        public static void SaveCurrent()
        {
            MainWindow._playlists.create_Playlist(_currentName, _currentlist_media);
        }

        public static void play_playlist(String name)
        {
            _currentName = name;
            try
            {
                using (FileStream fs = new FileStream("../../Playlist/" + name + ".xml", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    try
                    {
                        XmlSerializer xml = new XmlSerializer(_currentlist_media.GetType());

                        _currentlist_media = xml.Deserialize(fs) as List<MediaContent>;
                        _currentlist.Clear();
                        foreach (MediaContent item in _currentlist_media)
                        {
                            String[] stand = item._Titre.Split('\\');

                            _currentlist.Add(stand.Last<string>());
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        #region ListPlaylists
     /*   public static ListPlaylistsModel MainStaticListPlaylists
        {
            get
            {
                if (_mainListPlaylists == null)
                {
                    CreateMainListPlaylists();
                }

                return _mainListPlaylists;
            }
        }
        */
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
     /*   public ListPlaylistsModel MainListPlaylists
        {
            get
            {
                return MainStaticListPlaylists;
            }
        }

        public static void CreateMainListPlaylists()
        {
            if (_mainListPlaylists == null)
            {
                _mainListPlaylists = new ListPlaylistsModel();
            }
        }*/
        #endregion

        #region Playlist
     /*   public static MediaPlaylistModel MainStaticPlaylist
        {
            get
            {
                if (_mainPlaylist == null)
                {
                    CreateMainPlaylist();
                }

                return _mainPlaylist;
            }
        }
     */
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
      /*  public MediaPlaylistModel MainPlaylist
        {
            get
            {
                return MainStaticPlaylist;
            }
        }

        public static void CreateMainPlaylist()
        {
            if (_mainPlaylist == null)
            {
                _mainPlaylist = new MediaPlaylistModel();
            }
        } 
       * */
        #endregion

        #region Style
        public static ColorStyle MainStaticStyle
        {
            get
            {
                if (_mainStyle == null)
                {
                    CreateMainStyle();
                }

                return _mainStyle;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ColorStyle MainStyle
        {
            get
            {
                return MainStaticStyle;
            }
        }

        public static void CreateMainStyle()
        {
            if (_mainStyle == null)
            {
                _mainStyle = new ColorStyle();
            }
        } 
        #endregion

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            ClearMain();
        }
 
    }
}
