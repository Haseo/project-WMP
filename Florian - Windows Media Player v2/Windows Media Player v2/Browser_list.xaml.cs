using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel; 

namespace Windows_Media_Player_v2
{
    /// <summary>
    /// Interaction logic for Browser.xaml
    /// </summary>
    /// 

    public partial class Browser : Window
    {
        String[] Img_type = new String[] 
        { ".bmp", ".efig", ".fits", ".gif",
          ".ief", ".jfif", ".jif", ".pcx",
          ".png", ".psid", ".ric", ".spf",
          ".sxd", ".tif", ".tiff", ".wmf",
          ".xbm", ".xpm", ".zei", ".jpg"};
        String[] Audio_type = new String[] 
        { ".aac", ".ac3", ".au", ".au3",
          ".avi", ".ac3", ".cda", ".m3u",
          ".m4a", ".m4r", ".maud", ".mp2",
          ".mp3", ".ogg", ".psid", ".raw",
          ".rso", ".sb", ".sf", ".smp",
          ".snd", ".voc", ".wav"};
        String[] Video_type = new String[] 
        { ".flv", ".mov", ".movie", ".mp4",
          ".qt", ".rv", ".vob", ".wmv"};
        String[] Streaming_type = new String[] 
        { ".asf", ".ra", ".rm", ".smil",
          ".ram", ".RMVB", ".rv"};

        private List<string> Make_sub_selected_list(string name)
        {
            List<string> to_send = new List<string>();
            String[] array;

            array = System.IO.Directory.GetDirectories(name);
            foreach (string item in array)
            {
               foreach (string item2 in Make_sub_selected_list(item))
               {
                   to_send.Add(item2);
                }
            }
            String[] files = System.IO.Directory.GetFiles(name);
            foreach (string item in files)
            {
                if (this.test_extension(item) == true)
                    to_send.Add(item);
            }
            return (to_send);
        }

        private List<string> Make_selected_list()
        {
            List<string>    to_send = new List<string>();
            foreach (string stand_item in Browser_List.SelectedItems)
            {
                string item = epur_name(stand_item);

                if (item.Length > 0 && item.ElementAt<char>(item.Length - 1) == '\n')
                    item = item.Substring(0, item.Length - 1);
                if (this.IsDirectory(this.currentPath + "\\" + item) == true)
                {
                    foreach (string item2 in Make_sub_selected_list(this.currentPath + "\\" + item))
                    {
                        to_send.Add(item2);
                    }
                }
                else
                    to_send.Add(this.currentPath + "\\" + item);
            }
            return (to_send);
        }

        private bool test_extension(string name)
        {
            if (this.image_filter == true)
                foreach (string item in Img_type)
                {
                    if (name.Length > item.Length && string.Compare(item, 0, name, (name.Length - item.Length), item.Length) == 0)
                        return (true);
                }
            if (this.audio_filter == true)
                foreach (string item in Audio_type)
                {
                    if (name.Length > item.Length && string.Compare(item, 0, name, (name.Length - item.Length), item.Length) == 0)
                        return (true);
                }
            if (this.video_filter == true)
                foreach (string item in Video_type)
                {
                    if (name.Length > item.Length && string.Compare(item, 0, name, (name.Length - item.Length), item.Length) == 0)
                        return (true);
                }
            return (false);
        }

        private string epur_name(string name)
        {
            if (name.Length > 9 && string.Compare(name, 0, "<Dossier>", 0, 9) == 0)
                return (name.Substring(9, (name.Length - 9)));
            if (name.Length == 16 && string.Compare(name, 0, "<Dossier Parent>", 0, 16) == 0)
                return ("..");
            return (name);
        }

        private void Make_list()
        {
            String[] array;

            Browser_Path.Text = this.currentPath;
            array = System.IO.Directory.GetDirectories(this.currentPath);
            this.ListBrowser.Clear();
            this.ListBrowser.Add("<Dossier Parent>");
            foreach (string item in array)
            {
                String[] stand = item.Split('\\');

                if (this.filter.Length == 0 || 
                    (stand.Last<string>().Length >= this.filter.Length && string.Compare(this.filter, 0, stand.Last<string>(), 0 , this.filter.Length) == 0))
                    this.ListBrowser.Add("<Dossier>" + stand.Last<string>());
            }
            String[] files = System.IO.Directory.GetFiles(this.currentPath);
            foreach (string item in files)
            {
                String[] stand = item.Split('\\');

                if (this.test_extension(stand.Last<string>()) == true && (this.filter.Length == 0 ||
                    (stand.Last<string>().Length >= this.filter.Length && string.Compare(this.filter, 0, stand.Last<string>(), 0, this.filter.Length) == 0)))
                this.ListBrowser.Add(stand.Last<string>());
            }
        }
    }
}

// Definition :
/*

 * Image = 

.bmp       == 
.efig      == 
.fits      == 
.gif       == 
.ief       == 
.jfif      == 
.jif       == 
.pcx       == 
.png       == 
.psid      == 
.ric       == 
.spf       == 
.sxd       == 
.tif       == 
.tiff      == 
.wmf       == 
.xbm       == 
.xpm       == 
.zei       == 

 * Audio = 

.aac       == 
.ac3       == 
.au        == 
.au3       == 
.avi       == 
.ac3       == 
.cda       == 
.m3u       == 
.m4a       == 
.m4r       == 
.maud      == 
.mp2       == 
.mp3       == 
.ogg       == 
.psid      == 
.raw       == 
.rso       == 
.sb        == 
.sf        == 
.smp       == 
.snd       == 
.voc       == 
.wav       == 

 * Video =
 
.flv       == 
.mov       == 
.movie     == 
.mp4       == 
.qt        == 
.rv        == 
.vob       == 
.wmv       == 

 * Streaming = 

.asf       == 
.ra        == 
.rm        == 
.smil      == 
.ram       == 
.RMVB      == 
.rv"       == 
*/