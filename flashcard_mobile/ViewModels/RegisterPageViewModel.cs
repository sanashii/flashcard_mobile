using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using flashcard_mobile.Services;
using flashcard_mobile.Models;

namespace flashcard_mobile.ViewModels
{
    public class RegisterPageViewModel : BindableObject
    {
        private string _name = string.Empty;
        private string _email = string.Empty;
        private string _password = string.Empty;
        private bool _isBusy = false;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public ICommand NavigateToLoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public RegisterPageViewModel()
        {
            NavigateToLoginCommand = new Command(async () => await Shell.Current.GoToAsync("//login"));
            RegisterCommand = new Command(async () => await ExecuteRegisterCommand(), () => !IsBusy && ValidateRegistration());
        }

        private bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private bool ValidateRegistration()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(Email) &&
                   !string.IsNullOrWhiteSpace(Password);
        }

        private async Task ExecuteRegisterCommand()
        {
            if (!ValidateRegistration())
            {
                await Shell.Current.DisplayAlert("Registration Incomplete", "Please fill in all fields to register.", "OK");
                return;
            }

            IsBusy = true;
            var newUser = new User
            {
                Name = this.Name,
                Email = this.Email,
                Password = this.Password  // Reminder: Hash in production!
            };

            try
            {
                await App.DataService.AddUserAsync(newUser);
                await Shell.Current.DisplayAlert("Registration Success", "You have successfully registered.", "OK");
                await Shell.Current.GoToAsync("//login");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Registration Failed", $"Failed to register: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}