using flashcard_mobile.Models;
using flashcard_mobile.Services;
using System.Collections.ObjectModel;
using flashcard_mobile.Views;
using CommunityToolkit.Maui.Views;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace flashcard_mobile.ViewModels
{
    public class HomePageViewModel : BindableObject
    {
        private readonly DataService _dataService;
        private readonly SessionService _sessionService;
        private ObservableCollection<Deck> _decks;
        private ObservableCollection<Deck> _filteredDecks;
        private string _searchQuery;

        private string _accountButtonText {  get; set; }
        private bool _isUserLoggedIn { get; set; }

        public HomePageViewModel()
        {
            _dataService = App.DataService;
            _sessionService = App.SessionService;
            LoadDecks();
        }
        public ICommand DeckSelectedCommand { get; }
        public void RefreshData()
        {
            UpdateAccountButtonText();
            UpdateIsUserLoggedIn();

        }

        public string AccountButtonText
        {
            get => _accountButtonText;
            set
            {
                if (_accountButtonText != value)
                {
                    _accountButtonText = value;
                    OnPropertyChanged();
                }
            }
        }

        public void UpdateAccountButtonText()
        {
            AccountButtonText = _sessionService.IsLoggedIn ? "My Account" : "Log In";
            
        }


        public bool IsUserLoggedIn
        {
            get => _isUserLoggedIn;
            private set
            {
                if (_isUserLoggedIn != value)
                {
                    _isUserLoggedIn = value;
                    OnPropertyChanged(); 
                }
            }
        }

        public void UpdateIsUserLoggedIn()
        {
            IsUserLoggedIn = _sessionService.IsLoggedIn;
        }

        public ObservableCollection<Deck> Decks
        {
            get => _decks;
            set
            {
                _decks = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Deck> FilteredDecks
        {
            get => _filteredDecks;
            set
            {
                _filteredDecks = value;
                OnPropertyChanged();
            }
        }

        private async void LoadDecks()
        {
            var currentUserEmail = App.CurrentUserEmail;
            var decks = await _dataService.GetAllDecksAsync();
            Decks = new ObservableCollection<Deck>(decks);
            FilteredDecks = new ObservableCollection<Deck>(decks);

        }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
                FilterDecks();
            }
        }

        private void FilterDecks()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                FilteredDecks = new ObservableCollection<Deck>(Decks);
            }
            else
            {
                var filtered = Decks.Where(d => d.DeckName.ToLower().Contains(SearchQuery.ToLower()) ||
                                                d.Category.ToLower().Contains(SearchQuery.ToLower()));
                FilteredDecks = new ObservableCollection<Deck>(filtered);
            }
        }



        /* private void OpenDeckDetails(Deck deck)
        {
            // This method should handle opening the DeckDetailsPopup
            ShowDeckDetailsPopup(deck); //(This method should be in HomePage.xaml.cs and should handle the logic to display the popup)
        } 

        public ICommand DeckSelectedCommand { get; }

        private void OnDeckSelected(Deck selectedDeck)
        {
            var popup = new CardPopUp(selectedDeck);

            Hey();

            Application.Current.MainPage.ShowPopup(popup);
        }

        private async void Hey()
        {
            await Shell.Current.DisplayAlert("We", "Frack", "ok");
        }*/

    }
}
