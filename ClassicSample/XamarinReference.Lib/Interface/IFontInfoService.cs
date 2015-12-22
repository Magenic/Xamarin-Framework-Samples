using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinReference.Lib.Model;

namespace XamarinReference.Lib.Interface
{
    public interface IFontInfoService
    {
        List<FontInfo> GetAvailableFonts();
    }
}
