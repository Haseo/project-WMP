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
    public class ListPlaylistsModel : ViewModelBase
    {
        public ListPlaylists _List {get; set;}
        public MediaPlaylist _Current { get; set; }
        public List<string> _Names { get; set; }

        public ListPlaylistsModel()
        {
            _List = new ListPlaylists();
            _Names = new List<string>();
            /*XMLOpen();
            if (_Names.Count == 0)
                OpenPlaylistfromXML("Unnamed Playlist 0");
            else
                OpenPlaylistfromXML(_Names[0]);*/
        }
        /*
        public void XMLSave()
        {
            using (FileStream fs = new FileStream("../../Playlist/ListPlaylist.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<string>));

                xml.Serialize(fs, _Names);
            }
            
        }

        public void XMLRefresh()
        {
            using (FileStream fs = new FileStream("../../Playlist/ListPlaylist.xml", FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<string>));

                _Names = xml.Deserialize(fs) as List<string>;
            }
        }

        public void XMLOpen()
        {
            using (FileStream fs = new FileStream("../../Playlist/ListPlaylist.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<string>));

                _Names = xml.Deserialize(fs) as List<string>;
            }
        }

        public void OpenPlaylistfromXML(string playlistname)
        {
            int count;

            if (playlistname.Length > 0)
            {
                count = playlistname.IndexOf("\\Playlist\\");
                if (count == -1)
                    playlistname = "../../Playlist/" + playlistname;
                count = playlistname.IndexOf(".xml");
                if (count == -1)
                    playlistname = playlistname + ".xml";
                using (FileStream fs = new FileStream(playlistname, FileMode.Open))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(MediaPlaylist));

                    _Current = xml.Deserialize(fs) as MediaPlaylist;
                }
            }
        }

        public void XMLSavePlaylist()
        {
            int i = 0;
            string curr = "";

            if (_Current._Name_s != "")
            {
                using (FileStream fs = new FileStream("../../Playlist/" + _Current._Name_s + ".xml", FileMode.OpenOrCreate))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(MediaPlaylist));

                    xml.Serialize(fs, _Current);
                }
                while (i < _Names.Count)
                    curr = _Names[i++];
                if (curr == "")
                {
                    _Names.Add(_Current._Name_s);
                    XMLSave();
                }
            }
        }

        public void XMLOpenPlaylist()
        {
            using (FileStream fs = new FileStream("../../Playlist/" + _Current._Name_s + ".xml", FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(MediaPlaylist));

                _Current = xml.Deserialize(fs) as MediaPlaylist;
            }
        }

        public void XMLRefreshPlaylist()
        {
            using (FileStream fs = new FileStream("../../Playlist/" + _Current._Name_s + ".xml", FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(MediaPlaylist));

                _Current = xml.Deserialize(fs) as MediaPlaylist;
            }
        }
         * */
    }
}
