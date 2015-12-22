using CoreAnimation;
using Foundation;
using System;
using System.Collections.Generic;
using System.Text;

using UIKit;


using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;

using XamarinReference.iOS.Controls.View;
using XamarinReference.iOS.Helper;
using XamarinReference.Lib.Interface;
using XamarinReference.Lib.Model;

//xamarin control for radial progress
using RadialProgress;

namespace XamarinReference.iOS.Controls.Cell
{
    public class BusinessCardCell : UITableViewCell 
    {
        private readonly IStringLookupService _services = Mvx.Resolve<IStringLookupService>();

        //view to hold content
        private UIView _innerView;

        //private controls in the view
        private UILabel _jobName;
        private UILabel _companyName;
        private UILabel _officeLocation;
        private UILabel _dueDate;

        //dividers to attach to to give space
        private UIView _topDivider;
        private UIView _middleDivider;
        private UIView _bottomDivider;

        //view to hold due date and status 
        private UIView _dueDateView;
        private UIView _rightDueDateDivider;
        private UIView _jobStatusView;

        //used for holding KPI lights
        private UIView _lightsContainerView;
        private UIView _redLightView;
        private UIView _yellowLightView;
        private UIView _greenLightView;

        //bottom number views for tasks
        private UIView _tasksInProgressView;
        private UIView _tasksInProgressSeperatorView;
        private UIView _tasksInReviewView;
        private UIView _tasksInReviewSeperatorView;
        private UIView _tasksForReviewView;
        private UIView _tasksForReviewSeperatorView;
        private UIView _tasksToDoView;

        private UILabel _tasksInProgressHeader;
        private UILabel _tasksInReviewHeader;
        private UILabel _tasksForReviewHeader;
        private UILabel _tasksToDoHeader;
        private UILabel _tasksInProgress;
        private UILabel _tasksInReview;
        private UILabel _tasksForReview;
        private UILabel _tasksToDo;

        private UIView _percentPrepView;
        private UIView _percentWorkView;
        private UIView _percentDeliveryView;

        private UILabel _percentPrepHeader;
        private UILabel _percentWorkHeader;
        private UILabel _percentDeliveryHeader;

        private RadialProgressView _percentPrepRadialView;
        private RadialProgressView _percentWorkRadialView;
        private RadialProgressView _percentDeliveryRadialView;
        
        private bool _isCellResused = false;


        public BusinessCardCell(IntPtr handle):base(handle) 
        {
        }

        public void UpdateCell(Job job)
        {
            if (!_isCellResused)
            {
                SetupUi();
            }
            SetupBinding(job);
        }

        private void SetupUi()
        {
            try
            {
                //set the selection style
                this.SelectionStyle = UITableViewCellSelectionStyle.None;

                //set the background color of the cell to the same color of the tableView
                this.BackgroundColor = Helper.Theme.Color.C19;

                //set the border of the cell to be a little lighter, this will give it the look that the cell is floating in space by having the business card view's background color white
                //create a inner view that we change the background color and all content in.  This will make the content look like it's floating in the table view
                _innerView = new UIView
                {
                    BackgroundColor = Helper.Theme.Color.C1,
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Layer = {
                        BorderColor = Helper.Theme.Color.C20.CGColor,
                        BorderWidth = 1.0f,
                    }
                };

                //add the innerView into the contentview of the cell and attach it to the top, bottom, left, and right side of the cell
                this.ContentView.InsertSubview(_innerView, 0);
                AutoLayoutHelper.AttachToParentHorizontally(this.ContentView, _innerView, 0);
                AutoLayoutHelper.AttachToParentVertically(this.ContentView, _innerView, 4);

                //setup header labels
                _companyName = new UILabel
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Font = Helper.Theme.Font.F2(Helper.Theme.Font.H6),
                    TextColor = Helper.Theme.Color.C13,
                    LineBreakMode = UILineBreakMode.WordWrap,
                    Lines = 0
                };

                _innerView.InsertSubview(_companyName, 0);
                //setup _companyName layout in innerView below _jobName 
                AutoLayoutHelper.AttachToParentTop(_innerView, _companyName, 4);
                AutoLayoutHelper.AttachToParentHorizontally(_innerView, _companyName, 10);

                _officeLocation = new UILabel
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Font = Helper.Theme.Font.F2(Helper.Theme.Font.H6),
                    TextColor = Helper.Theme.Color.C13,
                    LineBreakMode = UILineBreakMode.WordWrap,
                    Lines = 0
                };

                _innerView.InsertSubview(_officeLocation, 0);
                //setup _officeLocation layout in innerView below _jobName 
                AutoLayoutHelper.FollowControlVertically(_innerView, _companyName, _officeLocation, 2);
                AutoLayoutHelper.AttachToParentHorizontally(_innerView, _officeLocation, 10);

                _jobName = new UILabel
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Font = Helper.Theme.Font.F2(Helper.Theme.Font.H4),
                    TextColor = Helper.Theme.Color.C3,
                    LineBreakMode = UILineBreakMode.WordWrap,
                    Lines = 0
                };

                _innerView.InsertSubview(_jobName, 0);
                //setup _jobName layout in innerview
                AutoLayoutHelper.FollowControlVertically(_innerView, _officeLocation, _jobName, 10);
                AutoLayoutHelper.AttachToParentHorizontally(_innerView, _jobName, 10);

                _topDivider = new UIView
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    BackgroundColor = Helper.Theme.Color.C19
                };

                _innerView.InsertSubview(_topDivider, 0);
                AutoLayoutHelper.FollowControlVertically(_innerView, _jobName, _topDivider, 6);
                AutoLayoutHelper.AttachToParentHorizontally(_innerView, _topDivider, 4);
                AutoLayoutHelper.SetHeight(_topDivider, 1.0f);

                //setup the middle row of due date and status
                _dueDateView = new UIView
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                };

                _innerView.InsertSubview(_dueDateView, 0);
                AutoLayoutHelper.FollowControlVertically(_innerView, _topDivider, _dueDateView, 1);
                AutoLayoutHelper.AttachToParentLeft(_innerView, _dueDateView, 10);

                _dueDate = new UILabel
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Font = Helper.Theme.Font.F2(Helper.Theme.Font.H6),
                    TextColor = Helper.Theme.Color.C3,
                    LineBreakMode = UILineBreakMode.Clip
                };

                _dueDateView.InsertSubview(_dueDate, 0);
                AutoLayoutHelper.CenterControlHorizontally(_dueDateView, _dueDate);
                AutoLayoutHelper.CenterControlVertically(_dueDateView, _dueDate);

                //setup the divider between them to draw line to seperate data
                _rightDueDateDivider = new UIView
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    BackgroundColor = Helper.Theme.Color.C19
                };

                _innerView.InsertSubview(_rightDueDateDivider, 0);
                AutoLayoutHelper.FollowControlVertically(_innerView, _topDivider, _rightDueDateDivider, 1);
                AutoLayoutHelper.FollowControlHorizontally(_innerView, _dueDateView, _rightDueDateDivider, 10);

                AutoLayoutHelper.SetWidth(_rightDueDateDivider, 2);
                AutoLayoutHelper.SetRelativeHeight(_innerView, _dueDateView, _rightDueDateDivider, 1);

                _jobStatusView = new UIView
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                };

                _innerView.InsertSubview(_jobStatusView, 0);
                AutoLayoutHelper.FollowControlVertically(_innerView, _topDivider, _jobStatusView, 1);
                AutoLayoutHelper.FollowControlHorizontally(_innerView, _rightDueDateDivider, _jobStatusView, 10);
                AutoLayoutHelper.AttachToParentRight(_innerView, _jobStatusView, 10);


                _lightsContainerView = new UIView()
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                };

                _jobStatusView.InsertSubview(_lightsContainerView, 0);
                AutoLayoutHelper.CenterControlHorizontally(_jobStatusView, _lightsContainerView);
                AutoLayoutHelper.CenterControlVertically(_jobStatusView, _lightsContainerView);

                //create stop lights for KPI
                _greenLightView = new UIView
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    BackgroundColor = Helper.Theme.Color.C8.ColorWithAlpha(0.5f),
                    Layer = { CornerRadius = 10 }
                };

                _lightsContainerView.InsertSubview(_greenLightView, 0);
                AutoLayoutHelper.AttachToParentVertically(_lightsContainerView, _greenLightView, 5);
                AutoLayoutHelper.AttachToParentLeft(_lightsContainerView, _greenLightView, 5);

                AutoLayoutHelper.SetHeight(_greenLightView, 20);
                AutoLayoutHelper.SetWidth(_greenLightView, 20);

                _yellowLightView = new UIView
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    BackgroundColor = Helper.Theme.Color.C8.ColorWithAlpha(0.5f),
                    Layer = { CornerRadius = 10 }
                };

                _lightsContainerView.InsertSubview(_yellowLightView, 0);

                AutoLayoutHelper.FollowControlHorizontally(_lightsContainerView, _greenLightView, _yellowLightView, 10);
                AutoLayoutHelper.AttachToParentVertically(_lightsContainerView, _yellowLightView, 5);

                AutoLayoutHelper.SetHeight(_yellowLightView, 20);
                AutoLayoutHelper.SetWidth(_yellowLightView, 20);

                _redLightView = new UIView
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    BackgroundColor = Helper.Theme.Color.C8.ColorWithAlpha(0.5f),
                    Layer = { CornerRadius = 10 }
                };

                _lightsContainerView.InsertSubview(_redLightView, 0);
                AutoLayoutHelper.FollowControlHorizontally(_lightsContainerView, _yellowLightView, _redLightView, 10);
                AutoLayoutHelper.AttachToParentRight(_lightsContainerView, _redLightView, 5);
                AutoLayoutHelper.AttachToParentVertically(_jobStatusView, _redLightView, 5);

                AutoLayoutHelper.SetHeight(_redLightView, 20);
                AutoLayoutHelper.SetWidth(_redLightView, 20);

                //set the job status view and the due date view to be the same width
                AutoLayoutHelper.SetRelativeWidth(_innerView, _jobStatusView, _dueDateView, 1);

                //set the due date view and job status view to the same height
                AutoLayoutHelper.SetRelativeHeight(_innerView, _jobStatusView, _dueDateView, 1);

                //draw divider between status and graphics
                _middleDivider = new UIView
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    BackgroundColor = Helper.Theme.Color.C19
                };

                _innerView.InsertSubview(_middleDivider, 0);
                AutoLayoutHelper.FollowControlVertically(_innerView, _dueDateView, _middleDivider, 1);
                AutoLayoutHelper.AttachToParentHorizontally(_innerView, _middleDivider, 4);
                AutoLayoutHelper.SetHeight(_middleDivider, 1);


                _percentPrepView = new UIView
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                };

                _innerView.InsertSubview(_percentPrepView, 0);
                AutoLayoutHelper.FollowControlVertically(_innerView, _middleDivider, _percentPrepView, 4);
                AutoLayoutHelper.AttachToParentLeft(_innerView, _percentPrepView, 10);
                AutoLayoutHelper.SetHeight(_percentPrepView, 60);

                _percentPrepHeader = new UILabel
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Font = Helper.Theme.Font.F2(Helper.Theme.Font.H6),
                    TextColor = Helper.Theme.Color.C3,
                    Text = _services.GetLocalizedString("PercentPrep")
                };

                _percentPrepView.InsertSubview(_percentPrepHeader, 0);
                AutoLayoutHelper.AttachToParentTop(_percentPrepView, _percentPrepHeader, 5);
                AutoLayoutHelper.CenterControlHorizontally(_percentPrepView, _percentPrepHeader);

                _percentPrepRadialView = new RadialProgressView(progressType: RadialProgressViewStyle.Small) {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    MinValue = 0,
                    MaxValue = 100,
                };

                _percentPrepView.InsertSubview(_percentPrepRadialView, 0);
                AutoLayoutHelper.FollowControlVertically(_percentPrepView, _percentPrepHeader, _percentPrepRadialView, 2);
                AutoLayoutHelper.CenterControlHorizontally(_percentPrepView, _percentPrepRadialView);
                AutoLayoutHelper.AttachToParentBottom(_percentPrepView, _percentPrepRadialView, 10);

                _percentWorkView = new UIView
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                };

                _innerView.InsertSubview(_percentWorkView, 0);
                AutoLayoutHelper.FollowControlVertically(_innerView, _middleDivider, _percentWorkView, 4);
                AutoLayoutHelper.FollowControlHorizontally(_innerView, _percentPrepView, _percentWorkView, 10);
                AutoLayoutHelper.SetHeight(_percentWorkView, 60);

                _percentWorkHeader = new UILabel
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Font = Helper.Theme.Font.F2(Helper.Theme.Font.H6),
                    TextColor = Helper.Theme.Color.C3,
                    Text = _services.GetLocalizedString("PercentWork")
                };

                _percentWorkView.InsertSubview(_percentWorkHeader, 0);
                AutoLayoutHelper.AttachToParentTop(_percentWorkView, _percentWorkHeader, 5);
                AutoLayoutHelper.CenterControlHorizontally(_percentWorkView, _percentWorkHeader);

                _percentWorkRadialView = new RadialProgressView(progressType: RadialProgressViewStyle.Small)
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    MinValue = 0,
                    MaxValue = 100,
                };

                _percentWorkView.InsertSubview(_percentWorkRadialView, 0);
                AutoLayoutHelper.FollowControlVertically(_percentWorkView, _percentWorkHeader, _percentWorkRadialView, 2);
                AutoLayoutHelper.CenterControlHorizontally(_percentWorkView, _percentWorkRadialView);
                AutoLayoutHelper.AttachToParentBottom(_percentWorkView, _percentWorkRadialView, 10);

                _percentDeliveryView = new UIView
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                };

                _innerView.InsertSubview(_percentDeliveryView, 0);
                AutoLayoutHelper.FollowControlVertically(_innerView, _middleDivider, _percentDeliveryView, 4);
                AutoLayoutHelper.FollowControlHorizontally(_innerView, _percentWorkView, _percentDeliveryView, 10);
                AutoLayoutHelper.AttachToParentRight(_innerView, _percentDeliveryView, 10);
                AutoLayoutHelper.SetHeight(_percentDeliveryView, 60);

                _percentDeliveryHeader = new UILabel
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Font = Helper.Theme.Font.F2(Helper.Theme.Font.H6),
                    TextColor = Helper.Theme.Color.C3,
                    Text = _services.GetLocalizedString("PercentDelivery")
                };

                _percentDeliveryView.InsertSubview(_percentDeliveryHeader, 0);
                AutoLayoutHelper.AttachToParentTop(_percentDeliveryView, _percentDeliveryHeader, 5);
                AutoLayoutHelper.CenterControlHorizontally(_percentDeliveryView, _percentDeliveryHeader);

                _percentDeliveryRadialView = new RadialProgressView(progressType: RadialProgressViewStyle.Small)
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    MinValue = 0,
                    MaxValue = 100,
                };

                _percentDeliveryView.InsertSubview(_percentDeliveryRadialView, 0);
                AutoLayoutHelper.FollowControlVertically(_percentDeliveryView, _percentDeliveryHeader, _percentDeliveryRadialView, 2);
                AutoLayoutHelper.CenterControlHorizontally(_percentDeliveryView, _percentDeliveryRadialView);
                AutoLayoutHelper.AttachToParentBottom(_percentDeliveryView, _percentDeliveryRadialView, 10);

                //make all 3 views equal width and height
                AutoLayoutHelper.SetRelativeWidth(_innerView, _percentPrepView, _percentWorkView, 1);
                AutoLayoutHelper.SetRelativeWidth(_innerView, _percentPrepView, _percentDeliveryView, 1);

                AutoLayoutHelper.SetRelativeHeight(_innerView, _percentPrepView, _percentWorkView, 1);
                AutoLayoutHelper.SetRelativeHeight(_innerView, _percentPrepView, _percentDeliveryView, 1);

                //draw divider between graphics and bottom views
                _bottomDivider = new UIView
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    BackgroundColor = Helper.Theme.Color.C19
                };

                _innerView.InsertSubview(_bottomDivider, 0);
                AutoLayoutHelper.FollowControlVertically(_innerView, _percentPrepView, _bottomDivider, 10);
                AutoLayoutHelper.AttachToParentHorizontally(_innerView, _bottomDivider, 4);
                AutoLayoutHelper.SetHeight(_bottomDivider, 1);

                _tasksInProgressView = new UIView
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                };

                _innerView.InsertSubview(_tasksInProgressView, 0);
                AutoLayoutHelper.FollowControlVertically(_innerView, _bottomDivider, _tasksInProgressView, 1);
                AutoLayoutHelper.AttachToParentLeft(_innerView, _tasksInProgressView, 10);
                AutoLayoutHelper.AttachToParentBottom(_innerView, _tasksInProgressView, 5);


                _tasksInProgressHeader = new UILabel
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Font = Helper.Theme.Font.F2(Helper.Theme.Font.H6),
                    TextColor = Helper.Theme.Color.C3,
                    Text = _services.GetLocalizedString("TaskInProgress")
                };

                _tasksInProgressView.InsertSubview(_tasksInProgressHeader, 0);
                AutoLayoutHelper.AttachToParentTop(_tasksInProgressView, _tasksInProgressHeader, 2);
                AutoLayoutHelper.CenterControlHorizontally(_tasksInProgressView, _tasksInProgressHeader);

                _tasksInProgress = new UILabel
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Font = Helper.Theme.Font.F2(Helper.Theme.Font.H6),
                    TextColor = Helper.Theme.Color.C13
                };
                _tasksInProgressView.InsertSubview(_tasksInProgress, 0);
                AutoLayoutHelper.CenterControlHorizontally(_tasksInProgressView, _tasksInProgress);
                AutoLayoutHelper.FollowControlVertically(_tasksInProgressView, _tasksInProgressHeader, _tasksInProgress, 4);
                AutoLayoutHelper.AttachToParentBottom(_tasksInProgressView,  _tasksInProgress, 4);

                _tasksInProgressSeperatorView = new UIView
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    BackgroundColor = Helper.Theme.Color.C19
                };

                _innerView.InsertSubview(_tasksInProgressSeperatorView, 0);
                AutoLayoutHelper.FollowControlVertically(_innerView, _bottomDivider, _tasksInProgressSeperatorView, 1);
                AutoLayoutHelper.FollowControlHorizontally(_innerView, _tasksInProgressView, _tasksInProgressSeperatorView, 5);
                AutoLayoutHelper.AttachToParentBottom(_innerView, _tasksInProgressSeperatorView, 5);

                AutoLayoutHelper.SetWidth(_tasksInProgressSeperatorView, 1);
                AutoLayoutHelper.SetRelativeHeight(_innerView, _tasksInProgressView, _tasksInProgressSeperatorView, 1);

                _tasksInReviewView = new UIView
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                };

                _innerView.InsertSubview(_tasksInReviewView, 0);
                AutoLayoutHelper.FollowControlVertically(_innerView, _bottomDivider, _tasksInReviewView, 1);
                AutoLayoutHelper.FollowControlHorizontally(_innerView, _tasksInProgressSeperatorView, _tasksInReviewView, 10);
                AutoLayoutHelper.AttachToParentBottom(_innerView, _tasksInReviewView, 5);

                _tasksInReviewHeader = new UILabel
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Font = Helper.Theme.Font.F2(Helper.Theme.Font.H6),
                    TextColor = Helper.Theme.Color.C3,
                    Text = _services.GetLocalizedString("TaskInReview")
                };

                _tasksInReviewView.InsertSubview(_tasksInReviewHeader, 0);
                AutoLayoutHelper.AttachToParentTop(_tasksInReviewView, _tasksInReviewHeader, 2);
                AutoLayoutHelper.CenterControlHorizontally(_tasksInReviewView, _tasksInReviewHeader);

                _tasksInReview = new UILabel
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Font = Helper.Theme.Font.F2(Helper.Theme.Font.H6),
                    TextColor = Helper.Theme.Color.C13
                };

                _tasksInReviewView.InsertSubview(_tasksInReview, 0);
                AutoLayoutHelper.CenterControlHorizontally(_tasksInReviewView, _tasksInReview);
                AutoLayoutHelper.FollowControlVertically(_tasksInReviewView, _tasksInReviewHeader, _tasksInReview, 4);
                AutoLayoutHelper.AttachToParentBottom(_tasksInReviewView, _tasksInReview, 4);

                _tasksInReviewSeperatorView = new UIView
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    BackgroundColor = Helper.Theme.Color.C19
                };

                _innerView.InsertSubview(_tasksInReviewSeperatorView, 0);
                AutoLayoutHelper.FollowControlVertically(_innerView, _bottomDivider, _tasksInReviewSeperatorView, 1);
                AutoLayoutHelper.FollowControlHorizontally(_innerView, _tasksInReviewView, _tasksInReviewSeperatorView, 5);
                AutoLayoutHelper.AttachToParentBottom(_innerView, _tasksInReviewSeperatorView, 5);

                AutoLayoutHelper.SetWidth(_tasksInReviewSeperatorView, 1);
                AutoLayoutHelper.SetRelativeHeight(_innerView, _tasksInProgressView, _tasksInReviewSeperatorView, 1);

                _tasksForReviewView = new UIView
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                };

                _innerView.InsertSubview(_tasksForReviewView, 0);
                AutoLayoutHelper.FollowControlVertically(_innerView, _bottomDivider, _tasksForReviewView, 1);
                AutoLayoutHelper.FollowControlHorizontally(_innerView, _tasksInReviewSeperatorView, _tasksForReviewView, 10);
                AutoLayoutHelper.AttachToParentBottom(_innerView, _tasksForReviewView, 5);

                _tasksForReviewHeader = new UILabel
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Font = Helper.Theme.Font.F2(Helper.Theme.Font.H6),
                    TextColor = Helper.Theme.Color.C3,
                    Text = _services.GetLocalizedString("TaskForReview")
                };

                _tasksForReviewView.InsertSubview(_tasksForReviewHeader, 0);
                AutoLayoutHelper.AttachToParentTop(_tasksForReviewView, _tasksForReviewHeader, 2);
                AutoLayoutHelper.CenterControlHorizontally(_tasksForReviewView, _tasksForReviewHeader);

                _tasksForReview = new UILabel
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Font = Helper.Theme.Font.F2(Helper.Theme.Font.H6),
                    TextColor = Helper.Theme.Color.C13
                };

                _tasksForReviewView.InsertSubview(_tasksForReview, 0);
                AutoLayoutHelper.CenterControlHorizontally(_tasksForReviewView, _tasksForReview);
                AutoLayoutHelper.FollowControlVertically(_tasksForReviewView, _tasksForReviewHeader, _tasksForReview, 4);
                AutoLayoutHelper.AttachToParentBottom(_tasksForReviewView, _tasksForReview, 4);

                _tasksForReviewSeperatorView = new UIView
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    BackgroundColor = Helper.Theme.Color.C19
                };

                _innerView.InsertSubview(_tasksForReviewSeperatorView, 0);
                AutoLayoutHelper.FollowControlVertically(_innerView, _bottomDivider, _tasksForReviewSeperatorView, 1);
                AutoLayoutHelper.FollowControlHorizontally(_innerView, _tasksForReviewView, _tasksForReviewSeperatorView, 5);
                AutoLayoutHelper.AttachToParentBottom(_innerView, _tasksForReviewSeperatorView, 5);

                AutoLayoutHelper.SetWidth(_tasksForReviewSeperatorView, 1);
                AutoLayoutHelper.SetRelativeHeight(_innerView, _tasksInProgressView, _tasksForReviewSeperatorView, 1);

                _tasksToDoView = new UIView
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                };

                _innerView.InsertSubview(_tasksToDoView, 0);
                AutoLayoutHelper.FollowControlVertically(_innerView, _bottomDivider, _tasksToDoView, 1);
                AutoLayoutHelper.AttachToParentRight(_innerView, _tasksToDoView, 10);
                AutoLayoutHelper.FollowControlHorizontally(_innerView, _tasksForReviewSeperatorView, _tasksToDoView, 10);
                AutoLayoutHelper.AttachToParentBottom(_innerView, _tasksToDoView, 5);

                _tasksToDoHeader = new UILabel
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Font = Helper.Theme.Font.F2(Helper.Theme.Font.H6),
                    TextColor = Helper.Theme.Color.C3,
                    Text = _services.GetLocalizedString("TaskToDo")
                };

                _tasksToDoView.InsertSubview(_tasksToDoHeader, 0);
                AutoLayoutHelper.AttachToParentTop(_tasksToDoView, _tasksToDoHeader, 2);
                AutoLayoutHelper.CenterControlHorizontally(_tasksToDoView, _tasksToDoHeader);

                _tasksToDo = new UILabel
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Font = Helper.Theme.Font.F2(Helper.Theme.Font.H6),
                    TextColor = Helper.Theme.Color.C13
                };

                _tasksToDoView.InsertSubview(_tasksToDo, 0);
                AutoLayoutHelper.CenterControlHorizontally(_tasksToDoView, _tasksToDo);
                AutoLayoutHelper.FollowControlVertically(_tasksToDoView, _tasksToDoHeader, _tasksToDo, 4);
                AutoLayoutHelper.AttachToParentBottom(_tasksToDoView, _tasksToDo, 4);

                    //set each task view to same width
                AutoLayoutHelper.SetRelativeWidth(_innerView, _tasksInProgressView, _tasksInReviewView, 1);
                AutoLayoutHelper.SetRelativeWidth(_innerView, _tasksInProgressView, _tasksForReviewView, 1);
                AutoLayoutHelper.SetRelativeWidth(_innerView, _tasksInProgressView, _tasksToDoView, 1);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            _isCellResused = true;
        }

        private void SetupBinding(Job job)
        {
            _jobName.Text = job.JobName;
            _companyName.Text = job.CompanyName;
            _officeLocation.Text = job.OfficeLocation;

            if (job.DueDate != null)
            {
                var date = (DateTime)job.DueDate;
                _dueDate.Text = date.ToShortDateString();

                if (date < DateTime.Now)
                {
                    _dueDate.TextColor = Helper.Theme.Color.C15;
                }
            }

            //set action colors
            switch (job.NeedAction)
            {
                case 0:
                    _greenLightView.BackgroundColor = UIColor.Green.ColorWithAlpha(0.5f);
                    _yellowLightView.BackgroundColor = Helper.Theme.Color.C8.ColorWithAlpha(0.5f);
                    _redLightView.BackgroundColor = Helper.Theme.Color.C8.ColorWithAlpha(0.5f);
                    break;
                case 1:
                    _greenLightView.BackgroundColor = Helper.Theme.Color.C8.ColorWithAlpha(0.5f); 
                    _yellowLightView.BackgroundColor = Helper.Theme.Color.C14.ColorWithAlpha(0.5f); 
                    _redLightView.BackgroundColor = Helper.Theme.Color.C8.ColorWithAlpha(0.5f);
                    break;
                case 2:
                    _greenLightView.BackgroundColor = Helper.Theme.Color.C8.ColorWithAlpha(0.5f); 
                    _yellowLightView.BackgroundColor = Helper.Theme.Color.C8.ColorWithAlpha(0.5f);
                    _redLightView.BackgroundColor = UIColor.Red.ColorWithAlpha(0.5f); 
                    break;
            }

            _tasksInProgress.Text = job.TaskInProgress.ToString();
            _tasksInReview.Text = job.TaskInReview.ToString();
            _tasksForReview.Text = job.TaskForReview.ToString();
            _tasksToDo.Text = job.TaskToDo.ToString();

            _percentPrepRadialView.Value = (nfloat)job.PercentPrep;
            _percentWorkRadialView.Value = (nfloat)job.PercentWork;
            _percentDeliveryRadialView.Value = (nfloat)job.PercentDelivery;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_innerView != null)
                {
                    _innerView.Dispose();
                    _innerView = null;
                }
                if(_jobName != null)
                {
                    _jobName.Dispose();
                    _jobName = null;
                }
                if(_companyName != null)
                {
                    _companyName.Dispose();
                    _companyName = null;
                }
                if(_officeLocation != null)
                {
                    _officeLocation.Dispose();
                    _officeLocation = null;
                }
                if (_dueDateView != null)
                {
                    _dueDateView.Dispose();
                    _dueDateView = null;
                }
                if(_jobStatusView != null)
                {
                    _jobStatusView.Dispose();
                    _jobStatusView = null;
                }
                if (_rightDueDateDivider != null)
                {
                    _rightDueDateDivider.Dispose();
                    _rightDueDateDivider = null;
                }
                if (_lightsContainerView != null)
                {
                    _lightsContainerView.Dispose();
                    _lightsContainerView = null;
                }
                if(_greenLightView != null)
                {
                    _greenLightView.Dispose();
                    _greenLightView = null;
                }
                if (_yellowLightView != null)
                {
                    _yellowLightView.Dispose();
                    _yellowLightView = null;
                }
                if (_redLightView != null)
                {
                    _redLightView.Dispose();
                    _redLightView = null;
                }
                if(_tasksInProgressView != null)
                {
                    _tasksInProgressView.Dispose();
                    _tasksInProgressView = null;
                }
                if (_tasksInProgressSeperatorView != null)
                {
                    _tasksInProgressSeperatorView.Dispose();
                    _tasksInProgressSeperatorView = null;
                }
                if (_tasksInReviewView != null)
                {
                    _tasksInReviewView.Dispose();
                    _tasksInReviewView = null;
                }
                if (_tasksInReviewSeperatorView != null)
                {
                    _tasksInReviewSeperatorView.Dispose();
                    _tasksInReviewSeperatorView = null;
                }
                if (_tasksForReviewView != null)
                {
                    _tasksForReviewView.Dispose();
                    _tasksForReviewView = null;
                }
                if (_tasksForReviewSeperatorView != null)
                {
                    _tasksForReviewSeperatorView.Dispose();
                    _tasksForReviewSeperatorView = null;
                }
                if (_tasksToDoView != null)
                {
                    _tasksToDoView.Dispose();
                    _tasksToDoView = null;
                }

                if (_tasksInProgressHeader != null)
                {
                    _tasksInProgressHeader.Dispose();
                    _tasksInProgressHeader = null;
                }
                if (_tasksInReviewHeader != null)
                {
                    _tasksInReviewHeader.Dispose();
                    _tasksInReviewHeader = null;
                }
                if (_tasksForReviewHeader != null)
                {
                    _tasksForReviewHeader.Dispose();
                    _tasksForReviewHeader = null;
                }
                if (_tasksToDoHeader != null)
                {
                    _tasksToDoHeader.Dispose();
                    _tasksToDoHeader = null;
                }
                if (_tasksInProgress != null)
                {
                    _tasksInProgress.Dispose();
                    _tasksInProgress = null;
                }
                if (_tasksInReview != null)
                {
                    _tasksInReview.Dispose();
                    _tasksInReview = null;
                }
                if (_tasksForReview != null)
                {
                    _tasksForReview.Dispose();
                    _tasksForReview = null;
                }
                if (_tasksToDo != null)
                {
                    _tasksToDo.Dispose();
                    _tasksToDo = null;
                }
                if (_topDivider != null)
                {
                    _topDivider.Dispose();
                    _topDivider = null;
                }
                if (_middleDivider != null)
                {
                    _middleDivider.Dispose();
                    _middleDivider = null;
                }
                if (_bottomDivider != null)
                {
                    _bottomDivider.Dispose();
                    _bottomDivider = null;
                }
                if (_percentPrepView != null)
                {
                    _percentPrepView.Dispose();
                    _percentPrepView = null;
                }
                if (_percentWorkView != null)
                {
                    _percentWorkView.Dispose();
                    _percentWorkView = null;
                }
                if (_percentDeliveryView != null)
                {
                    _percentDeliveryView.Dispose();
                    _percentDeliveryView = null;
                }
                if (_percentPrepHeader != null)
                {
                    _percentPrepHeader.Dispose();
                    _percentPrepHeader = null;
                }
                if (_percentWorkHeader != null)
                {
                    _percentWorkHeader.Dispose();
                    _percentWorkHeader = null;
                }
                if (_percentDeliveryHeader != null)
                {
                    _percentDeliveryHeader.Dispose();
                    _percentDeliveryHeader = null;
                }
                if (_percentPrepRadialView != null)
                {
                    _percentPrepRadialView.Dispose();
                    _percentPrepRadialView = null;
                }                
                if (_percentWorkRadialView != null)
                {
                    _percentWorkRadialView.Dispose();
                    _percentWorkRadialView = null;
                }
                if (_percentDeliveryRadialView != null)
                {
                    _percentDeliveryRadialView.Dispose();
                    _percentDeliveryRadialView = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}
