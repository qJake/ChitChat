using System.Configuration;

namespace ChitChat.Client.View.Configuration
{
    public class AppSettings : ConfigurationSection
    {
        [ConfigurationProperty("connectionUrl", IsRequired = true)]
        public string ConnectionUrl
        {
            get { return this["connectionUrl"].ToString(); }
            set { this["connectionUrl"] = value; }
        }
    }
}
