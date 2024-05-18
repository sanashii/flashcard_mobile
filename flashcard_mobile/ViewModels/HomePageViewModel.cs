using flashcard_mobile.Models;
using flashcard_mobile.Services;
using flashcard_mobile.Converters;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace flashcard_mobile.ViewModels
{
    public class HomePageViewModel : BindableObject
    {
        private readonly DataService _dataService;
        private ObservableCollection<Deck> _decks;
        private ObservableCollection<Deck> _filteredDecks;
        private string _searchQuery;

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

        public HomePageViewModel()
        {
            _dataService = App.DataService;
            LoadDecks();
        }

        private async void LoadDecks()
        {
            var currentUserEmail = App.CurrentUserEmail; // Assuming you have a property to get the current logged-in user email
            var decks = await _dataService.GetDecksAsync(currentUserEmail);
            Decks = new ObservableCollection<Deck>(decks);
            FilteredDecks = new ObservableCollection<Deck>(decks);
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
        } */
    }
}
