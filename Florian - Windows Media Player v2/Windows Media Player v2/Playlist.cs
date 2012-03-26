using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
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
    public partial class Playlist
    {
        string _name;
        string _file;
        List<string> _list;
        Browser research;
        bool isResearch;

        Button _add_To_Playlist;
        Button _remove_To_Playlist;
        Button _clear_To_Playlist;
        Button _delete_To_Playlist;
        TextBox _name_To_Playlist;
        Button _change_Name_To_Playlist;
        ListBox _list_Playlist;

        private void Assign_Controls(Button add_To_Playlist, Button remove_To_Playlist, Button clear_To_Playlist,
            Button delete_To_Playlist, TextBox name_To_Playlist, Button change_Name_To_Playlist, ListBox list_Playlist)
        {
            this._add_To_Playlist = add_To_Playlist;
            this._remove_To_Playlist = remove_To_Playlist;
            this._clear_To_Playlist = clear_To_Playlist;
            this._delete_To_Playlist = delete_To_Playlist;
            this._name_To_Playlist = name_To_Playlist;
            this._change_Name_To_Playlist = change_Name_To_Playlist;
            this._list_Playlist = list_Playlist;
        }

        public Playlist(string name, List<string> list, Button add_To_Playlist, Button remove_To_Playlist, Button clear_To_Playlist,
            Button delete_To_Playlist, TextBox name_To_Playlist, Button change_Name_To_Playlist, ListBox list_Playlist)
        {
            this._name = name;
            this._file = this.Determine_File(name);
            this._list = list;
            this.Assign_Controls(add_To_Playlist, remove_To_Playlist, clear_To_Playlist, delete_To_Playlist, name_To_Playlist, change_Name_To_Playlist, list_Playlist);
        }

        public Playlist(string name, Button add_To_Playlist, Button remove_To_Playlist, Button clear_To_Playlist,
            Button delete_To_Playlist, TextBox name_To_Playlist, Button change_Name_To_Playlist, ListBox list_Playlist)
        {
            this._name = name;
            this._file = this.Determine_File(name);
            this._list = new List<string>();
            this.Assign_Controls(add_To_Playlist, remove_To_Playlist, clear_To_Playlist, delete_To_Playlist, name_To_Playlist, change_Name_To_Playlist, list_Playlist);
        }

        public Playlist(string name, string file, Button add_To_Playlist, Button remove_To_Playlist, Button clear_To_Playlist,
            Button delete_To_Playlist, TextBox name_To_Playlist, Button change_Name_To_Playlist, ListBox list_Playlist)
        {
            if (name.Length == 0)
                this._name = this.Determine_Name(file);
            else
                this._name = name;
            if (file.Length == 0)
                this._file = this.Determine_File(name);
            else
                this._file = file;
            this._list = new List<string>();
            this.Assign_Controls(add_To_Playlist, remove_To_Playlist, clear_To_Playlist, delete_To_Playlist, name_To_Playlist, change_Name_To_Playlist, list_Playlist);
        }

        public Playlist(string name, string file, List<string> list, Button add_To_Playlist, Button remove_To_Playlist, Button clear_To_Playlist,
            Button delete_To_Playlist, TextBox name_To_Playlist, Button change_Name_To_Playlist, ListBox list_Playlist)
        {
            if (name.Length == 0)
                this._name = this.Determine_Name(file);
            else
                this._name = name;
            if (file.Length == 0)
                this._file = this.Determine_File(name);
            else
                this._file = file;
            this._list = list;
            this.Assign_Controls(add_To_Playlist, remove_To_Playlist, clear_To_Playlist, delete_To_Playlist, name_To_Playlist, change_Name_To_Playlist, list_Playlist);
        }

        public bool TestPlaylist()
        {
            if (this._name.Length == 0 || this._file.Length == 0)
                return (false);
            return (true);
        }

        public void Delete()
        {
            // TO_DO : destruction du fichier de la playlist
            System.IO.File.Delete(this._file);
        }

        public void Save()
        {
            // TO_DO : Création/Modification du fichier de la playlist
            XmlTextWriter xml = new XmlTextWriter(this._file, System.Text.Encoding.UTF8);
            xml.WriteStartDocument();
            xml.WriteStartElement("Playlist");
            xml.WriteAttributeString("Name", this._name);
            foreach (string item in this._list)
            {
                xml.WriteAttributeString("item", item);
            }
            xml.WriteEndElement();
            xml.WriteEndDocument();
            xml.Flush();
            xml.Close();
        }

        public bool Load()
        {
            // TO_DO : load du fichier XML
            return (true);
        }

        public void View()
        {
            this._add_To_Playlist.Click += new RoutedEventHandler(Click_Add);
            this._remove_To_Playlist.Click += new RoutedEventHandler(Click_Remove);
            this._clear_To_Playlist.Click += new RoutedEventHandler(Click_Clear);
            this._delete_To_Playlist.Click += new RoutedEventHandler(Click_Delete);
            this._name_To_Playlist.Text = this._name;
            this._change_Name_To_Playlist.Click += new RoutedEventHandler(Click_Change_Name);
            this._list_Playlist.SelectionMode = SelectionMode.Multiple;
            this._list_Playlist.ItemsSource = this._list;
        }

        public void StopView()
        {

        }

        private void Click_Add(object sender, RoutedEventArgs e)
        {
            if (this.isResearch == false)
            {
                research = new Browser();
                research.Activate();
                research.End_Browser += new EventHandler<BrowserArg>(Add_to_list);
                this.isResearch = true;
            }
        }

        private void Add_to_list(object sender, BrowserArg e)
        {
            this.isResearch = false;
            foreach (string item in e.list)
            {
                this._list.Add(item);
            }
        }

        private void Click_Remove(object sender, RoutedEventArgs e)
        {
            if (this._list.Count > 0 && this._list_Playlist.SelectedIndex < this._list.Count)
            {
                this._list.RemoveAt(this._list_Playlist.SelectedIndex);
            }
        }

        private void Click_Clear(object sender, RoutedEventArgs e)
        {
           this._list.Clear();
        }

        private void Click_Delete(object sender, RoutedEventArgs e)
        {
// To Delete
        }

        private void Click_Change_Name(object sender, RoutedEventArgs e)
        {
            if (this._name_To_Playlist.Text.Length > 0)
            {
                this._name = this._name_To_Playlist.Text;
            }
        }

    }
}
