using System.Windows;
using ChitChat.Client.ViewModel;

namespace ChitChat.Client.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Connect : Window
    {
        public ConnectViewModel ViewModel { get; set; }

        public Connect()
        {
            InitializeComponent();
            ViewModel = new ConnectViewModel();
        }
    }
}
