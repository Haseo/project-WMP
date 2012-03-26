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
       
        private void liste_key_down(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
                this.Play();
            if (e.Key == Key.Delete)
                this.Remove(this._listbox.SelectedIndex);
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

        private void Click_Remove(object sender, RoutedEventArgs e)
        {
            if (this.Items.Count > 0 && this._listbox.SelectedIndex < this.Items.Count)
            {
                this.Remove(this._listbox.SelectedIndex);
            }
        }

        private void Add_to_list(object sender, BrowserArg e)
        {
            this.isResearch = false;
            foreach (string item in e.list)
            {
                this.Items.Add(item);
            }
            this.put_list();
        }

        private void liste_lecture_List_DoubleClick(object sender, EventArgs e)
        {
            if (this._listbox.SelectedItem != null)
            {
                int id = this._listbox.SelectedIndex;
                this._main.DebugList.Add("Test = " + this._listbox.SelectedIndex.ToString() + "\n");
                if (id > 0 && this.Items.Count > id)
                {
                    this._current = id;
                    this.Run();
                }
            }
        }
    }
}
