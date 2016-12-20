using MvvmCross.Platform;

using System;

using XamarinReference.Lib.Interface;
using XamarinReference.Lib.Logging;

namespace XamarinReference.iOS
{
    public class FileLoggingService : ILoggingService, ILoggingFile
    {
        private readonly IFileHelper _fileHelper = Mvx.Resolve<IFileHelper>();
        private string _loggingPath;

        public string LoggingPath => _loggingPath;

        public FileLoggingService()
        {
            _loggingPath = string.Format(@"{0}/logfile.txt", _fileHelper.GetLocalStoragePath);
        }

        public void WriteLine(MessageType messageType, string message)
        {
            var text = string.Empty;

            switch (messageType)
            {
                case MessageType.Error:
                    text = string.Format("{0} ERROR:- {1}. {2}", DateTime.Now, message, System.Environment.NewLine);     
                    break;
                case MessageType.FailureAudit:
                    text = string.Format("{0} FAILURE AUDIT:- {1}. {2}", DateTime.Now, message, System.Environment.NewLine);     
                    break;
                case MessageType.Information:
                    text = string.Format("{0} INFORMATION:- {1}. {2}", DateTime.Now, message, System.Environment.NewLine);     
                    break;
                case MessageType.SuccessAudit:
                    text = string.Format("{0} SUCCESS AUDIT:- {1}. {2}", DateTime.Now, message, System.Environment.NewLine);     
                    break;
                case MessageType.Warning:
                    text = string.Format("{0} WARNING:- {1}. {2}", DateTime.Now, message, System.Environment.NewLine);     
                    break;
            }

            //write information to log file
            _fileHelper.AppendAllTextContent(_loggingPath, text);
        }

        public void DeleteLog()
        {
            _fileHelper.Delete(_loggingPath);
            this.WriteLine(MessageType.Information, string.Format("Logfile was deleted and recreated on {0}", DateTime.Now));
        }
    }
}
