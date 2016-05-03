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

using Newtonsoft.Json;

using XamarinReference.Lib.Interface;

namespace XamarinReference.Droid.Services
{
    public class StringLookupService : IStringLookupService
    {
        private Context _applicationContext; 
        public Context ApplicationContext 
        {
            get { return _applicationContext;}
            set { _applicationContext = value; }
        }
        public StringLookupService() { }

        public string GetLocalizedString(string value)
        {
            if (_applicationContext != null)
            {
                var packageName = _applicationContext.PackageName;
                int resourceId = _applicationContext.Resources.GetIdentifier(value, "string", packageName);
                return _applicationContext.GetString(resourceId);
            }
            return string.Empty;
        }
    }
}
