using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UIKit;
using Foundation;
using XamarinReference.iOS.Controller;

namespace XamarinReference.iOS.Controller
{
    public class TabController : BaseTabBarController
    {
        private UIViewController tabTopMovies, tabTopMovieRentals, tabTopMusicVideos;
        private UIBarButtonItem _backButton;
        public UIBarButtonItem BackButton => _backButton; 

        public TabController()
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            this.TabBar.Translucent = true;
            this.TabBar.BarStyle = UIBarStyle.Black;
            this.TabBar.BarTintColor = UIColor.Black;
            this.TabBar.TintColor = Helper.Theme.Color.C14;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.Title = _localizeLookupService.GetLocalizedString("iTunes");
            this.HidesBottomBarWhenPushed = false;
            SetupTabs();
        }
        public override void ItemSelected(UITabBar tabbar, UITabBarItem item)
        {
            var controller = ViewControllers.SingleOrDefault(x => x.TabBarItem == item);
            if (controller != null)
            {
                if (controller is TopMoviesNavigationController)
                {
                    var selectedController = (TopMoviesNavigationController)controller;
                    if(!selectedController.IsCategorySelected)
                    {
                        this.SetMenuNavigationButton();
                    }
                } 
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (_backButton != null)
            {
                _backButton.Dispose();
                _backButton = null;
            }
            if (tabTopMovieRentals != null)
            {
                tabTopMovieRentals.Dispose();
                tabTopMovieRentals = null;
            }
            if (tabTopMovies != null)
            {
                tabTopMovies.Dispose();
                tabTopMovies = null;
            }
            if (tabTopMusicVideos != null)
            {
                tabTopMusicVideos.Dispose();
                tabTopMusicVideos = null;
            }
        }

        public void SetupBackNavigationButton()
        {
            //setup the back button to go back to the category listing
            _backButton = new UIBarButtonItem
            {
                Image = UIImage.FromBundle("back_white.png"),
            };

            this.NavigationItem.SetLeftBarButtonItem(_backButton, false);
        }

        private void SetupTabs()
        {
            tabTopMovies = new TopMoviesNavigationController(TopMoviesCategoryController.MovieControllerType.TopMovies)
            {
                TabBarItem = new UITabBarItem(_localizeLookupService.GetLocalizedString("TopMovies"), UIImage.FromBundle("f008.png"), 0),
                HidesBottomBarWhenPushed = false,
            };
            tabTopMovieRentals = new TopMoviesNavigationController(TopMoviesCategoryController.MovieControllerType.TopMovieRentals)
            {
                TabBarItem = new UITabBarItem(_localizeLookupService.GetLocalizedString("TopMovieRentals"), UIImage.FromBundle("f145.png"), 1),
                HidesBottomBarWhenPushed = false
            };

            tabTopMusicVideos = new TopMusicVideosController
            {
                TabBarItem = new UITabBarItem(_localizeLookupService.GetLocalizedString("TopMusicVideos"), UIImage.FromBundle("f001.png"), 2),
                HidesBottomBarWhenPushed = false
            };

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
