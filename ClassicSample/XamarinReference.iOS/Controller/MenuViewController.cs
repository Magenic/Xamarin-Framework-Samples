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
    public partial class MenuViewController :  BaseTableViewController 
    {
        private const string CellReuse = "SideMenuCell";

        private readonly float menuWidth;

        private IList<NavigationMenuItem<UIViewController>> _menuItems;

        public IList<NavigationMenuItem<UIViewController>> MenuItems => _menuItems; 

        public MenuViewController(float width) : base()
        {
            menuWidth = width;
            var _navMenuService = Mvx.Resolve<INavigationMenuService<UIViewController>>();
            _menuItems = _navMenuService.GetMenuItemsEnabled();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            //UIApplication.SharedApplication.SetStatusBarHidden(true, false);
            UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;
        }

        public override void WillDisplay(UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
        {
            cell.PreservesSuperviewLayoutMargins = false;
            cell.LayoutMargins = UIEdgeInsets.Zero;
            cell.SeparatorInset = UIEdgeInsets.Zero;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
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
            return _menuItems.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default, CellReuse);
            cell.SelectionStyle = UITableViewCellSelectionStyle.None;
            cell.BackgroundColor = Helper.Theme.Color.C2;
            cell.TextLabel.TextColor = Helper.Theme.Color.C1;
            cell.TextLabel.Font = Helper.Theme.Font.F3(Helper.Theme.Font.H4);
            cell.TextLabel.Text = _menuItems[indexPath.Row].Title;
            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {

            NavMenuController.PopToRootViewController(false);
            NavMenuController.PushViewController(_menuItems[indexPath.Row].Manager, false);     
            SidebarMenuController.CloseMenu();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        private void CreateMenuTableView()
        {
            //this.TableView = new UITableView(new CGRect(0, 60, menuWidth, View.Bounds.Height));

            //setup menu colors
            this.TableView.BackgroundColor = Helper.Theme.Color.C2;
            this.TableView.SeparatorColor = Helper.Theme.Color.C3;

        }

    }
}