using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinReference.Lib.Helper
{
    public sealed class Memory
    {


        private Memory() { }

        /// <summary>
        /// Disposes the garbage.
        /// </summary>
        /// <param name="trash">Variable params that needs to be disposed.</param>
        public static void DisposeGarbage(params IDisposable[] trash)
        {
            if (trash != null)           //StaticCode_CA1062
                for (int i = 0; i < trash.Length; i++)
                {

                    IDisposable garbage = trash[i];

                    if (garbage != null)
                    {
                        garbage.Dispose();
                    }
                    //STATCODE_CA1804 
                }
        }
    }
}
