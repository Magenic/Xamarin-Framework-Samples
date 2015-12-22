using System;
using System.Collections.Generic;
using System.Text;

using UIKit;
using Foundation;
using CoreGraphics;

namespace XamarinReference.iOS.Helper.Theme
{
    public static class Font
    {
        /// <summary>
        /// returns 17px
        /// </summary>
        public static nfloat H1 => 17.0f;

        /// <summary>
        /// returns 16px
        /// </summary>
        public static nfloat H2 => 16.0f;

        /// <summary>
        /// returns 15px
        /// </summary>
        public static nfloat H3 => 15.0f;

        /// <summary>
        /// returns 14px
        /// </summary>
        public static nfloat H4 => 14.0f;

        /// <summary>
        /// returns 13px
        /// </summary>
        public static nfloat H5 => 13.0f;

        /// <summary>
        /// returns 12px
        /// </summary>
        public static nfloat H6 => 12.0f;

        /// <summary>
        /// returns 11px
        /// </summary>
        public static nfloat H7 => 11.0f;

        /// <summary>
        /// returns 10px
        /// </summary>
        public static nfloat H8 => 10.0f;

        /// <summary>
        /// F1 - returns Roboto Bold
        /// </summary>
        /// <param name="size">nfloat of header size</param>
        /// <returns></returns>
        public static UIFont F1(nfloat size)
        {
            return UIFont.FromName("Roboto-Bold", size);
        }

        /// <summary>
        /// F2 - returns Roboto Medium
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static UIFont F2(nfloat size)
        {
            return UIFont.FromName("Roboto-Medium", size);
        }

        /// <summary>
        /// F3 - returns Roboto Regular 
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static UIFont F3(nfloat size)
        {
            return UIFont.FromName("Roboto", size);
        }

        /// <summary>
        /// F4 - returns Roboto Light
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static UIFont F4(nfloat size)
        {
            return UIFont.FromName("Roboto-Light", size);
        }

        /// <summary>
        /// F5 - returns Roboto Thin 
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static UIFont F5(nfloat size)
        {
            return UIFont.FromName("Roboto-Thin", size);
        }

        /// <summary>
        /// F6 - returns Roboto Light
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static UIFont F6(nfloat size)
        {
            return UIFont.FromName("Roboto-Light", size);
        }
    }
}
