using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using UIKit;

using Xamarin.Media;
using XamarinReference.iOS.Helper;

using SWTableViewCells;
using XamarinReference.iOS.Controller;

namespace XamarinReference.iOS.Controls.Cell
{
    public class PicturePreviewCell : SWTableViewCell
    {
        private UIImageView _picturePreview;
        private UILabel _textLabel;
        
        private bool _isCellReused = false;

        public string FilePath { get; set; }
        public PicturePreviewCell(IntPtr handle) : base(handle)
        {
            SetupUi();
        }

        public void UpdateCell(string file)
        {
            if (!_isCellReused)
            {
                SetupUi();
            }
            SetupBinding(file);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (_picturePreview != null)
            {
                _picturePreview.Dispose();
                _picturePreview = null;
            }
            if (_textLabel != null)
            {
                _textLabel.Dispose();
                _textLabel = null;
            }
        }

        private void SetupBinding(string file)
        {
            this.FilePath = file;
            _textLabel.Text = this.FilePath;
            _picturePreview.Image = UIImage.FromFile(this.FilePath);
        }

        private void SetupUi()
        {
            try
            {
                //setup the image view first
                _picturePreview = new UIImageView
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Layer = {
                        BorderColor = UIColor.Black.CGColor,
                        BorderWidth = 1.0f
                    },
                };

                //setup constraints
                this.ContentView.InsertSubview(_picturePreview, 0);
                AutoLayoutHelper.AttachToParentLeft(this.ContentView, _picturePreview, 5);
                AutoLayoutHelper.AttachToParentVertically(this.ContentView, _picturePreview, 10);
                AutoLayoutHelper.SetWidth(_picturePreview, 60);
                AutoLayoutHelper.SetHeight(_picturePreview, 60);

                _textLabel = new UILabel
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Font = Helper.Theme.Font.F2(Helper.Theme.Font.H6),
                    TextColor = Helper.Theme.Color.C3,
                    LineBreakMode = UILineBreakMode.WordWrap,
                    Lines = 0
                };

                //seup the constraints
                this.ContentView.InsertSubview(_textLabel, 0);
                AutoLayoutHelper.FollowControlHorizontally(this.ContentView, _picturePreview, _textLabel, 10);
                AutoLayoutHelper.CenterControlVertically(this.ContentView, _textLabel);
                AutoLayoutHelper.AttachToParentRight(this.ContentView, _textLabel, 5);

                SetupRightUtilityButton();

                //setup constriants on the cell
                _isCellReused = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void SetupRightUtilityButton()
        {
            var buttons = new List<UIButton>();

            //create button to add
            var button = UIButton.FromType(UIButtonType.Custom);
            button.ExclusiveTouch = true;
            button.BackgroundColor = UIColor.Red;
            button.SetTitle("Delete", UIControlState.Normal);
            buttons.Add(button);

            this.SetRightUtilityButtons(buttons.ToArray(), 85.0f);
        }
    }


}
