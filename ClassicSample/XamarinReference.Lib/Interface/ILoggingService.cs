using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinReference.Lib.Interface
{
    public interface ILoggingService
    {
        void WriteLine(Logging.MessageType messageType, string message);
    }
}
