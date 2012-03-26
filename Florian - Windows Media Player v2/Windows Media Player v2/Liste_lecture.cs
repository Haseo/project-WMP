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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Windows_Media_Player_v2
{
    public partial class Liste_lecture
    {
        Browser research;
        bool isResearch;

        ListBox _listbox;
        TextBox _name_list;
        Button _create_playlist;
        Button _button_add;
        Button _button_remove;
        List<string> Items;
        int _current;
        bool _repeat;
        bool _shuffle;

        private Random random;

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
        
        public ObservableCollection<String> ItemList { get; set; } /* Debug */
        MainWindow _main;

        public Liste_lecture(ListBox listbox, TextBox name_list, Button create_playlist, Button button_add, Button button_remove, MainWindow main, bool repeat = false, bool shuffle = false)
        {
            this.isResearch = false;
            this.Items = new List<string>();
            this._listbox = listbox;
            this._name_list = name_list;
            this._create_playlist = create_playlist;
            this._button_add = button_add;
            this._button_remove = button_remove;
            this._main = main;
            this._current = 0;
            this._repeat = repeat;
            this._shuffle = shuffle;

            this.ItemList = new ObservableCollection<String>();
            this._listbox.ItemsSource = this.ItemList;
            this._button_add.Click += new RoutedEventHandler(Click_Add);
            this._button_remove.Click += new RoutedEventHandler(Click_Remove);
            this._create_playlist.Click += new RoutedEventHandler(Click_Create);
            this._listbox.MouseDoubleClick += new MouseButtonEventHandler(liste_lecture_List_DoubleClick);
            this._listbox.SelectionMode = SelectionMode.Single;
            this.random = new Random();
            this._main.KeyDown += new KeyEventHandler(liste_key_down);
            this._listbox.SelectedIndex = 0;
        }

        private void Click_Create(object sender, RoutedEventArgs e)
        {
            if (this._name_list.Text.Length > 0)
            {
                this._main.Add_Playlist(this._name_list.Text, this.Items);
            }
        }

        private int getObjectId(Object target)
        {
            int id = 0;
            
            foreach (Object item in ItemList)
            {
                if (target.Equals(item) == true)
                    return (id);
                id++;
            }
            return (-1);
        }

        private void put_list()
        {
            this.ItemList.Clear();
            foreach (string item in this.Items)
            {
                String[] stand = item.Split('\\');

                this.ItemList.Add(stand.Last<string>());
            }
        }

        private void Remove(int id)
        {
            if (this.Items.Count > 0 && id < this.Items.Count && id < this.ItemList.Count)
            {
                this.Items.RemoveAt(id);
                this.ItemList.RemoveAt(id);
                if (this._current == id)
                {
                    if (this._current >= this.Items.Count)
                        this._current -= 1;
                    if (this._current < 0)
                        this._current = 0;
                    this.Run();
                }
            }
        }

        private void Run()
        {
            if (this.Items.Count > this._current)
            {
                string name = this.Items.ElementAt(this._current);
                if (this.IsVideoORAudio(name) == true)
                {
                    this._main.Run_Media(name);
                }
                else if (this.IsImage(name) == true)
                {
                    this._main.Run_Image(name);
                }
                // else if (this.IsStreaming(name) == true)
                //     this._main.Run_Streaming(name);
            }
        }

        public void setRepeat(bool repeat)
        {
            this._repeat = repeat;
        }

        public void setShuffle(bool shuffle)
        {
            this._shuffle = shuffle;
        }

        private int getRandomId()
        {
            if (this.Items.Count > 0)
             return (this.random.Next(this.Items.Count));
            return (0);
        }

        public void Play()
        {
            this._current = this._listbox.SelectedIndex;
            if (this.Items.Count > 0 && this.Items.Count > this._current)
                this.Run();
        }

        public void Next()
        {
            if (this.Items.Count <= this._current)
                this._current = 0;
            if (this.Items.Count > 0)
            {
                if (this._shuffle == true)
                {
                    this._current = getRandomId();
                    this.Run();
                }
                else if (this._current == (this.Items.Count - 1) && this._repeat == true)
                {
                    this._current = 0;
                    this.Run();
                }
                else if (this._current < (this.Items.Count - 1))
                {
                    this._current += 1;
                    this.Run();
                }
                this._listbox.SelectedIndex = this._current;
            }
        }

        public void Prev()
        {
            if (this.Items.Count <= this._current)
                this._current = 0;
            if (this.Items.Count > 0)
            {
                if (this._shuffle == true)
                {
                    this._current = getRandomId();
                    this.Run();
                }
                else if (this._current == 0 && this._repeat == true)
                {
                    this._current = this.Items.Count - 1;
                    this.Run();
                }
                else if (this._current > 0)
                {
                    this._current -= 1;
                    this.Run();
                }
                this._listbox.SelectedIndex = this._current;
            }
        }

        public void Visible()
        {
            this._listbox.Visibility = Visibility.Visible;
            this._button_add.Visibility = Visibility.Visible;
            this._button_remove.Visibility = Visibility.Visible;
        }

        public void InVisible()
        {
            this._listbox.Visibility = Visibility.Hidden;
            this._button_add.Visibility = Visibility.Hidden;
            this._button_remove.Visibility = Visibility.Hidden;
        }
    }
}
