using System.Collections.Generic;
using System.Linq;

using Android.App;

using XamarinReference.Lib.Interface;
using XamarinReference.Lib.Model;
using XamarinReference.Droid.Activities;

using MvvmCross.Platform;

namespace XamarinReference.Droid.Services
{
    public class NavigationMenuService : INavigationMenuService<Activity>
    {
        private readonly IStringLookupService _localizedStrings = Mvx.Resolve<IStringLookupService>();

        public IList<NavigationMenuItem<Activity>> MenuItems { get; set; }

        public NavigationMenuService ()
        {
            this.MenuItems = new List<NavigationMenuItem<Activity>>
            {
                new NavigationMenuItem<Activity>
                {
                    IsEnabled =  true,
                    Manager = new AboutActivity(), 
                    Title = _localizedStrings.GetLocalizedString("About")
                },
            };
        }

        public IList<NavigationMenuItem<Activity>> GetMenuItemsEnabled()
        {
            return MenuItems.Where(x => x.IsEnabled).ToList();
        }
    }
}