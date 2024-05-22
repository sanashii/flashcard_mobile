namespace flashcard_mobile.Views;

public partial class AccountPage : ContentPage
{
	public AccountPage()
	{
		InitializeComponent();
	}

    private async void OnBackButtonTapped(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnEditButtonTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditAccountPage());
    }

    private async void OnLogoutButtonTapped(Object sender, EventArgs e)
    {
        bool confirmLogout = await DisplayAlert("Logout", "Are you sure you want to logout?", "Yes", "No");


        if (confirmLogout)
        {
            App.SessionService.Logout();
            await Navigation.PopToRootAsync();
        }
    }
}