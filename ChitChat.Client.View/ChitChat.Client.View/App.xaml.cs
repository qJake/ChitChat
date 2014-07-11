using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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

        public App()
        {
            Settings = (AppSettings)ConfigurationManager.GetSection("settings");

            HubManager.Initialize(Settings.ConnectionUrl);

            Startup += (_, __) =>
            {

            };
        }
    }
}
