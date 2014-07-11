using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChitChat.Client.View.Hubs;
using Microsoft.AspNet.SignalR.Client;

namespace ChitChat.Client.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IHubProxy PostHub;

        public MainWindow()
        {
            InitializeComponent();

            HubManager.Connecting += () =>
            {
                MessageBox.Show("Connecting...");
            };
            HubManager.Connected += () =>
            {
                MessageBox.Show("Connected!");
            };

            PostHub = HubManager.Get("PostHub");

            PostHub.On("NewPostNotification", () =>
            {
                MessageBox.Show("New Post!");
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() => HubManager.Connect());
        }
    }
}
