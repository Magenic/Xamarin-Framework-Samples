using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Foundation;
using UIKit;

using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;

using Xamarin.Media;
using XamarinReference.iOS.Helper;
using XamarinReference.iOS.Controls.Cell;
using XamarinReference.Lib.Interface;
using SWTableViewCells;

namespace XamarinReference.iOS.Controller
{
    public class CameraController : BaseTableViewController 
    {
        //used for showing the camera icon
        private UIBarButtonItem _rightButton;
        private static readonly string CellReuse = "CameraCell";

        //used to get list of files
        private readonly IMediaService _mediaService = Mvx.Resolve<IMediaService>();

        //collection of files to display in the table
        private IList<string> _files;

        //delegate for PicturePreviewCell
        private readonly PicturePreviewCellDelegate _cellDelegate;

        public CameraController()
        {
            //load the list of files on the device
            _files = _mediaService.GetFiles(); 

            //setup cell reuse for performance - only works in iOS > 6 
            this.TableView.RegisterClassForCellReuse(typeof(PicturePreviewCell), CellReuse);
            this.TableView.RowHeight = UITableView.AutomaticDimension;
            this.TableView.EstimatedRowHeight = 60.0f;
            _cellDelegate = new PicturePreviewCellDelegate(this.TableView, this);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetupUi();
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _files.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var media = _files[indexPath.Row];

            var cell = tableView.DequeueReusableCell(CellReuse, indexPath) as PicturePreviewCell;
            cell.Delegate = _cellDelegate; 
            cell.UpdateCell(media);            
            return cell;
        }

        private void SetupUi()
        {
            //setup the navigation bar with the right camera icon
            this.Title = _localizeLookupService.GetLocalizedString("Camera");
            _rightButton = new UIBarButtonItem(UIImage.FromBundle("camera.png"), UIBarButtonItemStyle.Bordered, CameraIconPressed);

            //set the navigation button icon to be the camera for taking pictures
            NavigationItem.SetRightBarButtonItem(_rightButton, true);

            //setup the table for display
            SetupTableView();
        }

        private void SetupTableView()
        {
            //remove the ability to select
            this.TableView.AllowsSelection = false;
        }

        private async void CameraIconPressed(object sender, EventArgs e)
        {
            //use the Xamarin.Media library to take the picture
            //it's cross platform and allows for quick access for taking picutres
            //would want to use native calls if you need customized solution
            var picturePicker = new MediaPicker();
            if (!picturePicker.IsCameraAvailable)
            {
                //show alert that no camera is available
                var alert = UIAlertController.Create("Error", "Sorry I tried to access the camera on your device, but your device told me you don't have one.  I can't take a picture without one.", UIAlertControllerStyle.Alert);
                //add in the ok button
                alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                //show the alert dialog on the UI
                PresentViewController(alert, true, null);
            }
            else
            {
                try
                {
                    var media = await picturePicker.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        Name = string.Format("test_picture_{0}.jpg", DateTime.Now),
                        Directory = "CameraExample"
                    });
                    if (media != null)
                    {
                        _files.Add(media.Path);
                        this.TableView.ReloadData();
                    }
                }
                catch (OperationCanceledException operationCancelledException)
                {
                    //TODO log they cancelled taking the picture
                    System.Console.WriteLine(operationCancelledException);
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.StackTrace);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (_rightButton != null)
                {
                    _rightButton.Dispose();
                    _rightButton = null;
                }
            }
        }
    }

    public class PicturePreviewCellDelegate : SWTableViewCellDelegate
    {
        private readonly UITableView _tableView;
        private readonly CameraController _controller;
        private readonly IFileHelper _fileHelper = Mvx.Resolve<IFileHelper>();

        public PicturePreviewCellDelegate(UITableView tableView, CameraController controller)
        {
            _tableView = tableView;
            _controller = controller;
        }

        public override async void DidTriggerRightUtilityButton(SWTableViewCell cell, nint index)
        {
            //make sure the first button is tapped.  We only have one, but you never know
            if (index == 0)
            {
                var filePath = ((PicturePreviewCell)cell).FilePath;
                //validate that the filePath isn't empty
                if (!string.IsNullOrEmpty(filePath))
                {
                    //confirm via UIAlert to delete
                    var isDelete = await Helper.Utility.ShowAlert("Confirm", "Are you sure you would like to delete this file?", "Delete");
                    if (isDelete)
                    {
                        //delete the file and reload the table
                        _fileHelper.Delete(filePath);

                        //reload the table data without the file in it
                        _tableView.ReloadData();
                    }
                }
            }
        }

        public override bool ShouldHideUtilityButtonsOnSwipe(SWTableViewCell cell)
        {
            return true;
        }
    }

}
