using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMPv2.Locator
{
    public class CurrentPlaylistLocator
    {
        private static MediaPlaylist _main;
        private static ColorStyle _mainStyle;

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public CurrentPlaylistLocator()
        {
            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view models
            ////}
            ////else
            ////{
            ////    // Create run time view models
            ////}

            CreateMain();
            CreateMainStyle();
        }

        public static void ClearMain()
        {
            _main.Cleanup();
            _mainStyle.Cleanup();
            _main = null;
            _mainStyle = null;
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        public static MediaPlaylist MainStatic
        {
            get
            {
                if (_main == null)
                {
                    CreateMain();
                }

                return _main;
            }
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MediaPlaylist Main
        {
            get
            {
                return MainStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the Main property.
        /// </summary>
        /// <summary>
        /// Provides a deterministic way to create the Main property.
        /// </summary>
        public static void CreateMain()
        {
            if (_main == null)
            {
                _main = new MediaPlaylist();
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        public static ColorStyle MainStaticStyle
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

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ColorStyle MainStyle
        {
            get
            {
                return MainStaticStyle;
            }
        }

        /// <summary>
        /// Provides a deterministic way to create the Main property.
        /// </summary>
        public static void CreateMainStyle()
        {
            if (_mainStyle == null)
            {
                _mainStyle = new ColorStyle();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            ClearMain();
        }
 
    }
}
