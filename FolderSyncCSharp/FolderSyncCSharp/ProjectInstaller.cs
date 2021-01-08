using System.ComponentModel;
using System.Configuration.Install;

namespace Folder_Synchronization
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void serviceProcessInstaller_AfterInstall(object sender, InstallEventArgs e) { }
    }
}