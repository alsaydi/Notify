using System.Windows;
using Hardcodet.Wpf.TaskbarNotification;

namespace Notify
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TaskbarIcon _taskbarIcon;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _taskbarIcon = FindResource("NotifyIcon") as TaskbarIcon;
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _taskbarIcon?.Dispose();
            base.OnExit(e);
        }

        
    }
}
