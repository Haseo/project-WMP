using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.ComponentModel;

namespace WMPv2
{
    public enum eType
    {
        Musique,
        Video,
        Image,
        Playlist,
        Inconnu
    };

    public class MediaContent : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string _image;
        int _numero;
        string _titre;
        string _duree;
        string _artiste;
        string _album;
        string _genre;
        eType _type;

        #region GettersSetters
        public string _Image
        {
            get { return _image; }
            set{ _image = value; NotifyPropertyChanged("_Image"); }
        }

        public int _Numero
        {
            get { return _numero; }
            set { _numero = value; NotifyPropertyChanged("_Numero"); }
        }

        public string _Titre
        {
            get { return _titre; }
            set { _titre = value; NotifyPropertyChanged("_Titre"); }
        }

        public string _Duree
        {
            get { return _duree; }
            set { _duree = value; NotifyPropertyChanged("_Duree"); }
        }

        public string _Artiste
        {
            get { return _artiste; }
            set { _artiste = value; NotifyPropertyChanged("_Artiste"); }
        }

        public string _Album
        {
            get { return _album; }
            set { _album = value; NotifyPropertyChanged("_Album"); }
        }

        public string _Genre
        {
            get { return _genre; }
            set { _genre = value; NotifyPropertyChanged("_Genre"); }
        }

        public eType _Type
        {
            get { return _type; }
            set { _type = value; NotifyPropertyChanged("_Type"); }
        }
        #endregion

        public MediaContent() {}

        public MediaContent(string nom)
        {
            _image = null;
            _numero = -1;
            _titre = nom;
            _duree = null;
            _artiste = null;
            _album = null;
            _genre = null;
            _type = eType.Inconnu;
        }

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
