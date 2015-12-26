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
    public class TopMusicVideosNavigationController : UINavigationController
    {
        protected readonly IStringLookupService _localizeLookupService = Mvx.Resolve<IStringLookupService>();

        public bool IsCategorySelected { get; set; }

        public TopMusicVideosNavigationController()
        {
            IsCategorySelected = false;
            SetupRootController();
        }
        public void SetTitle(string selectedGenre)
        {
            TabBarController.Title = string.Format("{0} - {1}", _localizeLookupService.GetLocalizedString("TopMusicVideos"), selectedGenre);
        }

        private void SetupRootController()
        {
            this.PushViewController(new TopMusicVideosCategoryController(this), true); 
        }
    }
}
