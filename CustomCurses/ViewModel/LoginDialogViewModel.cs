﻿using System.Threading.Tasks;
using System.Windows.Controls;
using CustomCursesLibrary.Helpers;
using CustomCursesLibrary.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CustomCurses.ViewModel
{
    class LoginDialogViewModel : ViewModelBase
    {
        private bool _closeTrigger;
        public bool CloseTrigger
        {
            get => _closeTrigger;
            set
            {
                _closeTrigger = value;
                RaisePropertyChanged(nameof(CloseTrigger));
            }
        }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                RaisePropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }

        private User _authorisedUser;
        public User AuthorisedUser
        {
            get => _authorisedUser;
            set
            {
                _authorisedUser = value;
                RaisePropertyChanged(nameof(AuthorisedUser));
            }
        }

        public RelayCommand<object> LoginCommand { get; }
        public RelayCommand CancelCommand { get; }

        public LoginDialogViewModel()
        {
            LoginCommand = new RelayCommand<object>(LoginCommandExecute);
            CancelCommand = new RelayCommand(CancelCommandExecute);
        }

        private void LoginCommandExecute(object password)
        {
            if (password is PasswordBox passwordBox) _password = passwordBox.Password;
            if (string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Username)) return;
            var result = Task.Run(async () => await DbRequests.GetUserByUserName(Username)).Result;
            var user = JsonSerialization<User>.GetModel(result);
            if (user == null ||
                !PasswordHashHelpers.VerifyPasswordHash(Password, user.PasswordHash, user.PasswordSalt)) return;
            AuthorisedUser = user;
            CloseTrigger = true;
        }

        private void CancelCommandExecute()
        {
            CloseTrigger = true;
        }
    }
}
