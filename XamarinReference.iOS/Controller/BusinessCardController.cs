using System;
using System.Collections.Generic;
using System.Text;

using Foundation;
using UIKit;

using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;

using XamarinReference.Lib.Interface;
using XamarinReference.Lib.Model;
using XamarinReference.iOS.Controls.Cell;

namespace XamarinReference.iOS.Controller
{
    public class BusinessCardController : BaseTableViewController
    {

        private readonly IJobsService _jobServices = Mvx.Resolve<IJobsService>();
        private IList<Job> _jobs;

        private static readonly NSString CellResuse = new NSString("BusinessCardCell");
        public BusinessCardController()
        {
            _jobs = _jobServices.Jobs;

            //setup cell reuse for performance - only works in iOS > 6 
            this.TableView.RegisterClassForCellReuse(typeof(BusinessCardCell), CellResuse);
        }

        public override void ViewDidLoad()
        {
            //call parent method
            base.ViewDidLoad();

            //set the title of the view from localization file
            this.Title = _localizeLookupService.GetLocalizedString("BusinessCardTitle");

            //used to setup the TableView
            SetupTableView();
        }

        /// <summary>
        /// RowsInSection - used to determine how many rows to draw in the TableView
        /// </summary>
        /// <param name="tableView"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _jobs.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            //data we will display in the view
            var job = _jobs[indexPath.Row];

            //get a cell to use to display
            var cell = (BusinessCardCell)tableView.DequeueReusableCell(CellResuse, indexPath);
            cell.UpdateCell(job);
            //return cell
            return cell;
        }

        private void SetupTableView()
        {
            //set the background color to match the cell color for making the floating cell by having the cell's view color be white
            this.TableView.BackgroundColor = Helper.Theme.Color.C19;

            //remove the ability to select
            this.TableView.AllowsSelection = false;

            //change the seperator style to none because we will handle the look via the cell, cell border, and background of the table
            this.TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;

            //set the tableview row height to automatic for dynamic cell height
            //only supported in iOS > 8.0 
            this.TableView.RowHeight = UITableView.AutomaticDimension;

            //set the estimated height to help with performance
            //if cells are going to be differne than this then you need
            //to override EstimatedHeight method to provide better calculation 
            //based on your data
            this.TableView.EstimatedRowHeight = 80.0f;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (CellResuse != null)
                {
                    CellResuse.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
