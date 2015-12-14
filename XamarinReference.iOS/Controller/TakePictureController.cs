using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

using Foundation;

using Xamarin.Media;

namespace XamarinReference.iOS.Controller
{
    public class TakePictureController : BaseController 
    {
        public MediaFile Picture { get; set; }
        public TakePictureController() { }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (Picture != null)
                {
                    Picture.Dispose();
                    Picture = null;
                }
            }
        }
    }
}
