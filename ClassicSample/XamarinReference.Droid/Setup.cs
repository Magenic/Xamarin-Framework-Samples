using Android.App;

using MvvmCross.Platform.IoC;
using MvvmCross.Platform;
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
            Mvx.RegisterSingleton(typeof(IStringLookupService), new StringLookupService(Android.App.Application.Context));
        }  
    }
}
