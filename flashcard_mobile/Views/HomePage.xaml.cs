using CommunityToolkit.Maui.Views;
using flashcard_mobile.Models;
using flashcard_mobile.ViewModels;

namespace flashcard_mobile.Views
{
    public partial class HomePage : ContentPage
    {
        private AccountPopup _accountPopup;
        private DeckDetailsPopup _deckDetailsPopup;
        private bool _isPopupOpen;

        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel();
            _isPopupOpen = false;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is HomePageViewModel viewModel)
            {
                viewModel.RefreshData();
            }
        }

        private async void RedirectLoginOrAccount()
        {
            if (App.SessionService.IsLoggedIn)
            {
                await Navigation.PushAsync(new AccountPage());
            }
            else
            {

                await Navigation.PushAsync(new LoginPage());
            }
        }

        private void OnMyAccountClicked(object sender, EventArgs e)
        {
            RedirectLoginOrAccount();
        }




        private async void OnDeckTapped(object sender, EventArgs e)
        {
            var stackLayout = sender as StackLayout;
            var item = stackLayout.BindingContext as Deck; // Replace with your actual item type
            /*
            if (item != null)
            {
                var popup = new CardPopUp(item);
                this.ShowPopup(popup);
            }*/

            await Navigation.PushAsync(new ScanDeck());

        }

        private async void OnCreateDeckTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateDeckPage());
        }


    }
}