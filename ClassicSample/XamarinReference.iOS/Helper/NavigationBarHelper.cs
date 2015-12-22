using System;
using System.Collections.Generic;
using System.Text;

using UIKit;
using Foundation;
using XamarinReference.iOS.Controller;

namespace XamarinReference.iOS.Helper
{
    public static class NavigationBarHelper
    {
        public static void SetupNavigationBar(SidebarNavigation.SidebarController sidebarController, NavController navController, UINavigationItem navItem, UIBarButtonItem menuButton)
        {
            menuButton = new UIBarButtonItem(UIImage.FromBundle("hamburger_menu_white.png")
                    , UIBarButtonItemStyle.Plain
                    , (sender, args) => {
                        sidebarController.ToggleMenu();
                    });
            //menuButton.TintColor = Helper.Theme.Color.C2;
            navItem.SetLeftBarButtonItem(menuButton, true);
            navController.NavigationBar.BackgroundColor = Helper.Theme.Color.C2;
            navController.NavigationBar.BarStyle = UIBarStyle.BlackOpaque;
            navController.NavigationBar.TintColor = Helper.Theme.Color.C1;
            navController.NavigationBar.BarTintColor = Helper.Theme.Color.C2;
        }
    }
}
