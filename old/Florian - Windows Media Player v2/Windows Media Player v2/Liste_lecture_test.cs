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
        private bool IsImage(string name)
        {
            foreach (string item in Img_type)
            {
                if (name.Length > item.Length && string.Compare(item, 0, name, (name.Length - item.Length), item.Length) == 0)
                    return (true);
            }
            return (false);
        }

        private bool IsStreaming(string name)
        {
            foreach (string item in Streaming_type)
            {
                if (name.Length > item.Length && string.Compare(item, 0, name, (name.Length - item.Length), item.Length) == 0)
                    return (true);
            }
            return (false);
        }

        private bool IsVideoORAudio(string name)
        {
            if (IsAudio(name) == true || IsVideo(name) == true)
                return (true);
            return (false);
        }

        private bool IsVideo(string name)
        {
            foreach (string item in Video_type)
            {
                if (name.Length > item.Length && string.Compare(item, 0, name, (name.Length - item.Length), item.Length) == 0)
                    return (true);
            }
            return (false);
        }

        private bool IsAudio(string name)
        {
            foreach (string item in Audio_type)
            {
                if (name.Length > item.Length && string.Compare(item, 0, name, (name.Length - item.Length), item.Length) == 0)
                    return (true);
            }
            return (false);
        }
    }
}
