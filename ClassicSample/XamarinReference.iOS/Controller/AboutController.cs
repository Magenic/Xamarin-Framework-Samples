using System;
using System.Collections.Generic;
using System.Text;

using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;

using Foundation;
using UIKit;

using XamarinReference.Lib.Interface;

namespace XamarinReference.iOS.Controller
{
    public class AboutController : BaseTableViewController
    {
     
        private readonly IVersionInfo _versionInfo = Mvx.Resolve<IVersionInfo>();
        public AboutController() { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetupUi();
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            //hard code how many sections to return
            //currently app info and developer sections 
            return 2;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            nint rows = 0;
            switch (section)
            {
                //build info
                case 0:
                    rows = 3;
                    break;
                //developer cell
                case 1:
                    rows = 1;
                    break;
            }
            return rows;
        }

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            var headerLabel = string.Empty;

            switch (section)
            {
                case 0:
                    headerLabel = _localizeLookupService.GetLocalizedString("AboutBuild");
                    break;
                case 1:
                    headerLabel = _localizeLookupService.GetLocalizedString("AboutDeveloper");
                    break;
            }

            return headerLabel;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = null;
            switch (indexPath.Section)
            {
                case 0:
                    cell = GetBuildCell(indexPath);
                    break;
                case 1:
                    cell = GetDeveloperCell(indexPath);
                    break;
            }
            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            switch (indexPath.Section)
            {
                case 0:
                    //do nothing because we are just showing version info
                    break;
                case 1:
                    //do something with developer cell - call another view
                    break;

            }
        }

        private UITableViewCell GetBuildCell(NSIndexPath indexPath)
        {
            var cell = new UITableViewCell
            {
                SelectionStyle = UITableViewCellSelectionStyle.None
            };
            switch (indexPath.Row)
            {
                case 0:
                    var version = string.Format("{0} {1}", _localizeLookupService.GetLocalizedString("BuildVersion"), _versionInfo.ApplicationVersion);
                    cell.TextLabel.Text = version;
                    break;
                case 1:
                    var dateBuild = string.Format("{0} {1}", _localizeLookupService.GetLocalizedString("BuildDate"),
                        _versionInfo.ApplicationBuildTime); 
                    cell.TextLabel.Text = dateBuild;
                    break;
                case 2:
                    var osVersion = string.Format("{0} {1}", _localizeLookupService.GetLocalizedString("BuildOsVersion"),
                        _versionInfo.OperatingSystemVersion);
                    cell.TextLabel.Text = osVersion;
                    break;
            }
            return cell;
        }

        private UITableViewCell GetDeveloperCell(NSIndexPath indexPath)
        {
            var cell = new UITableViewCell
            {
                SelectionStyle = UITableViewCellSelectionStyle.None,
                TextLabel = { Text = _localizeLookupService.GetLocalizedString("DeveloperOptions")},
                Accessory = UITableViewCellAccessory.DisclosureIndicator
            };
            return cell;
        }

        private void SetupUi()
        {
            //set the title on the navigation bar
            this.NavigationController.NavigationBarHidden = false;
            this.Title = _localizeLookupService.GetLocalizedString("About");
            //setup tableview
            this.TableView = new UITableView(View.Bounds, UITableViewStyle.Grouped)
            {
                SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine,
                AutoresizingMask = UIViewAutoresizing.All,
                RowHeight = UITableView.AutomaticDimension
            };
        }
    }
}
