using System;
using System.Collections.Generic;
using System.Text;

using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;

using UIKit;
using XamarinReference.Lib.Interface;

namespace XamarinReference.iOS.Controller
{
    public abstract class BaseController:UIViewController
    {
        protected readonly IStringLookupService _localizeLookupService = Mvx.Resolve<IStringLookupService>();
        private UIBarButtonItem _menuButton;

        protected SidebarNavigation.SidebarController SidebarController
        {
            get
            {
                return (UIApplication.SharedApplication.Delegate as AppDelegate).HomeViewController.SidebarController;
            }
        }

        // provide access to the sidebar controller to all inheriting controllers
        protected NavController NavController
        {
            get
            {
                return (UIApplication.SharedApplication.Delegate as AppDelegate).HomeViewController.NavController;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _menuButton = new UIBarButtonItem(UIImage.FromBundle("hamburger_menu_white.png")
                    , UIBarButtonItemStyle.Plain
                    , (sender, args) => {
                        SidebarController.ToggleMenu();
                    });
            //menuButton.TintColor = Helper.Theme.Color.C2;
            NavigationItem.SetLeftBarButtonItem(_menuButton, true);
            NavController.NavigationBar.BackgroundColor = Helper.Theme.Color.C2;
            NavController.NavigationBar.BarStyle = UIBarStyle.BlackOpaque;
            NavController.NavigationBar.TintColor = Helper.Theme.Color.C1;
            NavController.NavigationBar.BarTintColor = Helper.Theme.Color.C2;

            this.View.BackgroundColor = Helper.Theme.Color.C1;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (_menuButton != null)
                {
                    _menuButton.Dispose();
                    _menuButton = null;
                }
            }
        }

    }
}
