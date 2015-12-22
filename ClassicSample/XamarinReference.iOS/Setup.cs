using System;
using System.Collections.Generic;
using System.Text;

using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;

using UIKit;

using XamarinReference.Lib.Interface;
using XamarinReference.iOS.Services;
using XamarinReference.Lib.Services;
using XamarinReference.iOS.Helper;
using XamarinReference.iOS.Network;

namespace XamarinReference.iOS
{
    public static class Setup
    {
        public static void Initialize()
        {
            MvxSimpleIoCContainer.Initialize();

            Mvx.LazyConstructAndRegisterSingleton<INavigationMenuService<UIViewController>, NavigationMenuService>();
            Mvx.LazyConstructAndRegisterSingleton<IStringLookupService, StringLookupService>();
            Mvx.LazyConstructAndRegisterSingleton<IVersionInfo, VersionInfoService>();
            Mvx.LazyConstructAndRegisterSingleton<IFontInfoService, FontInfoService >();
            Mvx.LazyConstructAndRegisterSingleton<IJobsService, JobsService>();
            Mvx.LazyConstructAndRegisterSingleton<IFileHelper, FileHelper>();
            Mvx.LazyConstructAndRegisterSingleton<IMediaService, MediaService>();
            Mvx.LazyConstructAndRegisterSingleton<ICreateHttpClientHelper, NSUrlConnectionHandlerCreator>();
            Mvx.LazyConstructAndRegisterSingleton<IITunesDataService, ITunesDataService>();
        }
    }
}
