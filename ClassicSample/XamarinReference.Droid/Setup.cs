using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using XamarinReference.Lib.Interface;
using XamarinReference.Droid.Services;

namespace XamarinReference.Droid
{
    public static class Setup
    {
        public static void Initialize()
        {
            MvxSimpleIoCContainer.Initialize();

            Mvx.LazyConstructAndRegisterSingleton<INavigationMenuService<Activity>, NavigationMenuService>();
            Mvx.LazyConstructAndRegisterSingleton<IStringLookupService, new StringLookup(this.ApplicationContext)>();
        }  
    }
}
