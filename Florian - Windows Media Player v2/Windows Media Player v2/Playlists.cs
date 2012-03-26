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
    public partial class Playlists
    {
        List<Playlist> _list;
        ListBox _listbox;
        TextBox _name_playlist;
        Button _create_playlist;
        Button _delete_playlist;
        Button _view_playlist;
        MainWindow _main;

        // Pour Playlist
        Button  _add_To_Playlist;
        Button  _remove_To_Playlist;
        Button  _clear_To_Playlist;
        Button  _delete_To_Playlist;
        TextBox _name_To_Playlist;
        Button  _change_Name_To_Playlist;
        ListBox _list_Playlist;

        int _current_view;

        public ObservableCollection<String> ItemList { get; set; }

        public Playlists(ListBox listbox, TextBox name_playlist, Button create_playlist, Button delete_playlist, Button view_playlist, MainWindow main
            , Button add_To_Playlist, Button remove_To_Playlist, Button clear_To_Playlist, Button delete_To_Playlist, TextBox name_To_Playlist, Button change_Name_To_Playlist,
            ListBox list_Playlist)
        {
            this._listbox = listbox;
            this._name_playlist = name_playlist;
            this._create_playlist = create_playlist;
            this._delete_playlist = delete_playlist;
            this._view_playlist = view_playlist;

            this._add_To_Playlist = add_To_Playlist;
            this._remove_To_Playlist = remove_To_Playlist;
            this._clear_To_Playlist = clear_To_Playlist;
            this._delete_To_Playlist = delete_To_Playlist;
            this._name_To_Playlist = name_To_Playlist;
            this._change_Name_To_Playlist = change_Name_To_Playlist;
            this._list_Playlist = list_Playlist;

            this._main = main;
            this.ItemList = new ObservableCollection<String>();
            this._listbox.ItemsSource = this.ItemList;
            this._list = new List<Playlist>();
            this._current_view = -1;

            this._create_playlist.Click += new RoutedEventHandler(Click_Create);
            this._delete_playlist.Click += new RoutedEventHandler(Click_Delete);
            this._view_playlist.Click += new RoutedEventHandler(Click_View);
            this._listbox.MouseDoubleClick += new MouseButtonEventHandler(Playlists_DoubleClick);
        }

        private void Playlists_DoubleClick(object sender, EventArgs e)
        {
            this.Click_View(sender, null);
        }

        private void Click_Create(object sender, RoutedEventArgs e)
        {
            if (this._name_playlist.Text.Length > 0)
            {
                this.Add_Playlist(this._name_playlist.Text);
            }
        }

        private void Click_Delete(object sender, RoutedEventArgs e)
        {
            if (this._listbox.SelectedIndex >= 0 && this._listbox.SelectedIndex < this._list.Count)
            {
                this.Remove_Playlist(this._listbox.SelectedIndex);
            }
        }

        private void Click_View(object sender, RoutedEventArgs e)
        {
            if (this._listbox.SelectedIndex >= 0 && this._listbox.SelectedIndex < this._list.Count)
            {
                if (this._current_view != -1)
                {
                    this._list.ElementAt(this._listbox.SelectedIndex).StopView();
                }
                this._current_view = this._listbox.SelectedIndex;
                this._list.ElementAt(this._listbox.SelectedIndex).View();
            }
        }

        private void put_List()
        {
            this.ItemList.Clear();
            foreach (Playlist item in this._list)
            {
                this.ItemList.Add(item.getName());
            }
        }

        public void List_Playlist()
        {
            // TO_DO : Lister les différentes playlist
        }

        public void Run_Playlist(int id)
        {
            // TO_DO : Setter la Playlist en fonction de la playlist
            id = 0;
        }
    }
}
