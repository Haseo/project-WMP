using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMPv2
{
    class MediaPlayer
    {
        private string _source
        {
            get { return (_source); }
            set { _source = value; }
        }

        private List<string> _files
        {
            get { return (_files); }
            set { _files = value; }
        }

        private Uri _currentFile
        {
            get { return (_currentFile); }
            set { _currentFile = value; }
        }

        public MediaPlayer()
        {
            _currentFile = new Uri(@"C:\Users\Public\Videos\Sample Videos\Faune.wmv");
        }

        public void addFile(string file)
        {
            _files.Add(file);
        }
    }
}
