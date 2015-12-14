using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UIKit;

using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;

using XamarinReference.iOS.Controller;
using XamarinReference.Lib.Interface;
using XamarinReference.Lib.Model;

namespace XamarinReference.iOS.Services
{
    public class NavigationMenuService : INavigationMenuService<UIViewController>
    {
        private readonly IStringLookupService _LocalizedStrings = Mvx.Resolve<IStringLookupService>();

        public IList<NavigationMenuItem<UIViewController>> MenuItems { get; set; }

        public NavigationMenuService()
        {
            this.MenuItems = new List<NavigationMenuItem<UIViewController>>
            {
                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new BusinessCardController(),
                    Title = _LocalizedStrings.GetLocalizedString("Business Card")
                },
                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new TasksController(),
                    Title = _LocalizedStrings.GetLocalizedString("Tasks")
                },
                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new StickyHeaderController(),
                    Title = _LocalizedStrings.GetLocalizedString("Sticky Header")
                },
                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new CameraController(),
                    Title = _LocalizedStrings.GetLocalizedString("Camera")
                },
                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new GeolocationController(),
                    Title = _LocalizedStrings.GetLocalizedString("Geolocation")
                },
                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new NetworkConnectivityController(),
                    Title = _LocalizedStrings.GetLocalizedString("Network Connectivity")
                },
                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new PdfStitchingController(),
                    Title = _LocalizedStrings.GetLocalizedString("PDF Stitching")
                },
                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new PingController(),
                    Title = _LocalizedStrings.GetLocalizedString("Ping")
                },

                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new AboutController(), 
                    Title = _LocalizedStrings.GetLocalizedString("About") 
                },
                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new ThemeColorController(), 
                    Title = _LocalizedStrings.GetLocalizedString("Theme Colors") 
                },
                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new ThemeFontController(), 
                    Title = _LocalizedStrings.GetLocalizedString("Theme Fonts") 
                },
                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new FontController(),
                    Title = _LocalizedStrings.GetLocalizedString("Fonts Loaded") 
                },

            };    
        }
        public IList<NavigationMenuItem<UIViewController>> GetMenuItemsEnabled()
        {
            return MenuItems.Where(x => x.IsEnabled).ToList();
        }

    }
}
