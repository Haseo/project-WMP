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
    public partial class Browser : Window
    {
        /* Gestion des touches Entree + Echap */
        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (selected_item.Count != 1 || this.Change_Current_dir(selected_item.First<string>()) == false)
                    this.Browser_Valid_Click(sender, null);
            }
            if (e.Key == Key.Escape)
                this.Button_Cancel_Click(sender, null);
        }

        /* Filtre de recherche pour la liste */
        private void Browser_Research_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.filter = Browser_Research.Text;
            this.Make_list();
        }

        /* Bouton de validation (changement de dossier si sélectionner, sinon transmission des valeurs (A faire). Changer le changement de dossier, en ajout des fichiers recursifs)*/
        private void Browser_Valid_Click(object sender, RoutedEventArgs e)
        {
            this.End_Browser(this, new BrowserArg(this.Make_selected_list()));
            this.Valid_end = true;
            this.Close();
        }

        /* Interception de la fermeture de la fenetre, pour lancer l'evenement */
        void Window_Closing(object sender, CancelEventArgs e)
        {
            if (this.Valid_end == false)
                this.End_Browser(this, new BrowserArg(new List<string>()));
        }

        /* Bouton Annulation */
        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        /* Double Click dans la liste */
        private void Browser_List_DoubleClick(object sender, EventArgs e)
        {
            if (Browser_List.SelectedItem != null)
            {
                if (this.Change_Current_dir(Browser_List.SelectedItem.ToString()) == false)
                {
                    this.Browser_Valid_Click(sender, null);
                }
            }
        }

        /* Changement du Path par l'utilisateur. Si cela correspond à un dossier, chargement du contenu dans la liste */
        private void Browser_Path_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.Browser_Path.Text.Length > 0 && System.IO.Directory.Exists(this.Browser_Path.Text))
            {
                this.currentPath = this.Browser_Path.Text;
                this.Make_list();
            }
        }


        private void Check_Box_Audio(object sender, EventArgs e)
        {
            this.audio_filter = true;
            this.Make_list();
        }

        private void UnCheck_Box_Audio(object sender, EventArgs e)
        {
            this.audio_filter = false;
            this.Make_list();
        }

        private void Check_Box_Video(object sender, EventArgs e)
        {
            this.video_filter = true;
            this.Make_list();
        }

        private void UnCheck_Box_Video(object sender, EventArgs e)
        {
            this.video_filter = false;
            this.Make_list();
        }

        private void Check_Box_Image(object sender, EventArgs e)
        {
            this.image_filter = true;
            this.Make_list();
        }

        private void UnCheck_Box_Image(object sender, EventArgs e)
        {
            this.image_filter = false;
            this.Make_list();
        }


     }
}
