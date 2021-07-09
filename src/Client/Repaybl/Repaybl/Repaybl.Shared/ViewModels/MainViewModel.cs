using System;
using System.Threading.Tasks;
using System.Windows.Input;

using BasicMvvm;
using BasicMvvm.Commands;

using Repaybl.Helpers;
using Repaybl.Swag;

using Windows.UI.Xaml.Controls;

namespace Repaybl.ViewModels
{
    public class MainViewModel : BindableBase
    {
        IUserClient _client;
        public Frame _contentFrame;
        public ICommand RegisterCommand => new AsyncCommand(OnRegisterCommandExecuteAsync);
        public ICommand LoginCommand => new AsyncCommand(OnLoginCommandExecuteAsync);
        public MainViewModel(IUserClient client)
        {
            _client = client;
            RegisterUser = new User() { Id = Guid.NewGuid() };
            LoginUser = new LoginRequest();

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
            try
            {
                if (LoginUser != null && !string.IsNullOrEmpty(LoginUser.UserName) && !string.IsNullOrEmpty(LoginUser.Password))
                {
                    var token = await _client.LoginAsync(LoginUser);
                    if (token != null)
                    {
                        LocalSettingHelper.MarkContainer("token", token);
                        BaseClient.SetBearerToken(token);
                        _contentFrame.Navigate(typeof(HomePage));
                    }
                }
            }
            catch (Exception ex)
            {

            }
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
