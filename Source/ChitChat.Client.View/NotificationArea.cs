using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Threading;
using ChitChat.Client.Model;
using ChitChat.Client.View.Hubs;
using ChitChat.Client.View.Views;
using Application = System.Windows.Application;

namespace ChitChat.Client.View
{
    public class NotificationArea
    {
        public NotifyIcon Icon { get; set; }

        public NotificationArea()
        {
            var item1 = new MenuItem
            {
                Text = "New Post"
            };
            item1.Click += (_, __) =>
            {
                HubController.PostHub.Invoke<Post>("CreatePost", new Post
                {
                    Body = "This was created on the fly!",
                    CatID = 1,
                    UserID = 1
                });
            };
            var item2 = new MenuItem
            {
                Text = "Exit"
            };
            item2.Click += (_, __) => Environment.Exit(0);

            var contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(item1);
            contextMenu.MenuItems.Add(item2);

            var iconStream = Application.GetResourceStream(new Uri("pack://application:,,,/ChitChat.Client;component/Resources/Application.ico")).Stream;

            Icon = new NotifyIcon
            {
                Icon = new Icon((Stream)iconStream),
                ContextMenu = contextMenu,
                Text = "ChitChat [Alpha]",
                Visible = true
            };
        }

        public void ShowNotification(Post post)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                var notificationWindow = new Notification
                {
                    ViewModel =
                    {
                        Foreground = post.Category.Foreground,
                        Background = post.Category.Background,
                        Body = post.Body,
                        User = post.User.FirstName + " " + post.User.LastName
                    },
                    Timeout = post.Category.Timeout
                };

                notificationWindow.Show();
            });
        }
    }
}
