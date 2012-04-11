using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows_Media_Player_v2
{
    public partial class Playlist
    {
        private string Determine_File(string name)
        {
            return (name + ".xml");
        }

        private string Determine_Name(string name)
        {
            if (name.Length > 4 && string.Compare(".xml", 0, name, (name.Length - 4), 4) == 0)
                return (name.Substring(0, (name.Length - 4)));
            return ("");
        }

        public String getName()
        {
            return (this._name);
        }

        public void setName(string name)
        {
            this._name = name;
        }

        public void setList(List<string> newlist)
        {
            this._list = newlist;
        }

        public List<string> getList()
        {
            return (this._list);
        }

        public void addToList(string name)
        {
            this._list.Add(name);
        }

        public void addToList(List<string> addList)
        {
            foreach (string item in addList)
            {
                this._list.Add(item);
            }
        }

        public void removeToList(int id)
        {
            if (id >= 0 && id < this._list.Count)
            {
                this._list.RemoveAt(id);
            }
        }

        public void clearList()
        {
            this._list.Clear();
        }
    }
}
