using CommunityToolkit.Maui.Views;

namespace flashcard_mobile.Views
{
    public partial class EmailPopup : Popup
    {
        public string Email { get; set; }

        public EmailPopup(string email)
        {
            InitializeComponent();
            Email = email;
            BindingContext = this;
        }

        private void OnCloseButtonClicked(object sender, EventArgs e)
        {
            Close();
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            Close();
            bool confirm = await Application.Current.MainPage.DisplayAlert("Confirm Logout", "Are you sure you want to logout?", "Yes", "No");
            if (confirm)
            {
                App.SessionService.Logout();
                await Shell.Current.GoToAsync("//blank");
                await Shell.Current.GoToAsync("//home");
            }
        }
    }
}
