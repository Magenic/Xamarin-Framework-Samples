using MvvmCross.Platform;

using System.Collections.Generic;
using System.Linq;

using UIKit;

using XamarinReference.iOS.Controller;
using XamarinReference.Lib.Interface;
using XamarinReference.Lib.Model;

namespace XamarinReference.iOS.Services
{
    public class NavigationMenuService : INavigationMenuService<UIViewController>
    {
        private readonly IStringLookupService _localizedStrings = Mvx.Resolve<IStringLookupService>();

        public IList<NavigationMenuItem<UIViewController>> MenuItems { get; set; }

        public NavigationMenuService()
        {
            this.MenuItems = new List<NavigationMenuItem<UIViewController>>
            {
                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new BusinessCardController(),
                    Title = _localizedStrings.GetLocalizedString("Business Card")
                },
                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new TabController(),
                    Title = _localizedStrings.GetLocalizedString("Tab Navigation")
                },
                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new StickyHeaderController(),
                    Title = _localizedStrings.GetLocalizedString("Sticky Header")
                },
                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new CameraController(),
                    Title = _localizedStrings.GetLocalizedString("Camera")
                },
                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new GeolocationController(),
                    Title = _localizedStrings.GetLocalizedString("Geolocation")
                },
                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new NetworkConnectivityController(),
                    Title = _localizedStrings.GetLocalizedString("Network Connectivity")
                },
                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new PdfStitchingController(),
                    Title = _localizedStrings.GetLocalizedString("PDF Stitching")
                },
                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new PingController(),
                    Title = _localizedStrings.GetLocalizedString("Ping")
                },

                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new AboutController(), 
                    Title = _localizedStrings.GetLocalizedString("About") 
                },
                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new ThemeColorController(), 
                    Title = _localizedStrings.GetLocalizedString("Theme Colors") 
                },
                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new ThemeFontController(), 
                    Title = _localizedStrings.GetLocalizedString("Theme Fonts") 
                },
                new NavigationMenuItem<UIViewController>
                {
                    IsEnabled =  true,
                    Manager = new FontController(Mvx.Resolve<IFontInfoService>()),
                    Title = _localizedStrings.GetLocalizedString("Fonts Loaded") 
                },

            };    
        }
        public IList<NavigationMenuItem<UIViewController>> GetMenuItemsEnabled()
        {
            return MenuItems.Where(x => x.IsEnabled).ToList();
        }

    }
}
