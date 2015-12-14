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

namespace XamarinReference.iOS
{
    public static class Setup
    {
        public static void Initialize()
        {
            MvxSimpleIoCContainer.Initialize();

            Mvx.RegisterType<INavigationMenuService<UIViewController>, NavigationMenuService>();
            Mvx.RegisterType<IStringLookupService, StringLookupService>();
            Mvx.RegisterType<IVersionInfo, VersionInfoService>();
            Mvx.RegisterType<IFontInfoService, FontInfoService >();
            Mvx.RegisterType<IJobsService, JobsService>();
            Mvx.RegisterType<IFileHelper, FileHelper>();
            Mvx.RegisterType<IMediaService, MediaService>();
        }
    }
}
