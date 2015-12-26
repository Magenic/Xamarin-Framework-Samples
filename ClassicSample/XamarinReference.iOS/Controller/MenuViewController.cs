using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UIKit;
using CoreGraphics;
using Foundation;

using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;

using XamarinReference.iOS.Services;
using XamarinReference.Lib.Interface;
using XamarinReference.Lib.Model;

namespace XamarinReference.iOS.Controller
{
    /// <summary>
    /// MenuViewController - used to display side menu content
    /// </summary>
    public partial class MenuViewController :  BaseTableViewController 
    {
        private const string CellReuse = "SideMenuCell";

        private readonly float menuWidth;

        private IList<NavigationMenuItem<UIViewController>> _menuItems;

        public IList<NavigationMenuItem<UIViewController>> MenuItems => _menuItems; 

        public MenuViewController(float width) : base()
        {
            menuWidth = width;

            //get a list of menu items to display
            var _navMenuService = Mvx.Resolve<INavigationMenuService<UIViewController>>();
            _menuItems = _navMenuService.GetMenuItemsEnabled();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;
        }

        public override void WillDisplay(UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
        {
            //used to make sure cells seperate will fill entire cell
            //works in iOS > 7.0 
            cell.PreservesSuperviewLayoutMargins = false;
            cell.LayoutMargins = UIEdgeInsets.Zero;
            cell.SeparatorInset = UIEdgeInsets.Zero;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //change the view background to black in order to match the table
            //just in case, probably not needed
            this.View.BackgroundColor = Helper.Theme.Color.C2;

            //create menu tableView
            CreateMenuTableView();
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            //hard code number of sections to 1
            return 1;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            //return total amount of items to display in the menu
            return _menuItems.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            //used to draw the cell

            //use cell reuse to save on memory and better for performance
            var cell = tableView.DequeueReusableCell(CellReuse, indexPath);
            cell.SelectionStyle = UITableViewCellSelectionStyle.None;
            //set the color, font, and text
            cell.BackgroundColor = Helper.Theme.Color.C2;
            cell.TextLabel.TextColor = Helper.Theme.Color.C1;
            cell.TextLabel.Font = Helper.Theme.Font.F3(Helper.Theme.Font.H4);
            cell.TextLabel.Text = _menuItems[indexPath.Row].Title;
            //return the cell to draw
            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //clear the nav controller's current stack to the root which is blank
            NavMenuController.PopToRootViewController(false);
            //switch the view in the navigation control to the view that was selected
            NavMenuController.PushViewController(_menuItems[indexPath.Row].Manager, false);     
            SidebarMenuController.CloseMenu();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        private void CreateMenuTableView()
        {
            //setup menu colors
            this.TableView.BackgroundColor = Helper.Theme.Color.C2;
            this.TableView.SeparatorColor = Helper.Theme.Color.C3;
            //setup cell reuse
            this.TableView.RegisterClassForCellReuse(typeof(UITableViewCell), CellReuse);
        }

    }
}