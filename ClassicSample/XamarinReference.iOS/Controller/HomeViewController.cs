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

        public SidebarController SidebarMenuController { get; private set; } 
        public NavController NavMenuController { get; private set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.NavMenuController = new NavController();

            //set the default view
            this.NavMenuController.PushViewController(new BlankViewController(), false);
            this.NavMenuController.PushViewController(new AboutController(), false);

            //load the side bar controller to create the hamburger menu
            this.SidebarMenuController = new SidebarController(this, NavMenuController, new MenuViewController(_menuWidth));
            this.SidebarMenuController.MenuWidth = _menuWidth;
            this.SidebarMenuController.MenuLocation = MenuLocations.Left;
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
    }
}
