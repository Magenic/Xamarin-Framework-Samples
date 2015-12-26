using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Newtonsoft.Json;

namespace XamarinReference.Droid.Storage
{
    public class KeyValueStorage
    {
        ISharedPreferences _SharedPreferences;

        public KeyValueStorage(Context applicationContext)
        {
            _SharedPreferences = applicationContext.GetSharedPreferences("SharedPreferences.json", FileCreationMode.Private);
        }

        public T GetValue<T>(string key, T defaultValue)
        {
            if (_SharedPreferences.Contains(key))
            {
                var json = _SharedPreferences.GetString(key, "");

                return JsonConvert.DeserializeObject<T>(json);
            }

            else
            {
                return defaultValue;
            }
        }

        public void SetValue(string key, object value)
        {
            var json = JsonConvert.SerializeObject(value);

            _SharedPreferences.All[key] = json;
        }
    }
}