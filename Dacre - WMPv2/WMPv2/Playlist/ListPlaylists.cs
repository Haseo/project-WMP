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
    //[Serializable]
    public class ListPlaylists : ViewModelBase
    {
        public List<MediaPlaylist> _List { get; set; }
        public List<string> _Names { get; set; }
        public MediaPlaylist _Current { get; set; }

        public ListPlaylists()
        {
            _List = new List<MediaPlaylist>();
            _Current = new MediaPlaylist();
            openListPlaylist();
        }

        public void addElemtoList(MediaPlaylist elem)
        {
            _List.Add(elem);
            if (_List.Count == 1)
                _Current = elem;
        }

        public void changeCurrent(MediaPlaylist elem)
        {
            _Current = elem;
        }

        public void deleteElemtoList(MediaPlaylist elem)
        {
            _List.Remove(elem);
        }

        public void saveListPlaylist()
        {
            using (FileStream fs = new FileStream("ListPlaylist.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<string>));

                xml.Serialize(fs, _Names);
            }
        }

        public void openListPlaylist()
        {
            using (FileStream fs = new FileStream("ListPlaylist.xml", FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<string>));

                _Names = xml.Deserialize(fs) as List<string>;
            }
        }

        public void refreshListPlaylist()
        {
            using (FileStream fs = new FileStream("ListPlaylist.xml", FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<string>));

                _Names = xml.Deserialize(fs) as List<string>;
            }
        }



    }
}
