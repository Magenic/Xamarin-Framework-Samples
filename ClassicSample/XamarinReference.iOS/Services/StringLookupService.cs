using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using XamarinReference.Lib.Interface;

namespace XamarinReference.iOS.Services
{
    public class StringLookupService : IStringLookupService
    {
        public StringLookupService() { }

        public string GetLocalizedString(string value)
        {
            return NSBundle.MainBundle.LocalizedString(value, "optional");
        }
    }
}
