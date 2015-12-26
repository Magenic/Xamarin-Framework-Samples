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
    public class TopMusicVideosController : BaseTableViewController
    {

        private readonly IITunesDataService _itunesService = Mvx.Resolve<IITunesDataService>();
        private static readonly string CellReuse = "MusicVideoCell";

        private readonly string _genre;
        private Lib.Model.iTunes.MusicVideos.MusicVideo _musicVideo;
        private readonly TopMusicVideosNavigationController _navController;

        public TopMusicVideosController(string genre, TopMusicVideosNavigationController navController)
        {
            _genre = genre;
            _navController = navController;
        }

        public override void ViewDidAppear(bool animated)
        {
            SetupBackButton();
            //set the top navigation bar title 
            _navController.SetTitle(_genre);
            base.ViewDidAppear(animated);
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            if (_musicVideo != null)
            {
                return _musicVideo.Feed.Entry.Count;
            }
            return 0;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var musicVideo = _musicVideo.Feed.Entry[indexPath.Row];
            var cell = tableView.DequeueReusableCell(CellReuse, indexPath);

            cell.Accessory = UITableViewCellAccessory.None;
            cell.TextLabel.Text = musicVideo.ImName.Label;
            cell.TextLabel.Font = Helper.Theme.Font.F2(Helper.Theme.Font.H4);

            return cell;
        }

        private async Task SetupUi()
        {
            var task = _itunesService.GetMusicVideosAsync(25, _genre);

            this.TableView.RegisterClassForCellReuse(typeof(UITableViewCell), CellReuse);
            this.Title = _localizeLookupService.GetLocalizedString("TopMusicVideos");

            _musicVideo = await task;
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
