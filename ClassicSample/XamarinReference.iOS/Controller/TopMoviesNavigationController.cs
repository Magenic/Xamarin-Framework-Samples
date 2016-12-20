using XamarinReference.Lib.Interface;

using UIKit;

using MvvmCross.Platform;

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
