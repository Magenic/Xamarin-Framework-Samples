using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinReference.Lib.Interface
{
    public interface IVersionInfo
    {
        DateTime ApplicationBuildTime { get; }

        string ApplicationVersion { get; }

        string OperatingSystemVersion { get; }
    }
}
