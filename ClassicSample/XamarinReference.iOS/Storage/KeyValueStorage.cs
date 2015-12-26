using System;
using System.Collections.Generic;
using System.Text;

using Foundation;
using UIKit;

using Newtonsoft.Json;

using XamarinReference.Lib.Interface;

namespace XamarinReference.iOS.Storage
{
    public class KeyValueStorage : IKeyValueStorage
    {
        public T GetValue<T>(string key, T defaultValue)
        {
            var val = NSUserDefaults.StandardUserDefaults.StringForKey((NSString)key);

            if (val == null)
            {
                return defaultValue;
            }

            else
            {
                return JsonConvert.DeserializeObject<T>(val);
            }
        }


        public void SetValue(string key, object value)
        {
            var json = JsonConvert.SerializeObject(value);

            NSUserDefaults.StandardUserDefaults.SetValueForKey((NSString)json, (NSString)key);
        }
    }
}
