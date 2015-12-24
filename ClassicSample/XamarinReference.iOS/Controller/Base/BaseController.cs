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

        protected SidebarNavigation.SidebarController SidebarMenuController
        {
            get
            {
                return (UIApplication.SharedApplication.Delegate as AppDelegate).HomeViewController.SidebarMenuController;
            }
        }

        // provide access to the sidebar controller to all inheriting controllers
        protected NavController NavMenuController
        {
            get
            {
                return (UIApplication.SharedApplication.Delegate as AppDelegate).HomeViewController.NavMenuController;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //Helper.NavigationBarHelper.SetupNavigationBar(SidebarMenuController, NavMenuController, NavigationItem, _menuButton);
            _menuButton = new UIBarButtonItem(UIImage.FromBundle("hamburger_menu_white.png")
                    , UIBarButtonItemStyle.Plain
                    , (sender, args) =>
                    {
                        SidebarMenuController.ToggleMenu();
                    });
            NavigationItem.SetLeftBarButtonItem(_menuButton, true);
            NavMenuController.NavigationBar.BackgroundColor = Helper.Theme.Color.C2;
            NavMenuController.NavigationBar.BarStyle = UIBarStyle.BlackOpaque;
            NavMenuController.NavigationBar.TintColor = Helper.Theme.Color.C1;
            NavMenuController.NavigationBar.BarTintColor = Helper.Theme.Color.C2;

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
