using System.ServiceProcess;

namespace Folder_Synchronization
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new FolderSync()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}