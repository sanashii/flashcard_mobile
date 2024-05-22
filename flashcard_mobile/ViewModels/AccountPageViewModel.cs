using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flashcard_mobile.Services;
using System.Collections.ObjectModel;
using flashcard_mobile.Models;

namespace flashcard_mobile.ViewModels
{
    public class AccountPageViewModel : BindableObject
    {
        private readonly SessionService _sessionService;
        private readonly DataService _dataService;
        private ObservableCollection<Deck> _decks;
        private ObservableCollection<Category> _categories;


        public AccountPageViewModel()
        {
            _sessionService = App.SessionService;
            _dataService = App.DataService;
            LoadDecks();
        }

        private async void LoadDecks()
        {
            var decks = await _dataService.GetDecksAsync(UserEmail);
            DecksByUser = new ObservableCollection<Deck>(decks);

            var categories = await _dataService.GetCategoriesByUser(UserEmail, DecksByUser);
            RecentlyAddedDecks = new ObservableCollection<Deck>(decks.Take(3));
            Categories = new ObservableCollection<Category>(categories);

        }

        public ObservableCollection<Deck> DecksByUser
        {
            get => _decks;
            set
            {
                _decks = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Deck> RecentlyAddedDecks
        {
            get => _decks;
            set
            {
                _decks = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }


        public int CategoryCount => _categories.Count;
        public string UserName => _sessionService.CurrentUser?.Name ?? "Unknown User";
        public string UserEmail => _sessionService.CurrentUser?.Email ?? "unknown@example.com";
        public int DecksCreated => DecksByUser.Count;
    }
}
