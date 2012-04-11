using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows_Media_Player_v2
{
    public partial class Playlists
    {
        public void Add_Playlist(Playlist newlist)
        {
            this._list.Add(newlist);
            this.put_List();
        }

        public void Add_Playlist(string name, List<string> list)
        {
            Playlist newPlaylist = new Playlist(name, list, this._add_To_Playlist, this._remove_To_Playlist, this._clear_To_Playlist, this._delete_To_Playlist,
                this._name_To_Playlist, this._change_Name_To_Playlist, this._list_Playlist);

            newPlaylist.Save();
            this.Add_Playlist(newPlaylist);
        }

        public void Add_Playlist(string name)
        {
            Playlist newPlaylist = new Playlist(name, this._add_To_Playlist, this._remove_To_Playlist, this._clear_To_Playlist, this._delete_To_Playlist,
                this._name_To_Playlist, this._change_Name_To_Playlist, this._list_Playlist);

            newPlaylist.Save();
            this.Add_Playlist(newPlaylist);
        }

        public void addToPlaylist(int id, string name)
        {
            if (id >= 0 && id < this._list.Count)
            {
                this._list.ElementAt(id).addToList(name);
            }
        }

        public void addToPlaylist(int id, List<string> list)
        {
            if (id >= 0 && id < this._list.Count)
            {
                this._list.ElementAt(id).addToList(list);
            }
        }

        public void SetListToPlaylist(int id, List<string> list)
        {
            if (id >= 0 && id < this._list.Count)
            {
                this._list.ElementAt(id).setList(list);
            }
        }

        public void SetNameToPlaylist(int id, string name)
        {
            if (id >= 0 && id < this._list.Count)
            {
                this._list.ElementAt(id).setName(name);
            }
        }

        public void RemoveToPlaylist(int id, int target)
        {
            if (id >= 0 && id < this._list.Count)
            {
                this._list.ElementAt(id).removeToList(target);
                this.put_List();
            }
        }
        

        public void Load_Playlist(string name)
        {
            Playlist newPlaylist = new Playlist("", name, this._add_To_Playlist, this._remove_To_Playlist, this._clear_To_Playlist, this._delete_To_Playlist,
                this._name_To_Playlist, this._change_Name_To_Playlist, this._list_Playlist);

            if (newPlaylist.Load() == true)
                this.Add_Playlist(newPlaylist);
        }

        public void Remove_Playlist(int id)
        {
            if (id >= 0 && id < this._list.Count)
            {
                this._list.ElementAt(id).Delete();
                this._list.RemoveAt(id);
                this.put_List();
            }
        }
    }
}
