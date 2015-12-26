using System;
using System.Collections.Generic;
using System.Text;

using XamarinReference.Lib.Interface;
using XamarinReference.Lib.Model;

using UIKit;
using Foundation;
using Cirrious.CrossCore;
using CoreGraphics;
using System.Threading.Tasks;

namespace XamarinReference.iOS.Controller
{
    public class TopMovieRentalsController : BaseTableViewController
    {
        private readonly IITunesDataService _itunesService = Mvx.Resolve<IITunesDataService>();
        private static readonly string CellReuse = "MovieCell";

        private string _genre;
        private Lib.Model.iTunes.Movies.Movie _movies;
        private TopMoviesNavigationController _navController;

        public TopMovieRentalsController(string genre, TopMoviesNavigationController _navController)
        {
            this._genre = genre;
            this._navController = _navController;
        }

        public override void ViewDidAppear(bool animated)
        {
            SetupBackButton();
            //set the top navigation bar title 
            _navController.SetTitle(_genre);
            base.ViewDidAppear(animated);
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            await SetupUi();
            this.TableView.ReloadData();
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            if (_movies != null)
            {
                return _movies.Feed.Entry.Count;
            }
            return 0;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var movie = _movies.Feed.Entry[indexPath.Row];
            var cell = tableView.DequeueReusableCell(CellReuse, indexPath);

            cell.Accessory = UITableViewCellAccessory.None;
            cell.TextLabel.Text = movie.ImName.Label;
            cell.TextLabel.Font = Helper.Theme.Font.F2(Helper.Theme.Font.H4);

            return cell;
        }

        private async Task SetupUi()
        {
            var task = _itunesService.GetMoviesAsync(Lib.Model.iTunes.Movies.Movie.ListingType.TopRentals, 25, _genre);

            this.TableView.RegisterClassForCellReuse(typeof(UITableViewCell), CellReuse);
            this.Title = _localizeLookupService.GetLocalizedString("TopMovies");

            _movies = await task;
        }

        private void SetupBackButton()
        {
            var tabController = (TabController)this.TabBarController;

            if (tabController != null)
            {
                tabController.SetupBackNavigationButton();
                tabController.BackButton.Clicked += (o, e) =>
                {
                    _navController.PopViewController(true);
                    _navController.IsCategorySelected = false;
                    tabController.SetMenuNavigationButton();
                    tabController.Title = _localizeLookupService.GetLocalizedString("iTunes");
                };
            }
        }
    }
}
