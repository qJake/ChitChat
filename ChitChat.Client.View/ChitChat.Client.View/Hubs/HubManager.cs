using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace ChitChat.Client.View.Hubs
{
    public class HubManager
    {
        public static event Action Connected;
        public static event Action Connecting;

        private static HubConnection Connection { get; set; }
        private static Dictionary<string, IHubProxy> Hubs { get; set; }

        public static ConnectionState State
        {
            get { return Connection.State; }
        }

        public static void Initialize(string url)
        {
            Initialize(url, CredentialCache.DefaultCredentials);
        }

        public static void Initialize(string url, ICredentials credentials)
        {
            Hubs = new Dictionary<string, IHubProxy>();

            ServicePointManager.DefaultConnectionLimit = 10;
            Connection = new HubConnection(url)
            {
                Credentials = credentials
            };

            Connection.StateChanged += s =>
            {
                switch (s.NewState)
                {
                    case ConnectionState.Connected:
                        if (Connected != null)
                        {
                            Connected();
                        }
                        break;
                    case ConnectionState.Connecting:
                        if (Connecting != null)
                        {
                            Connecting();
                        }
                        break;
                }
            };
        }

        public static IHubProxy Get(string hub)
        {
            if (Hubs.ContainsKey(hub))
            {
                return Hubs[hub];
            }

            return CreateHub(hub);
        }

        public static async Task Connect()
        {
            await Connection.Start();
        }

        private static IHubProxy CreateHub(string name)
        {
            if (State != ConnectionState.Disconnected)
            {
                throw new InvalidOperationException("Cannot create a hub instance while connected or connecting.");
            }

            var hub = Connection.CreateHubProxy(name);

            Hubs.Add(name, hub);

            return hub;
        }
    }
}
