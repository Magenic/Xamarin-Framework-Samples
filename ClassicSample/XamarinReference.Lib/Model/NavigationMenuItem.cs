using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinReference.Lib.Model
{
    public class NavigationMenuItem<T>
    {
        /// <summary>
        /// IsSelected - used to find if the menu item is selected 
        /// </summary>
        public bool IsSelected { get; set; }
        /// <summary>
        /// Title - string value of the title to display in the menu
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// IsEnabled - bool value used to check to show in the menu or not
        /// </summary>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// Manager - used to load up whom to call when this item is selected from the menu 
        /// </summary>
        public T Manager { get; set; }
    }
}
