using Microsoft.Maui.Controls;
using flashcard_mobile.ViewModels;
using CommunityToolkit.Maui.Views;

namespace flashcard_mobile.Views
{
    public partial class HomePage : ContentPage
    {
        private AccountPopup _accountPopup;
        private bool _isPopupOpen;

        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel();
            _isPopupOpen = false;
        }

        private void OnMyAccountClicked(object sender, EventArgs e)
        {
            if (_isPopupOpen)
            {
                ClosePopup();
            }
            else
            {
                ShowAccountPopup();
            }
        }

        private void ShowAccountPopup()
        {
            _accountPopup = new AccountPopup(); // Create a new instance of AccountPopup
            _accountPopup.Closed += (s, e) =>
            {
                _isPopupOpen = false;
            };

            this.ShowPopup(_accountPopup);
            _isPopupOpen = true;
        }

        private void ClosePopup()
        {
            if (_accountPopup != null && _isPopupOpen)
            {
                _accountPopup.Close();
            }
        }
    }
}
