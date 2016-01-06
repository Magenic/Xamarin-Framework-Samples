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

namespace XamarinReference.Droid
{
    [Application]
    public class XamarinReferenceApplication : Application
    {
        public XamarinReferenceApplication(IntPtr handle, JniHandleOwnership transfer):base(handle, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            SetupIoC(); 
        }

        private void SetupIoC()
        {
            Setup.Initialize();
        }
    }
}