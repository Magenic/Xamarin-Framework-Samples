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

        public StringLookupService(Context applicationContext)
        {
            _applicationContext = applicationContext;     
        }

        public string GetLocalizedString(string value)
        {
            var packageName = _applicationContext.PackageName;
            int resourceId = _applicationContext.Resources.GetIdentifier(value, "string", packageName);
            return _applicationContext.GetString(resourceId);
        }
    }
}