using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using XamarinReference.Lib.Interface;
using XamarinReference.Lib.Model;

namespace XamarinReference.iOS.Services
{
    public class FontInfoService : IFontInfoService
    {
        public List<FontInfo> GetAvailableFonts()
        {
            var list = new List<FontInfo>();
            var familyNames = UIFont.FamilyNames;
            foreach (var familyName in familyNames)
            {
                var fontInfo = new FontInfo
                {
                    Family = familyName,
                    FontNames = new List<string>()
                };
                foreach (var fontName in UIFont.FontNamesForFamilyName(familyName))
                {
                    fontInfo.FontNames.Add(fontName);    
                }
                list.Add(fontInfo);
            }
            return list.OrderBy(x => x.Family).ToList();
        }
           
    }
}
