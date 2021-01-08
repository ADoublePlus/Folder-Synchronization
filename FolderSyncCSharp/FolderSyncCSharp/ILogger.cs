using System;

namespace Folder_Synchronization
{
    public interface ILogger
    {
        void LogToInfo(String message);
        void LogToWarning(String message);
        void LogToError(String message);
    }
}