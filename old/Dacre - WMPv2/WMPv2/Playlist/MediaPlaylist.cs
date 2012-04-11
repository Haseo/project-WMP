using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using System.IO;
using System.Xml.Serialization;

namespace WMPv2
{
    [Serializable]
    public class MediaPlaylist
    {
        public string _Image_s { get; set; }
        public string _Name_s { get; set; }
        public List<string> _Playlist { get; set; }
        [XmlIgnore]
        static int nb = 0;
        [XmlIgnore]
        string currentnb;

        public MediaPlaylist()
        {
            currentnb = nb.ToString();
            _Image_s = @"Images\AlbumImage.png";
            _Name_s = "Unnamed Playlist " + currentnb;
            _Playlist = new List<string>();
            ++nb;
        }

        public MediaPlaylist(string albumImage, string playlistName, List<string> playlistList = null)
        {
            _Image_s = albumImage;
            _Name_s = playlistName;

            if (playlistList == null)
                _Playlist = new List<string>();
            else
                _Playlist = playlistList;
        }

        public void addElemtoPlaylist(string path)
        {
            _Playlist.Add(path);
        }

    }
}
