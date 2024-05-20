using System.ComponentModel;
using System.Windows.Input;
using flashcard_mobile.Services;
using flashcard_mobile.Models;

namespace flashcard_mobile.ViewModels
{
    public class EditAccountViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _email;
        private string _password;
        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }
        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public ICommand SaveCommand { get; }

        public EditAccountViewModel()
        {
            SaveCommand = new Command(OnSave);
        }

        private void OnSave()
        {
            // Implement save logic here
            // Example: DataService.UpdateUser(new User { Username = Username, Email = Email, Password = Password });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
