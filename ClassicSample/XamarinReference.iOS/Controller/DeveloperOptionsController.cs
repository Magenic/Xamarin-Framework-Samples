using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using UIKit;
using XamarinReference.Lib.Interface;

namespace XamarinReference.iOS.Controller
{
    public class DeveloperOptionsController : BaseTableViewController
    {
        //_backButton is used to display a back button to go back to the AboutController from the NavController
        private UIBarButtonItem _backButton;

        //_shareViewController - used to show the share view with options to share the log file via various activities
        private UIActivityViewController _shareViewController;

        public DeveloperOptionsController() { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetupUi();
        }

        public override void ViewDidAppear(bool animated)
        {
            SetupBackNavigationButton();
            base.ViewDidAppear(animated);
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            //currently hard coded to one as all we have is the logging section
            return 1;
        }
        public override nint RowsInSection(UITableView tableView, nint section)
        {
            var rows = 0;
            var rowsLogging = 3;

            switch (section)
            {
                //logging section
                case 0:
                    rows = rowsLogging; 
                    break;
            }
            return rows;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default, "LoggingCell")
            {
                SelectionStyle = UITableViewCellSelectionStyle.None
            };

            switch (indexPath.Row)
            {
                case 0:
                    cell.TextLabel.Text = _localizeLookupService.GetLocalizedString("LogFileView");
                    cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
                    break;
                case 1:
                    cell.TextLabel.Text = _localizeLookupService.GetLocalizedString("LogFileShare");
                    cell.Accessory = UITableViewCellAccessory.None;
                    break;
                case 2:
                    cell.TextLabel.Text = _localizeLookupService.GetLocalizedString("LogFileDelete");
                    cell.Accessory = UITableViewCellAccessory.None;
                    break;
            } 
            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            switch (indexPath.Row)
            {
                case 0:
                    ViewLogFile();
                    break;
                case 1:
                    ShareLogFile();
                    break;
                case 2:
                    DeleteLogFile();
                    break;
            }
        }

        
        public override string TitleForHeader(UITableView tableView, nint section)
        {
            var headerLabel = string.Empty;
            switch (section)
            {
                case 0:
                    headerLabel = _localizeLookupService.GetLocalizedString("DeveloperLogging");
                    break;
            }

            return headerLabel;
        }

        private void ViewLogFile()
        {
            //TODO:  show modal popup with the log file contents
        }

        private async void DeleteLogFile()
        {
            //make sure the logging option supports deleting files
            if (_logging is ILoggingFile)
            {
                //confirm via UIAlert to delete
                var isDelete = await Helper.Utility.ShowAlert(_localizeLookupService.GetLocalizedString("Confirm"), _localizeLookupService.GetLocalizedString("DeleteFileMessage"), _localizeLookupService.GetLocalizedString("Delete"), _localizeLookupService.GetLocalizedString("Cancel"));
                if (isDelete)
                {
                    //delete the file 
                    ((ILoggingFile)_logging).DeleteLog();

                }
            }
        }

        private void ShareLogFile()
        {
            try
            {
                //make sure the current logging service supports sharing the log file - some logging services shouldn't support this
                if (_logging is ILoggingFile)
                {
                    //get the file path of the log file to share
                    var path = ((ILoggingFile)_logging).LoggingPath;

                    //setup the view control to show sharing options
                    _shareViewController = new UIActivityViewController(
                        new NSObject[] { NSUrl.FromFilename(path) },
                        null)
                    {
                        //used to exclude sharing the log file to these types 
                        //of activities
                        ExcludedActivityTypes = new NSString[]
                        {
                            UIActivityType.AddToReadingList,
                            UIActivityType.AssignToContact,
                            UIActivityType.OpenInIBooks,
                            UIActivityType.PostToFacebook,
                            UIActivityType.PostToFlickr,
                            UIActivityType.PostToTencentWeibo,
                            UIActivityType.PostToTwitter,
                            UIActivityType.PostToVimeo,
                            UIActivityType.PostToWeibo,
                            UIActivityType.Print,
                            UIActivityType.SaveToCameraRoll
                        },
                    };
                    this.PresentViewController(_shareViewController, true, null);
                }
            }
            catch (Exception ex)
            {
                this.DealWithErrors(ex);
            }
        }

        private void SetupBackNavigationButton()
        {
            //setup the back button to go back to the category listing
            _backButton = new UIBarButtonItem
            {
                Image = UIImage.FromBundle("back_white.png"),
            };

            //handle back button clicked to go back to the About Controller
            _backButton.Clicked += (o, e) =>
            {
                this.NavMenuController.PopViewController(true);
            };

            this.NavigationItem.SetLeftBarButtonItem(_backButton, false);
        }

        private void SetupUi()
        {
            this.Title = _localizeLookupService.GetLocalizedString("DeveloperOptions");

            SetupTableView();
        }

        private void SetupTableView()
        {
            this.TableView = new UIKit.UITableView(View.Bounds, UIKit.UITableViewStyle.Grouped);
            this.TableView.SeparatorStyle = UIKit.UITableViewCellSeparatorStyle.SingleLine;
            this.TableView.AutoresizingMask = UIKit.UIViewAutoresizing.All;
            this.TableView.RowHeight = UIKit.UITableView.AutomaticDimension;
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (_backButton != null)
            {
                _backButton.Dispose();
                _backButton = null;
            }
            if (_shareViewController != null)
            {
                _shareViewController.Dispose();
                _shareViewController = null;
            }
        }
    }
}
