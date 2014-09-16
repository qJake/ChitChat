using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using ChitChat.Client.Model;
using ChitChat.Client.View.Hubs;
using ChitChat.Client.ViewModel;

namespace ChitChat.Client.View.Views
{
    /// <summary>
    /// Interaction logic for Notification.xaml
    /// </summary>
    public partial class Notification : Window
    {
        public NotificationViewModel ViewModel { get; set; }

        public int Timeout { get; set; }

        public Notification()
        {
            InitializeComponent();
            ViewModel = new NotificationViewModel();
            DataContext = ViewModel;

            MouseRightButtonUp += (s, e) =>
            {
                Close();
            };

            MouseLeftButtonDown += (s, e) =>
            {
                DragMove();
            };
        }

        private void Reposition()
        {
            Top = Screen.PrimaryScreen.WorkingArea.Height - ActualHeight;
            Left = Screen.PrimaryScreen.WorkingArea.Width - ActualWidth;
        }

        public new void Show()
        {
            base.Show();
            Reposition();

            Task.Run(() =>
            {
                Thread.Sleep(Timeout * 1000);
                Dispatcher.Invoke(Close);
            });
        }
    }
}
