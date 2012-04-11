using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Data;
using System.IO;
using System.Xml.Serialization;

namespace WMPv2
{
    public class LibraryViewModel
    {
        enum Audio_filter
        {
            None,
            Artist,
            Album,
            Genre
        };

        enum Video_filter
        {
            None,
            Genre
        };

        enum Image_filter
        {
            None,
            Artist,
            Genre
        };

        public ICollectionView _LibraryList { get; private set; }
        public List<String> _PlaylistList;
        public List<MediaContent> librarylist;
        bool global;
        Image_filter _img;
        Video_filter _vid;
        Audio_filter _aud;
        String _currentName;

        #region action Playlist
        private void add_Playlist(MediaContent content)
        {
            _PlaylistList.Add(content._Titre);
            if (global == true)
            {
                librarylist.Add(content);
                _LibraryList = CollectionViewSource.GetDefaultView(librarylist);
                _LibraryList.Refresh();
            }
        }

        public void delete_Playlist(int index)
        {
            if (index >= 0 && index < _PlaylistList.Count)
                _PlaylistList.RemoveAt(index);
            if (global == true && index >= 0 && index < librarylist.Count)
            {
                librarylist.RemoveAt(index);
                _LibraryList = CollectionViewSource.GetDefaultView(librarylist);
                _LibraryList.Refresh();
            }
        }

        public bool can_delete_Playlist(int index)
        {
            if (index >= 0 && index < _PlaylistList.Count)
            {
                if ((index < librarylist.Count && global == true) || global == false)
                    return (true);
            }
            return (false);
        }

        public void create_Playlist(String name, List<MediaContent> list)
        {
            MediaContent new_playlist = new MediaContent(name);

            save_playlist(name, list);
            foreach (String item in _PlaylistList)
            {
                if (item == name)
                    return;
            }
            add_Playlist(new_playlist);
            save_all_playlist();
        }

        public bool can_create_Playlist(String name)
        {
            if (_PlaylistList.IndexOf(name) >= 0)
                return (false);
            else if (global == true)
            {
                foreach (MediaContent content in librarylist)
                {
                    if (content._Titre.CompareTo(name) == 0)
                        return (false);
                }
            }
            return (true);
        }
        #endregion

        #region action libraryList
        private void add_libraryList(MediaContent content)
        {
            librarylist.Add(content);
            _LibraryList = CollectionViewSource.GetDefaultView(librarylist);
            _LibraryList.Refresh();
        }

        public void delete_libraryList(int index)
        {
            if (index >= 0 && index < librarylist.Count)
            {
                librarylist.RemoveAt(index);
                _LibraryList = CollectionViewSource.GetDefaultView(librarylist);
                _LibraryList.Refresh();
            }
        }

        public void clear_libraryList()
        {
            librarylist.Clear();
            _LibraryList = CollectionViewSource.GetDefaultView(librarylist);
            _LibraryList.Refresh();
        }

        public bool can_delete_libraryList(int index)
        {
            if (index >= 0 && index < librarylist.Count)
                return (true);
            return (false);
        }

        public void create_libraryList(String name)
        {
            add_libraryList(new MediaContent(name));
        }

        public bool can_create_libraryList(String name)
        {
            foreach (MediaContent content in librarylist)
            {
                if (content._Titre.CompareTo(name) == 0)
                    return (false);
            }
            return (true);
        }
        #endregion

        #region global_flag
        public void activate_global()
        {
            global = true;
        }

        public void desactivate_global()
        {
            global = false;
        }

        public bool is_global()
        {
            return global;
        }

        #endregion

        #region xml

        #region load

        private void load_librarylist(String file, bool flag)
        {
            bool error = false;

            if (flag == true)
            {
                clear_libraryList();
                try
                {
                    using (FileStream fs = new FileStream("../../Playlist/" + file + ".xml", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        try
                        {
                            XmlSerializer xml = new XmlSerializer(librarylist.GetType());

                            librarylist = xml.Deserialize(fs) as List<MediaContent>;
                            _LibraryList = CollectionViewSource.GetDefaultView(librarylist);
                            _LibraryList.Refresh();
                        }
                        catch (Exception)
                        {
                            error = true;
                        }
                    }
                }
                catch (Exception)
                {
                }
                if (error == true)
                    save_librarylist(file, false);
            }
            else
            {
                clear_libraryList();
                _PlaylistList.Clear();
                try
                {
                    using (FileStream fs = new FileStream("../../Playlist/" + file + ".xml", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        try
                        {
                            XmlSerializer xml = new XmlSerializer(typeof(List<MediaContent>));

                            librarylist = xml.Deserialize(fs) as List<MediaContent>;
                            foreach (MediaContent item in librarylist)
                            {
                                _PlaylistList.Add(item._Titre);
                            }
                            _LibraryList = CollectionViewSource.GetDefaultView(librarylist);
                            _LibraryList.Refresh();
                        }
                        catch (Exception)
                        {
                            error = true;
                        }
                    }
                }
                catch (Exception)
                {
                }
                if (error == true)
                    save_librarylist(file, false);
            }
        }

        private void load_playlistList(String file)
        {
            bool error = false;

            //if (global == true)
            clear_libraryList();
            _PlaylistList.Clear();
            try
            {
                using (FileStream fs = new FileStream("../../Playlist/" + file + ".xml", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    try
                    {
                        XmlSerializer xml = new XmlSerializer(typeof(List<string>));

                        _PlaylistList = xml.Deserialize(fs) as List<string>;
                        if (global == true)
                        {
                            foreach (string item in _PlaylistList)
                            {
                                add_libraryList(new MediaContent(item));
                            }
                        }
                    }
                    catch (Exception)
                    {
                        error = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            if (error == true)
                save_playlistList(file);
        }

        public void load_all_playlist()
        {
            load_playlistList("ListPlaylist");
        }

        public void load_playlist(string name)
        {
            load_librarylist(name, true);
            _currentName = name;
        }

        public void load_music()
        {
            load_librarylist("Music", false);
            _PlaylistList.Clear();
            _PlaylistList.Add("Artist");
            _PlaylistList.Add("Album");
            _PlaylistList.Add("Genre");
        }

        public void load_video()
        {
            load_librarylist("Video", false);
            _PlaylistList.Clear();
            _PlaylistList.Add("Genre");
        }

        public void load_image()
        {
            load_librarylist("Images", false);
            _PlaylistList.Clear();
        }

        #endregion

        #region save

        private void save_librarylist(String file, bool flag)
        {
            if (flag == true)
            {
                try
                {
                    using (FileStream fs = new FileStream("../../Playlist/" + file + ".xml", FileMode.Create, FileAccess.ReadWrite))
                    {
                        try
                        {
                            XmlSerializer xml = new XmlSerializer(typeof(List<string>));

                            xml.Serialize(fs, _PlaylistList);
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
            else
            {
                try
                {
                    using (FileStream fs = new FileStream("../../Playlist/" + file + ".xml", FileMode.Create, FileAccess.ReadWrite))
                    {
                        try
                        {
                            XmlSerializer xml = new XmlSerializer(librarylist.GetType());

                            xml.Serialize(fs, librarylist);
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
        }

        private void save_playlistList(String file)
        {
            try
            {
                using (FileStream fs = new FileStream("../../Playlist/" + file + ".xml", FileMode.Create, FileAccess.ReadWrite))
                {
                    try
                    {
                        XmlSerializer xml = new XmlSerializer(typeof(List<string>));

                        xml.Serialize(fs, _PlaylistList);
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

        private void save_playlist(String file, List<MediaContent> items)
        {
            try
            {
                using (FileStream fs = new FileStream("../../Playlist/" + file + ".xml", FileMode.Create, FileAccess.ReadWrite))
                {
                    try
                    {
                        XmlSerializer xml = new XmlSerializer(items.GetType());

                        xml.Serialize(fs, items);
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

        public void save_all_playlist()
        {
            save_playlistList("ListPlaylist");
        }

        public void save_playlist(string name)
        {
            save_librarylist(name, false);
        }

        public void save_playlist()
        {
            if (_currentName.Length > 0)
                save_librarylist(_currentName, false);
        }

        public void save_music()
        {
            save_librarylist("Music", false);
        }

        public void save_video()
        {
            save_librarylist("Video", false);
        }

        public void save_image()
        {
            save_librarylist("Images", false);
        }

        #endregion

        #region delete

        private void delete_librarylist(String file)
        {
            if (System.IO.File.Exists("../../Playlist/" + file + ".xml"))
            {
                try
                {
                    System.IO.File.Delete("../../Playlist/" + file + ".xml");
                }
                catch (System.IO.IOException)
                {
                }
            }
        }

        private void delete_playlistList(String file)
        {
            if (System.IO.File.Exists("../../Playlist/" + file + ".xml"))
            {
                try
                {
                    System.IO.File.Delete("../../Playlist/" + file + ".xml");
                }
                catch (System.IO.IOException)
                {
                }
            }
        }

        public void delete_all_playlist()
        {
            delete_librarylist("Playlists");
        }

        public void delete_playlist(string name)
        {
            delete_playlistList(name);
        }

        public void delete_music()
        {
            delete_librarylist("Music");
        }

        public void delete_video()
        {
            delete_librarylist("Video");
        }

        public void delete_image()
        {
            delete_librarylist("Images");
        }

        #endregion

        #endregion

        #region filter

        public bool activate_audio_filter(int index)
        {
            if (index >= 0 && index < _PlaylistList.Count && (index + 1) <= (int)Audio_filter.Genre)
            {
                _aud = (Audio_filter)(index + 1);
                return true;
            }
            return false;
        }

        public bool activate_video_filter(int index)
        {
            if (index >= 0 && index < _PlaylistList.Count && (index + 1) <= (int)Video_filter.Genre)
            {
                _vid = (Video_filter)(index + 1);
                return true;
            }
            return false;
        }

        public bool activate_image_filter(int index)
        {
            if (index >= 0 && index < _PlaylistList.Count && (index + 1) <= (int)Image_filter.Genre)
            {
                _img = (Image_filter)(index + 1);
                return true;
            }
            return false;
        }

        #endregion

        public void modify_content(int row, int column)
        {
            if (row >= 0 && row < librarylist.Count)
            {
                switch (column)
                {
                    case 0:
                        break;
                    case 1:
                  //      librarylist.ElementAt(row)._Numero = _LibraryList.   <List<MediaContent>>
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                }
            }
        }

        public bool validPlaylist(int index)
        {
            if (index >= 0 && index < _PlaylistList.Count && index < librarylist.Count)
                return true;
            return false;
        }

        public bool select_playlist(int index)
        {
            if (index >= 0 && index < _PlaylistList.Count)
            {
                global = false;
                load_playlist(_PlaylistList.ElementAt(index));
                return true;
            }
            return false;
        }

        public void play_playlist(int index)
        {
            if (index >= 0 && index < _PlaylistList.Count)
            {
                Locator.WMPLocator.play_playlist(_PlaylistList.ElementAt(index));
            }
        }

        public bool delete_playlist(int index)
        {
            if (index >= 0 && index < _PlaylistList.Count)
            {
                global = true;
                delete_playlist(_PlaylistList.ElementAt(index));
                _PlaylistList.RemoveAt(index);
                save_all_playlist();
                load_all_playlist();
                return true;
            }
            return false;
        }

        public void add_content(MediaContent item)
        {
            add_libraryList(item);
        }

        public void add_music(String name)
        {
            add_content(new MediaContent(name));
            save_music();
        }

        public void add_video(String name)
        {
            add_content(new MediaContent(name));
            save_video();
        }

        public void add_image(String name)
        {
            add_content(new MediaContent(name));
            save_image();
        }

        public LibraryViewModel()
        {
            global = true;
            _img = Image_filter.None;
            _vid = Video_filter.None;
            _aud = Audio_filter.None;
            librarylist = new List<MediaContent>();
            _PlaylistList = new List<String>();
            _LibraryList = CollectionViewSource.GetDefaultView(librarylist);
            _currentName = "";
        }

    }
}
