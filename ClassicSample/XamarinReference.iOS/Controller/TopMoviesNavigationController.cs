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

        protected readonly IStringLookupService _localizeLookupService = Mvx.Resolve<IStringLookupService>();
        private TopMoviesCategoryController.MovieControllerType _controllerType; 
        
        public bool IsCategorySelected { get; set; }

        public TopMoviesNavigationController(TopMoviesCategoryController.MovieControllerType controllerType)
        {
            _controllerType = controllerType;
            IsCategorySelected = false;
            SetupRootController();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

        }

        public void SetTitle(string selectedGenre)
        {
            var selectedController = (_controllerType == TopMoviesCategoryController.MovieControllerType.TopMovies) ? _localizeLookupService.GetLocalizedString("TopMovies") : _localizeLookupService.GetLocalizedString("TopMovieRentals");

            TabBarController.Title = string.Format("{0} - {1}", selectedController, selectedGenre);
        }

        private void SetupRootController()
        {
            this.PushViewController(new TopMoviesCategoryController(this, _controllerType), false);
        }
    }
}
