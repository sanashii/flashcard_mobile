using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using flashcard_mobile.Models;
using flashcard_mobile.Services;
using System.Windows.Input;

namespace flashcard_mobile.ViewModels
{
    public class HomePageViewModel : BindableObject
    {
        /*public ObservableCollection<Deck> Decks { get; } = new ObservableCollection<Deck>();

        public ICommand LoadDecksCommand { get; private set; }
        public ICommand AddDeckCommand { get; private set; }
        public ICommand DeleteDeckCommand { get; private set; }

        public HomePageViewModel()
        {
            LoadDecksCommand = new Command(async () => await LoadDecks());
            AddDeckCommand = new Command<Deck>(async deck => await AddDeck(deck));
            DeleteDeckCommand = new Command<string>(async deckName => await DeleteDeck(deckName));
        }

        private async Task LoadDecks()
        {
            var decks = await App.DataService.GetDecksAsync(App.DataService.CurrentUserEmail);
            Decks.Clear();
            foreach (var deck in decks)
            {
                Decks.Add(deck);
            }
        }

        private async Task AddDeck(Deck deck)
        {
            await App.DataService.AddDeckAsync(App.DataService.CurrentUserEmail, deck);
            Decks.Add(deck);
        }

        private async Task DeleteDeck(string deckName)
        {
            await App.DataService.DeleteDeckAsync(App.DataService.CurrentUserEmail, deckName);
            var deck = Decks.FirstOrDefault(d => d.DeckName == deckName);
            if (deck != null)
            {
                Decks.Remove(deck);
            }
        } */
    } 
}
