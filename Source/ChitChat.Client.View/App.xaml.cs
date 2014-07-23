using System.Configuration;
using System.Windows;
using ChitChat.Client.View.Configuration;
using ChitChat.Client.View.Hubs;

namespace ChitChat.Client.View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static AppSettings Settings { get; private set; }

        public static NotificationArea NotificationIcon { get; private set; }

        public App()
        {
            Settings = (AppSettings)ConfigurationManager.GetSection("settings");

            NotificationIcon = new NotificationArea();

            HubManager.Initialize(Settings.ConnectionUrl);
        }
    }
}
