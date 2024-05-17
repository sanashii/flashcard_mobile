using Microsoft.Maui.Controls;

namespace flashcard_mobile.Views
{
    public partial class AccountPopupPage : ContentPage
    {
        public AccountPopupPage()
        {
            InitializeComponent();
        }

        /*private async void OnEditAccountClicked(object sender, EventArgs e)
        {
            // Navigate to Edit Account page
            await Shell.Current.GoToAsync("//editaccount");
        } adjust accordingly lng to whoever is in charge of this */

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            // Handle logout logic here
            bool confirm = await DisplayAlert("Confirm Logout", "Are you sure you want to logout?", "Yes", "No");
            if (confirm)
            {
                // Perform logout operation and navigate to login page
                App.CurrentUserEmail = null;
                await Shell.Current.GoToAsync("//login");
            }
        }
    }
}
