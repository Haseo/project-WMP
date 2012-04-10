using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMPv2.Locator
{
    public class WMPLocator
    {
        private static ListPlaylistsModel _mainListPlaylists;
        private static MediaPlaylistModel _mainPlaylist;
        private static ColorStyleModel _mainStyle;

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public WMPLocator()
        {
            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view models
            ////}
            ////else
            ////{
            ////    // Create run time view models
            ////}

            CreateMainListPlaylists();
            CreateMainPlaylist();
            CreateMainStyle();
        }

        public static void ClearMain()
        {
            _mainListPlaylists.Cleanup();
            _mainPlaylist.Cleanup();
            _mainStyle.Cleanup();
            _mainListPlaylists = null;
            _mainPlaylist = null;
            _mainStyle = null;
        }

        #region ListPlaylists
        public static ListPlaylistsModel MainStaticListPlaylists
        {
            get
            {
                if (_mainListPlaylists == null)
                {
                    CreateMainListPlaylists();
                }

                return _mainListPlaylists;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ListPlaylistsModel MainListPlaylists
        {
            get
            {
                return MainStaticListPlaylists;
            }
        }

        public static void CreateMainListPlaylists()
        {
            if (_mainListPlaylists == null)
            {
                _mainListPlaylists = new ListPlaylistsModel();
            }
        }
        #endregion

        #region Playlist
        public static MediaPlaylistModel MainStaticPlaylist
        {
            get
            {
                if (_mainPlaylist == null)
                {
                    CreateMainPlaylist();
                }

                return _mainPlaylist;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MediaPlaylistModel MainPlaylist
        {
            get
            {
                return MainStaticPlaylist;
            }
        }

        public static void CreateMainPlaylist()
        {
            if (_mainPlaylist == null)
            {
                _mainPlaylist = new MediaPlaylistModel();
            }
        } 
        #endregion

        #region Style
        public static ColorStyleModel MainStaticStyle
        {
            get
            {
                if (_mainStyle == null)
                {
                    CreateMainStyle();
                }

                return _mainStyle;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ColorStyleModel MainStyle
        {
            get
            {
                return MainStaticStyle;
            }
        }

        public static void CreateMainStyle()
        {
            if (_mainStyle == null)
            {
                _mainStyle = new ColorStyleModel();
            }
        } 
        #endregion

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            ClearMain();
        }
 
    }
}
