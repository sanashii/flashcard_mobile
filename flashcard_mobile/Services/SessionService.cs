using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flashcard_mobile.Models;

namespace flashcard_mobile.Services
{
    public class SessionService : INotifyPropertyChanged
    {
        public event EventHandler<UserLoggedInEventArgs> UserLoggedIn;
        public event EventHandler UserLoggedOut;

        public event PropertyChangedEventHandler? PropertyChanged;

        private User _currentUser;

        public SessionService()
        {
            _currentUser = null;
        }

        public User CurrentUser
        {
            get => _currentUser;
            private set
            {
                _currentUser = value;
                if (_currentUser != null)
                {
                    OnUserLoggedIn(_currentUser);
                }
                else
                {
                    OnUserLoggedOut();
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentUser)));
            }
        }

        public bool IsLoggedIn => CurrentUser != null;

        public void Login(User user)
        {
            CurrentUser = user;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        protected virtual void OnUserLoggedIn(User user)
        {
            UserLoggedIn?.Invoke(this, new UserLoggedInEventArgs(user));
        }

        protected virtual void OnUserLoggedOut()
        {
            UserLoggedOut?.Invoke(this, EventArgs.Empty);
        }
    }


    public class UserLoggedInEventArgs : EventArgs
    {
        public UserLoggedInEventArgs(User user)
        {
            User = user;
        }

        public User User { get; }
    }
}
