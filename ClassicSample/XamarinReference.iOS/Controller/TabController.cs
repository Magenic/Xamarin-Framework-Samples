using System;
using System.Collections.Generic;
using System.Text;

using UIKit;
using Foundation;
using XamarinReference.iOS.Controller;

namespace XamarinReference.iOS.Controller
{
    public class TabController : BaseTabBarController
    {
        UIViewController tabTopMovies, tabTopMovieRentals, tabTopMusicVideos;
        public TabController()
        {
            SetupTabs();
        }

        private void SetupTabs()
        {
            tabTopMovies = new TopMoviesController();
            tabTopMovies.Title = _localizeLookupService.GetLocalizedString("TopMovies");

            tabTopMovieRentals = new TopMovieRentalsController();
            tabTopMovieRentals.Title = _localizeLookupService.GetLocalizedString("TopMovieRentals");

            tabTopMusicVideos = new TopMusicVideosController();
            tabTopMusicVideos.Title = _localizeLookupService.GetLocalizedString("topMusicVideos");
            var tabs = new UIViewController[]
            {
                tabTopMovies,
                tabTopMovieRentals,
                tabTopMusicVideos
            };

            ViewControllers = tabs;
        }
    }
}
