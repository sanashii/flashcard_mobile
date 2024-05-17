using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using flashcard_mobile.Models;
using flashcard_mobile.Services;

namespace flashcard_mobile.ViewModels
{
    public class LoginPageViewModel : BindableObject
    {
        private string? email;
        private string? password;

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public ICommand NavigateToRegisterCommand { get; }
        public ICommand LoginCommand { get; }

        public LoginPageViewModel()
        {
            NavigateToRegisterCommand = new Command(async () => await Shell.Current.GoToAsync("//register"));
            LoginCommand = new Command(async () => await Login(Email, Password));
        }

        private bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public async Task Login(string email, string password)
        {
            var user = await App.DataService.GetUserAsync(email);
            if (user != null && user.Password == password)
            {
                // Handle successful login
                // Navigate to the home page
                await Shell.Current.GoToAsync("//home");
            }
            else
            {
                // Handle failed login
                // Display an error message
            }
        }
    }
}