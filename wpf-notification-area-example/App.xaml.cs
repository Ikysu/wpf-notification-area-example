using System.ComponentModel;
using System.Windows;

namespace wpf_notification_area_example
{
    public partial class App : Application
    {
        private System.Windows.Forms.NotifyIcon _notifyIcon;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = new MainWindow();

            MainWindow.Left = SystemParameters.PrimaryScreenWidth - MainWindow.Width;
            MainWindow.Top = SystemParameters.FullPrimaryScreenHeight + SystemParameters.WindowCaptionHeight - MainWindow.Height;

            MainWindow.ShowInTaskbar = false;
            MainWindow.Topmost = true;

            _notifyIcon = new System.Windows.Forms.NotifyIcon();
            _notifyIcon.Icon = wpf_notification_area_example.Properties.Resources.l2;
            _notifyIcon.Visible = true;

            _notifyIcon.MouseDoubleClick += (s, args) => ShowMainWindow();

            _notifyIcon.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("Exit").Click += (s, er) => ExitApplication();
        }

        private void ExitApplication()
        {
            MainWindow.Close();
            _notifyIcon.Dispose();
            _notifyIcon = null;
        }

        private void ShowMainWindow()
        {
            if (MainWindow.IsVisible)
            {
                MainWindow.Hide();
            }
            else
            {
                MainWindow.Show();
            }
        }
    }
}
