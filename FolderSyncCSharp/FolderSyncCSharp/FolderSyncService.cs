﻿using System.ServiceProcess;

namespace Folder_Synchronization
{
    public partial class FolderSync : ServiceBase
    {
        private Configuration configuration;
        private FolderNotification folderNotification;
        private WindowsEventLog windowsEventLog;

        public FolderSync()
        {
            InitializeComponent();

            windowsEventLog = new WindowsEventLog("Application");
            configuration = new Configuration(windowsEventLog);

            fileSystemWatcher.Path = configuration.SourcePath;

            folderNotification = new FolderNotification(new PathActions(configuration), new FileActions(configuration));

            fileSystemWatcher.Changed += folderNotification.handleChanged;
            fileSystemWatcher.Created += folderNotification.handleCreated;
            fileSystemWatcher.Deleted += folderNotification.handleDeleted;
            fileSystemWatcher.Renamed += folderNotification.handleRenamed;
        }

        protected override void OnStart(string[] args)
        {
            if (fileSystemWatcher.Path != "")
            {
                fileSystemWatcher.EnableRaisingEvents = true;
                windowsEventLog.LogToInfo("Started monitoring path " + fileSystemWatcher.Path);
            }
        }

        protected override void OnStop()
        {
            fileSystemWatcher.EnableRaisingEvents = false;
            windowsEventLog.LogToInfo("Stopped monitoring path " + fileSystemWatcher.Path);
        }
    }
}