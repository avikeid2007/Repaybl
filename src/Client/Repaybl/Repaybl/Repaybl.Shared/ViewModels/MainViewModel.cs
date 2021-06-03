using System;
using System.Threading.Tasks;
using System.Windows.Input;

using BasicMvvm;
using BasicMvvm.Commands;

using Repaybl.Swag;

namespace Repaybl.ViewModels
{
    public class MainViewModel : BindableBase
    {
        IUserClient _client;
        public ICommand RegisterCommand => new AsyncCommand(OnRegisterCommandExecuteAsync);
        public ICommand LoginCommand => new AsyncCommand(OnLoginCommandExecuteAsync);
        public MainViewModel(IUserClient client)
        {
            _client = client;
            RegisterUser = new User() { Id = Guid.NewGuid() };
        }
        private User _registerUser;
        public User RegisterUser
        {
            get { return _registerUser; }
            set
            {
                _registerUser = value;
                OnPropertyChanged();
            }
        }
        private LoginRequest _loginUser;

        public LoginRequest LoginUser
        {
            get { return _loginUser; }
            set
            {
                _loginUser = value;
                OnPropertyChanged();
            }
        }

        private async Task OnLoginCommandExecuteAsync()
        {
            //if()
        }
        private async Task OnRegisterCommandExecuteAsync()
        {
            if (RegisterUser != null && !string.IsNullOrEmpty(RegisterUser.Email))
            {
                await _client.RegisterAsync(RegisterUser);
            }
        }

    }
}
