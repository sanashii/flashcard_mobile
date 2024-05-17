using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;

namespace flashcard_mobile.Views
{
    public partial class AccountPopup : Popup
    {
        public AccountPopup()
        {
            InitializeComponent();
        }

        /* private async void OnEditAccountClicked(object sender, EventArgs e)
        {
            Close();
            await Shell.Current.GoToAsync("//editaccount");
        } */

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            Close();
            bool confirm = await Application.Current.MainPage.DisplayAlert("Confirm Logout", "Are you sure you want to logout?", "Yes", "No");
            if (confirm)
            {
                App.CurrentUserEmail = null;
                await Shell.Current.GoToAsync("//login");
            }
        }
    }
}