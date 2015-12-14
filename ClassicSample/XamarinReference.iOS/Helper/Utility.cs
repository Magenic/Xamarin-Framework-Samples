using System;
using System.Collections.Generic;
using System.Text;

using Foundation;
using UIKit;

using System.Threading.Tasks;
using Cirrious.CrossCore;
using XamarinReference.Lib.Interface;

namespace XamarinReference.iOS.Helper
{
    public static class Utility
    {
        public static void SetNavigationBarStyle(UINavigationBar bar)
        {
            
        }

        public static UIBarButtonItem GetNavigationBarButtonItem(string title, bool isEnabled)
        {
            var button = new UIBarButtonItem(title, UIBarButtonItemStyle.Bordered, null)
            {
                Enabled = isEnabled,
                TintColor = Helper.Theme.Color.C2
            };

            return button;
        }

        public static Task<bool> ShowAlert(string title, string message, string buttonName)
        {
            var lookupService = Mvx.Resolve<IStringLookupService>();

            var tcs = new TaskCompletionSource<bool>();
            UIApplication.SharedApplication.InvokeOnMainThread(new Action(() =>
            {
                var alert = new UIAlertView(title, message, null, lookupService.GetLocalizedString("Cancel"), buttonName);
                alert.Clicked += (s, e) =>
                {
                    tcs.SetResult(e.ButtonIndex != alert.CancelButtonIndex);
                };

            }));

            return tcs.Task;
        }
    }
}
