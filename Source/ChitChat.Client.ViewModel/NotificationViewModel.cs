using Molten.Core.Wpf;

namespace ChitChat.Client.ViewModel
{
    public class NotificationViewModel : BindableBase
    {
        private string _Foreground;
        public string Foreground
        {
            get { return _Foreground; }
            set { SetProperty(ref _Foreground, value); }
        }

        private string _Background;
        public string Background
        {
            get { return _Background; }
            set { SetProperty(ref _Background, value); }
        }

        private string _Body;
        public string Body
        {
            get { return _Body; }
            set { SetProperty(ref _Body, value); }
        }

        private string _User;
        public string User
        {
            get { return _User; }
            set { SetProperty(ref _User, value); }
        }
    }
}
