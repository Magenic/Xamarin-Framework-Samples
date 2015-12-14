using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SidebarNavigation;
using UIKit;

namespace XamarinReference.iOS.Controller
{
    public class HomeViewController: UIViewController
    {
        private const int _menuWidth = 270;

        public SidebarController SidebarController { get; private set; } 
        public NavController NavController { get; private set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavController = new NavController();

            //set the default view
            NavController.PushViewController(new BlankViewController(), false);
            NavController.PushViewController(new AboutController(), false);

            //load the side bar controller to create the hamburger menu
            SidebarController = new SidebarController(this, NavController, new MenuViewController(_menuWidth));
            SidebarController.MenuWidth = _menuWidth;
            SidebarController.MenuLocation = MenuLocations.Left;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            //this.NavigationController.NavigationBarHidden = true;
            //this.NavigationController.NavigationBar.Translucent = true;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (SidebarController != null)
            {
                SidebarController.RemoveFromParentViewController();
                SidebarController.Dispose();
                SidebarController = null;
            }

            if (NavController != null)
            {
                NavController.RemoveFromParentViewController();
                NavController.Dispose();
                NavController = null;
            }
          
        }
    }
}
