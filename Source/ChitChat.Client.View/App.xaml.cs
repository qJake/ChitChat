using System.Configuration;
using System.Threading.Tasks;
using System.Windows;
using ChitChat.Client.View.Configuration;
using ChitChat.Client.View.Hubs;
using Microsoft.AspNet.SignalR.Client;

namespace ChitChat.Client.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static AppSettings Settings { get; private set; }
        public static NotificationArea NotificationArea { get; private set; }

        public App()
        {
            Settings = (AppSettings)ConfigurationManager.GetSection("settings");
            NotificationArea = new NotificationArea();

            while (string.IsNullOrWhiteSpace(Settings.ConnectionUrl))
            {
                var connectionDialog = new Connect();
                connectionDialog.ShowDialog();
                Settings.ConnectionUrl = connectionDialog.ViewModel.Server;
            }

            HubController.Initialize();
        }
    }
}
