using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinReference.Lib.Interface
{
    public interface IFileHelper
    {        
        /// <summary>
        /// Delete file at path
        /// </summary>
        /// <param name="path">file path</param>
        void Delete(string path);

        /// <summary>
        /// GetFiles - get a listing of files in a given path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        IList<string> GetFiles(string path);

        /// <summary>
        /// Check if the file exists or not
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <returns>true or false based on file exists or not</returns>
        bool Exists(string filePath);

        string GetLocalStoragePath { get; }

   
    }
}
