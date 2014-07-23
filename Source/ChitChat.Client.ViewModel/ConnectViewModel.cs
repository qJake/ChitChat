using System.Windows.Input;
using Molten.Core.Wpf;
using Molten.Core.Wpf.Commands;

namespace ChitChat.Client.ViewModel
{
    public class ConnectViewModel : BindableBase
    {
        private string _Server;
        public string Server
        {
            get { return _Server; }
            set { SetProperty(ref _Server, value); }
        }

        private bool? _DialogResult;
        public bool? DialogResult
        {
            get { return _DialogResult; }
            set { SetProperty(ref _DialogResult, value); }
        }

        public ICommand Connect { get; set; }

        public ConnectViewModel()
        {
            Connect = new ActionCommand(ExecuteConnect);
        }

        private void ExecuteConnect()
        {
            DialogResult = true;
        }
    }
}
