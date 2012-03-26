using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;
using System.Xml.Serialization;

namespace WMPv2
{
    public partial class MainWindow : Window
    {

        public void savePlaylist()
        {
            using (FileStream fs = new FileStream(_CurrentPlaylist._Name_s + ".xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xml = new XmlSerializer(typeof(MediaPlaylist));

                xml.Serialize(fs, _CurrentPlaylist);
            }
        }

        public void refreshPlaylist()
        {
            using (FileStream fs = new FileStream(_CurrentPlaylist._Name_s + ".xml", FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(MediaPlaylist));

                _CurrentPlaylist = xml.Deserialize(fs) as MediaPlaylist;
            }
        }

    }
}
