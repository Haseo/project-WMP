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
        public static ColorStyleModel _mainStyle;
        public static List<MediaContent> _currentlist_media;
        public static List<string> _currentlist;
        public static String _currentName;
        public static String _currentImg;
        public static int _currentMedia;

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
            _currentlist_media.Clear();
            _currentName = "";
            _mainStyle.Cleanup();
            _mainStyle = null;
        }

        #region act current playlist

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
                if (!Directory.Exists("./Playlist/"))
                    Directory.CreateDirectory("./Playlist/");
                using (FileStream fs = new FileStream("./Playlist/" + name + ".xml", FileMode.OpenOrCreate, FileAccess.ReadWrite))
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

        public static void add_play_playlist(String name)
        {
            try
            {
                if (!Directory.Exists("./Playlist/"))
                    Directory.CreateDirectory("./Playlist/");
                using (FileStream fs = new FileStream("./Playlist/" + name + ".xml", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    try
                    {
                        List<MediaContent> new_list = new List<MediaContent>();

                        XmlSerializer xml = new XmlSerializer(new_list.GetType());

                        new_list = xml.Deserialize(fs) as List<MediaContent>;
                        foreach (MediaContent item in new_list)
                        {
                            String[] stand = item._Titre.Split('\\');

                            _currentlist_media.Add(item);
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

        #endregion

        #region Style
        public static ColorStyleModel MainStaticStyle
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
        public ColorStyleModel MainStyle
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
                _mainStyle = new ColorStyleModel();
            }
        } 
        #endregion

        public static void Cleanup()
        {
            ClearMain();
        }
 
    }
}
