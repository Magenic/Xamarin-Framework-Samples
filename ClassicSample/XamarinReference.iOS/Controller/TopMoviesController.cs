using System;
using System.Collections.Generic;
using System.Text;

using XamarinReference.Lib.Interface;
using XamarinReference.Lib.Model;

using UIKit;
using Foundation;
using Cirrious.CrossCore;

namespace XamarinReference.iOS.Controller
{
    public class TopMoviesController : BaseTableViewController
    {
        private readonly IITunesDataService _itunesService = Mvx.Resolve<IITunesDataService>();
        private readonly List<string> _genres;

        private static readonly string CellReuse = "GenreCell";

        public TopMoviesController()
        {
            _genres = _itunesService.GetMovieGenres();    
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetupUi();
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _genres.Count; 
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var genre = _genres[indexPath.Row];
            var cell = tableView.DequeueReusableCell(CellReuse, indexPath);
            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
            cell.TextLabel.Text = genre;
            cell.TextLabel.Font = Helper.Theme.Font.F2(Helper.Theme.Font.H4);
            return cell; 
        }

        private void SetupUi()
        {
            TableView.RegisterClassForCellReuse(typeof(UITableViewCell), CellReuse);
        }


    }
}
