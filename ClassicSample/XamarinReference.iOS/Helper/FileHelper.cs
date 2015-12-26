using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XamarinReference.Lib.Interface;

namespace XamarinReference.iOS.Helper
{
    public class FileHelper : IFileHelper
    {
        /// <summary>
        /// Delete file at path
        /// </summary>
        /// <param name="path">file path</param>
        public void Delete(string path)
        {
            if (this.Exists(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// ReadAllTextContext - return a string of all the text in a given file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string ReadAllTextContent(string path)
        {
            return File.ReadAllText(path);
        }

        /// <summary>
        /// AppendAllTextContent - write all the text to a given file
        /// </summary>
        /// <param name="path">path to the text file to write to</param>
        /// <param name="text">text to append to the file</param>
        public void AppendAllTextContent(string path, string text)
        {
            File.AppendAllText(path, text);
        }

        /// <summary>
        /// GetFiles - get a listing of files in a given path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public IList<string> GetFiles(string path)
        {
            IList<string> files = new List<string>();
            if (System.IO.Directory.Exists(path))
            {
                foreach (var file in System.IO.Directory.GetFiles(path))
                {
                    files.Add(file);
                }
            }
            return files;
        }

        /// <summary>
        /// Check if the file exists or not
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <returns>true or false based on file exists or not</returns>
        public bool Exists(string filePath)
        {
            return File.Exists(filePath);
        }

        public string GetLocalStoragePath { get { return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); }
        }
    }
}
