using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Windows.Input;

namespace WMPv2
{
    public partial class MainWindow : Window
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
