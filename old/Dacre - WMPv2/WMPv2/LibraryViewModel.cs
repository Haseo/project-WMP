using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Data;

namespace WMPv2
{
    class LibraryViewModel
    {
        public ICollectionView _LibraryList { get; private set;}

        public LibraryViewModel()
        {
            List<MediaContent> librarylist = new List<MediaContent>();

            librarylist.Add(new MediaContent("Papillon"));
            librarylist.Add(new MediaContent("Patate"));
            librarylist.Add(new MediaContent("Pomme de pin"));

            _LibraryList = CollectionViewSource.GetDefaultView(librarylist);
        }

    }
}
