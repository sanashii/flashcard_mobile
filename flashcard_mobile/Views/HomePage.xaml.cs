using Microsoft.Maui.Controls;
using flashcard_mobile.ViewModels;
using CommunityToolkit.Maui.Views;
using flashcard_mobile.Models;

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
                Overlay.IsVisible = false; // Hide overlay when popup is closed
            };

            this.ShowPopup(_accountPopup);
            _isPopupOpen = true;
            Overlay.IsVisible = true; // Show overlay when popup is open
        }

        private void OnDeckTapped(object sender, EventArgs e)
        {
            if (_isPopupOpen)
            {
                ClosePopup();
            }
            else
            {
                var deck = (sender as BindableObject)?.BindingContext as Deck;
                if (deck != null)
                {
                    ShowDeckDetailsPopup(deck);
                }
            }
        }

        private void ShowDeckDetailsPopup(Deck deck)
        {
            var popup = new DeckDetailsPopup(deck);
            popup.Closed += (s, e) =>
            {
                _isPopupOpen = false;
                Overlay.IsVisible = false;
            };

            this.ShowPopup(popup);
            _isPopupOpen = true;
            Overlay.IsVisible = true;
        }

        private void ClosePopup()
        {
            if (_isPopupOpen)
            {
                if (_accountPopup != null)
                {
                    _accountPopup.Close();
                }
                if (_deckDetailsPopup != null)
                {
                    _deckDetailsPopup.Close();
                }
                Overlay.IsVisible = false;
                _isPopupOpen = false;
            }
        }
    }
}