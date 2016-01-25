using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinReference.Lib.Interface
{
    /// <summary>
    /// IApplicationSettings inteface, use to store aplication setting
    /// </summary>
    public interface IKeyValueStorage
    {
        /// <summary>
        /// retrieves the object stored against the key passed in
        /// </summary>
        /// <typeparam name="T">type of the object to be retrieved</typeparam>
        /// <param name="key">unique key of the object to be retrieved</param>
        /// <returns>object stored against the key</returns>
        T GetValue<T>(string key, T defaultValue);

        void SetValue(string key, object value);
    }
}
