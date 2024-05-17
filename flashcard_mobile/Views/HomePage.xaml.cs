using Microsoft.Maui.Controls;
using flashcard_mobile.ViewModels;

namespace flashcard_mobile.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel();
        }

        private async void OnMyAccountClicked(object sender, EventArgs e)
        {
            var popupPage = new AccountPopupPage();
            await Navigation.PushModalAsync(popupPage);
        }
    }
}
