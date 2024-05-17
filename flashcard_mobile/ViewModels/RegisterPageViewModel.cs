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
            RegisterCommand = new Command(
                execute: async () => await ExecuteRegisterCommand(),
                canExecute: () => ValidateRegistration()
            );

            PropertyChanged += (_, args) =>
            {
                if (args.PropertyName == nameof(Name) || args.PropertyName == nameof(Email) || args.PropertyName == nameof(Password))
                {
                    ((Command)RegisterCommand).ChangeCanExecute();
                }
            };
        }

        private bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        private bool ValidateRegistration()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   IsValidEmail(Email) &&
                   !string.IsNullOrWhiteSpace(Password);
        }

        private async Task ExecuteRegisterCommand()
        {
            if (!ValidateRegistration())
            {
                if (!IsValidEmail(Email))
                {
                    await Shell.Current.DisplayAlert("Invalid Email", "Please enter a valid email address.", "OK");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Registration Incomplete", "Please fill in all fields to register.", "OK");
                }
                return;
            }

            IsBusy = true;
            var newUser = new User
            {
                Name = this.Name,
                Email = this.Email,
                Password = this.Password
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