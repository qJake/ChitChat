using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Windows;
using ChitChat.Client.Model;
using Microsoft.AspNet.SignalR.Client;

namespace ChitChat.Client.View.Hubs
{
    public static class HubController
    {
        public static IHubProxy PostHub { get; private set; }
        public static List<Category> CategoryCache { get; private set; }

        public static void Initialize()
        {
            HubManager.Initialize(App.Settings.ConnectionUrl);

            PostHub = HubManager.Get("PostHub");

            HubManager.Connected += () =>
            {
                PostHub.Invoke("RegisterClient");
                PostHub.Invoke("GetCategory");
            };

            RegisterPostHubEvents(PostHub);

            Task.Run(() => HubManager.Connect());
        }

        private static void RegisterPostHubEvents(IHubProxy hub)
        {
            hub.On("RegisterClientResponse", d =>
            {
                if (d.status == "fail")
                {
                    MessageBox.Show("Failed to connect.");
                }
            });

            hub.On<Post>("NewPostNotification", p =>
            {
                App.NotificationArea.ShowNotification(p);
            });

            hub.On<List<Category>>("GetCategoryResponse", c => CategoryCache = c);
        }
    }
}
