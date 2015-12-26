using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cirrious.CrossCore;
using SidebarNavigation;
using UIKit;

using XamarinReference.Lib.Interface;

namespace XamarinReference.iOS.Controller
{
    public class HomeViewController: UIViewController
    {
        //used to look up logging based on how the app has logging setup 
        protected readonly ILoggingService _logging = Mvx.Resolve<ILoggingService>();

        private const int _menuWidth = 270;

        public SidebarController SidebarMenuController { get; private set; } 
        public NavController NavMenuController { get; private set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            try
            {
                _logging.WriteLine(Lib.Logging.MessageType.Information, "Starting application in HomeViewController ViewDidLoad method");

                this.NavMenuController = new NavController();

                //set the default view
                this.NavMenuController.PushViewController(new BlankViewController(), false);
                this.NavMenuController.PushViewController(new AboutController(), false);

                //load the side bar controller to create the hamburger menu
                this.SidebarMenuController = new SidebarController(this, NavMenuController, new MenuViewController(_menuWidth));
                this.SidebarMenuController.MenuWidth = _menuWidth;
                this.SidebarMenuController.MenuLocation = MenuLocations.Left;
            }
            catch (Exception ex)
            {
                this.DealWithErrors(ex);
            }
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (SidebarMenuController != null)
            {
                SidebarMenuController.RemoveFromParentViewController();
                SidebarMenuController.Dispose();
                SidebarMenuController = null;
            }

            if (NavMenuController != null)
            {
                NavMenuController.RemoveFromParentViewController();
                NavMenuController.Dispose();
                NavMenuController = null;
            }
        }

        protected void DealWithErrors(Exception ex)
        {
            _logging.WriteLine(Lib.Logging.MessageType.Error, string.Format("Error Message: {0} .  Stack Trace: {1}", ex.Message, ex.StackTrace));
        }
    }
}
