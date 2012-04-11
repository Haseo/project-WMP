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
using System.IO;

namespace Windows_Media_Player_v2
{
    /// <summary>
    /// Interaction logic for Browser.xaml
    /// </summary>
    public class BrowserArg : EventArgs
    {
        public BrowserArg(List<string> new_list)
        {
            this.list = new_list;
        }

        public List<string> list { get; private set; }
    }

    public partial class Browser : Window
    {
        public ObservableCollection<String> ListBrowser { get; set; }

        string       currentPath;
        string       filter;
        List<string> selected_item;
        bool         Valid_end;
        bool         audio_filter;
        bool         video_filter;
        bool         image_filter;
        
        public event EventHandler<BrowserArg> End_Browser;

        public Browser()
        {
            InitializeComponent();

            Browser_Debug.Text = "Lancement de la recherche.\n";

            this.Valid_end = false;
            this.audio_filter = false;
            this.video_filter = false;
            this.image_filter = false;
            this.filter = "";
            this.ListBrowser = new ObservableCollection<String>();
            Browser_List.ItemsSource = this.ListBrowser;
            this.currentPath = System.IO.Directory.GetCurrentDirectory();
            this.selected_item = new List<string>();
            this.Browser_checkbox_audio.IsChecked = true;
            this.Browser_checkbox_video.IsChecked = true;
            this.Browser_checkbox_image.IsChecked = true;
            this.Make_list();
            this.Show();
            this.Closing += Window_Closing;
            this.Browser_List.SelectionMode = SelectionMode.Extended;
        }

        private bool IsDirectory(string name)
        {
            return (System.IO.Directory.Exists(name) == true);
        }

        private bool CanAccessDirectory(string name)
        {
            if (IsDirectory(name) == false)
                return (false);

            //System.Security.AccessControl.DirectorySecurity security = new DirectoryInfo(name).GetAccessControl();

            
            return (false);
        }

        private bool Change_Current_dir(string stand_name)
        {
            bool    flag = false;
            string name = this.epur_name(stand_name);

            if (name == "..")
            {
                if (this.IsDirectory(System.IO.Directory.GetParent(this.currentPath).FullName) == true)
                {
                    this.currentPath = System.IO.Directory.GetParent(this.currentPath).FullName;
                    flag = true;
                }
            }
            else
            {
                if (this.IsDirectory(this.currentPath + "\\" + name) == true)
                {
                    this.currentPath += "\\" + name;
                    flag = true;
                }
            }
            if (flag == true)
            {
                this.filter = "";
                Browser_Research.Text = "";
                if (selected_item.Count > 0)
                    selected_item.Clear();
                this.Make_list();
            }
            return (flag);
        }
    }
}
