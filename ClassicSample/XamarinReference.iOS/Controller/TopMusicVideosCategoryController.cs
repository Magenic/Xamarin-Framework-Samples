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
    public class TopMusicVideosCategoryController:BaseTableViewController
    {
        private readonly IITunesDataService _itunesService = Mvx.Resolve<IITunesDataService>();
        private readonly List<string> _genres;
        
        private static readonly string CellReuse = "GenreCell";
        private TopMusicVideosNavigationController _navController;

        public TopMusicVideosCategoryController(TopMusicVideosNavigationController navController)
        {
            _navController = navController;
            _genres = _itunesService.GetMusicVideoGenres();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            TabBarController.Title = _localizeLookupService.GetLocalizedString("iTunes");
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

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //get the selected data at the row selected
            var genre = _genres[indexPath.Row];

            _navController.PushViewController(new TopMusicVideosController(genre, _navController), true);

            //notify the _navController we have a category selected for redraw when tabs are changed and come back to (remember state)
            _navController.IsCategorySelected = true;

        }

        private void SetupUi()
        {
            this.TableView.RegisterClassForCellReuse(typeof(UITableViewCell), CellReuse);
            this.Title = _localizeLookupService.GetLocalizedString("TopMusicVideos");
        }
    }
}
