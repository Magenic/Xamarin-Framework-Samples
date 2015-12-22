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
    public class TopMoviesController : BaseTableViewController
    {
        private readonly IITunesDataService _itunesService = Mvx.Resolve<IITunesDataService>();
        private static readonly string CellReuse = "MovieCell";

        private readonly string _genre;

        private Lib.Model.iTunes.Movie _movies;

        public TopMoviesController(string selectedGenre)
        {
            _genre = selectedGenre;
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
            var task = _itunesService.GetMoviesAsync(Lib.Model.iTunes.Movie.ListingType.TopMovies, 25, _genre);

            this.TableView.RegisterClassForCellReuse(typeof(UITableViewCell), CellReuse);
            this.Title = _localizeLookupService.GetLocalizedString("TopMovies");
            //bring up loading screen

            _movies = await task;
        }

    }
}
