using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

using XamarinReference.Lib.Model;
using XamarinReference.iOS.Helper;

namespace XamarinReference.iOS.Controls.View
{
    public class BusinessCardView : UIView
    {
        //data for the view 
        private Job _job;

        //private controls in the view
        private UILabel _jobName;
        private UILabel _companyName;
        private UILabel _officeLocation;

        public BusinessCardView(Job job)
        {
            _job = job;
            SetupUi();
            SetupBinding();
        }

        public void Update(Job job)
        {
            _job = job;
            SetNeedsDisplay();
        }

        private void SetupUi()
        {

            //background color of the view
            this.BackgroundColor = Helper.Theme.Color.C1;

            //setup header labels
            _jobName = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Font = Helper.Theme.Font.F1(Helper.Theme.Font.H4),
                TextColor = Helper.Theme.Color.C13,
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 0
            };
            this.InsertSubview(_jobName, 0);
            //setup _jobName layout in parent view
            AutoLayoutHelper.AttachToParentTop(this, _jobName, 5);
            AutoLayoutHelper.AttachToParentHorizontally(this, _jobName, 5);

            _companyName = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Font = Helper.Theme.Font.F1(Helper.Theme.Font.H4),
                TextColor = Helper.Theme.Color.C13,
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 0
            };
            this.InsertSubview(_companyName, 0);
            //setup _companyName layout in parent below _jobName 
            AutoLayoutHelper.FollowControlVertically(this, _jobName, _companyName, 2);
            AutoLayoutHelper.AttachToParentHorizontally(this, _companyName, 5);

            _officeLocation = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Font = Helper.Theme.Font.F1(Helper.Theme.Font.H4),
                TextColor = Helper.Theme.Color.C13,
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 0
            };
            this.InsertSubview(_officeLocation, 0);
            //setup _officeLocation layout in parent below _jobName 
            AutoLayoutHelper.FollowControlVertically(this, _companyName, _officeLocation, 2);
            AutoLayoutHelper.AttachToParentHorizontally(this, _officeLocation, 5);
            AutoLayoutHelper.AttachToParentBottom(this, _officeLocation, 2);
        }

        private void SetupBinding()
        {
            _jobName.Text = _job.JobName;
            _companyName.Text = _job.CompanyName;
            _officeLocation.Text = _job.CompanyName; 
        }

    }
}
