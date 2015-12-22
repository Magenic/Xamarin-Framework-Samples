using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinReference.iOS.Controller
{
    public class BlankViewController:BaseController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.View.BackgroundColor = Helper.Theme.Color.C1;
        }
    }
}
