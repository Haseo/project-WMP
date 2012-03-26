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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>s
    ///

    public partial class MainWindow : Window
    {
        Browser research;
        bool isResearch;

        public ObservableCollection<String> DebugList { get; set; } /* Debug */

        Liste_lecture liste_lecture;
        Playlists _playlists;

        public MainWindow()
        {
            InitializeComponent();
            this.DebugList = new ObservableCollection<String>();
            Debug.ItemsSource = this.DebugList;
            this.DebugList.Add("Lancement du Programme.\n");
            this.isResearch = false;
            liste_lecture = new Liste_lecture(this.List_Lect, this.Name_Liste_Lecture, this.Create_Change_Liste_lecture, this.List_Lect_Add, this.List_Lect_Remove, this);
            _playlists = new Playlists(this.List_Playlists, this.Name_To_Create_playlist, this.Create_Playlist, this.Delete_Playlist, this.View_Playlist, this,
                   this.Add_To_Playlist, this.Remove_To_Playlist, this.Clear_To_Playlist, this.Delete_To_Playlist, this.Name_To_Playlist, this.Change_Name_To_Playlist, this.List_Playlist);
        }

        private void Run_Browser_Click(object sender, RoutedEventArgs e)
        {
            if (this.isResearch == false)
            {
                this.DebugList.Add("Lancement d'une recherche (programme sous-jacent).\n");
                research = new Browser();
                research.Activate();
                research.End_Browser += new EventHandler<BrowserArg>(End_Browsing);
                this.isResearch = true;
            }
                // research.Visibility = research.s;
        }

        private void End_Browsing(object sender, BrowserArg e)
        {
            this.isResearch = false;
            this.DebugList.Add("Resultat Browser :\n");
            this.DebugList.Add("\t-----\n");
            foreach (string item in e.list)
            {
                this.DebugList.Add(item + "\n");

            }
            this.DebugList.Add("\t-----\n");
            this.DebugList.Add("End Resultat Browser :\n");
        }

        public void Add_Playlist(string name, List<string> list)
        {
            this._playlists.Add_Playlist(name, list);
        }

        public void Run_Media(string name)
        {
            this.DebugList.Add("Run Media : " + name + "\n");
        }

        public void Run_Image(string name)
        {
            this.DebugList.Add("Run Image : " + name + "\n");
        }

        public void Run_Streaming(string name)
        {
            this.DebugList.Add("Run Streaming : " + name + "\n");
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            this.liste_lecture.Prev();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            this.liste_lecture.Next();
        }
        
        private void Run_Click(object sender, RoutedEventArgs e)
        {
            this.liste_lecture.Play();
        }

        private void Shuffle_checked(object sender, RoutedEventArgs e)
        {
            this.liste_lecture.setShuffle(true);
        }

        private void Shuffle_unchecked(object sender, RoutedEventArgs e)
        {
            this.liste_lecture.setShuffle(false);
        }

        private void Repeat_checked(object sender, RoutedEventArgs e)
        {
            this.liste_lecture.setRepeat(true);
        }

        private void Repeat_unchecked(object sender, RoutedEventArgs e)
        {
            this.liste_lecture.setRepeat(false);
        }

        private void Clear_debug_Click(object sender, RoutedEventArgs e)
        {
            this.DebugList.Clear();
        }
    }
}
