using MvvmCross.Platform;

using System.Collections.Generic;

using XamarinReference.Lib.Interface;

namespace XamarinReference.iOS.Services
{
    public class MediaService : IMediaService
    {
        IFileHelper _fileHelper = Mvx.Resolve<IFileHelper>();
        public IList<string> GetFiles()
        {
            var path = string.Format(@"{0}/CameraExample", _fileHelper.GetLocalStoragePath);
            return _fileHelper.GetFiles(path);
        }
    }
}
