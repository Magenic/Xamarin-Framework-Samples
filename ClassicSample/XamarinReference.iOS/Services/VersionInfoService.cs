using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Foundation;
using UIKit;
using XamarinReference.Lib.Interface;

namespace XamarinReference.iOS.Services
{
    public class VersionInfoService : IVersionInfo
    {
        private DateTime _ApplicationBuildTime;

        public DateTime ApplicationBuildTime
        {
            get { return _ApplicationBuildTime; }
        }

        private string _ApplicationVersion;

        public string ApplicationVersion
        {
            get { return _ApplicationVersion; }
        }

        private string _OperatingSystemVersion;

        public string OperatingSystemVersion
        {
            get { return _OperatingSystemVersion; }
        }

        public VersionInfoService()
        {
            try
            {
                Version version = Assembly.GetExecutingAssembly().GetName().Version;

                DateTime temp = new DateTime(2000, 1, 1);
                temp = temp.AddDays(version.Build);
                _ApplicationBuildTime = temp.AddSeconds(version.Revision * 2);

                _OperatingSystemVersion = UIDevice.CurrentDevice.SystemVersion;
                _ApplicationVersion = NSBundle.MainBundle.InfoDictionary["CFBundleVersion"].ToString();
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
