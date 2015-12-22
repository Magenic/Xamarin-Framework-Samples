using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;

using XamarinReference.Lib.Interface;
using XamarinReference.Lib.Model;

namespace XamarinReference.iOS.Controller
{
    public class FontController : BaseTableViewController
    {

        //used to get the fonts loaded in by the application
        private readonly IFontInfoService _fontInfoService = Mvx.Resolve<IFontInfoService>();
        //used for memory management by reusing cells 
        private const string CellResuse = "FontNameCell";

        //data collection for displaying information
        private List<FontInfo> _fontInfoList;

        //used for indexing section letters
        private List<string> _indexTitles;

        public FontController()
        {
            _fontInfoList = _fontInfoService.GetAvailableFonts();
            CalculateIndexTitles();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.Title = "Fonts";
            SetupTableView();
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return _fontInfoList.Count;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _fontInfoList[(int) section].FontNames.Count;
        }

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return _fontInfoList[(int)section].Family;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default, CellResuse);
            cell.TextLabel.Text = _fontInfoList[indexPath.Section].FontNames[indexPath.Row];
            return cell;
        }

        public override string[] SectionIndexTitles(UITableView tableView)
        {
            return _indexTitles.ToArray();
        }

        public override nint SectionFor(UITableView tableView, string title, nint atIndex)
        {
            return _fontInfoList.FindIndex(x => x.Family.StartsWith(title));
        }

        /// <summary>
        ///  CalculateIndexTitles - used to create the colleciotn of index letters to show on the right side of the table
        /// </summary>
        private void CalculateIndexTitles()
        {
            _indexTitles = new List<string>();
            foreach (var family in _fontInfoList)
            {
                var firstLetter = family.Family[0].ToString();
                if (!_indexTitles.Contains(firstLetter))
                {
                    _indexTitles.Add(firstLetter);    
                }
            }
        }

        /// <summary>
        /// SetupTableview - used to setup defaults for the UITableView that will be displayed
        /// you need to create a new one in order to switch the table style to grouped - otherwise
        /// you can use the built in tableView without creating a new one
        /// </summary>
        private void SetupTableView()
        {
            this.TableView = new UITableView(View.Bounds, UITableViewStyle.Grouped)
            {
                SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine,
                AutoresizingMask = UIViewAutoresizing.All,
                RowHeight = UITableView.AutomaticDimension
            };

            //used to make the background of the index letters clear or transparent
            this.TableView.SectionIndexBackgroundColor = UIColor.Clear;

            //used for memory management and reusing cells - only iOS 6+
            TableView.RegisterClassForCellReuse(typeof(UITableViewCell), CellResuse);    
        }

    }
}
