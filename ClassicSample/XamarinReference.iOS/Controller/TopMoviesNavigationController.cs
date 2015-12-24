using System;
using System.Collections.Generic;
using System.Text;

using XamarinReference.Lib.Interface;
using XamarinReference.Lib.Model;

using UIKit;
using Foundation;
using Cirrious.CrossCore;
using CoreGraphics;

namespace XamarinReference.iOS.Controller
{
    public class TopMoviesNavigationController:UINavigationController
    {

        public TopMoviesNavigationController()
        {
            SetupRootController();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

        }
        private void SetupRootController()
        {
            this.PushViewController(new TopMoviesCategoryController(this), false);
        }
    }
}
