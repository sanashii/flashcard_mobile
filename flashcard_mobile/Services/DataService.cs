using flashcard_mobile.Models;
using Microsoft.Data.Sqlite;
using System.Threading.Tasks;

namespace flashcard_mobile.Services
{
    public class DataService
    {
        private readonly Dictionary<string, User> _usersInSession = new Dictionary<string, User>();
        private readonly Dictionary<string, List<Deck>> _decksByUser = new Dictionary<string, List<Deck>>();

        public Task AddUserAsync(User user)
        {
            if (!_usersInSession.ContainsKey(user.Email))
            {
                _usersInSession[user.Email] = user;
                _decksByUser[user.Email] = new List<Deck>(); // Initialize empty list of decks for each user
            }
            return Task.CompletedTask;
        }

        public Task<User> GetUserAsync(string email)
        {
            if (_usersInSession.TryGetValue(email, out User user))
            {
                return Task.FromResult(user);
            }
            return Task.FromResult<User>(null);
        }

        // CRUD operations for decks
        public Task AddDeckAsync(string userEmail, Deck deck)
        {
            if (_decksByUser.TryGetValue(userEmail, out List<Deck> decks))
            {
                decks.Add(deck);
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Deck>> GetDecksAsync(string userEmail)
        {
            if (_decksByUser.TryGetValue(userEmail, out List<Deck> decks))
            {
                return Task.FromResult<IEnumerable<Deck>>(decks);
            }
            return Task.FromResult<IEnumerable<Deck>>(new List<Deck>());
        }

        public Task DeleteDeckAsync(string userEmail, string deckName)
        {
            if (_decksByUser.TryGetValue(userEmail, out List<Deck> decks))
            {
                var deckToRemove = decks.FirstOrDefault(d => d.DeckName == deckName);
                if (deckToRemove != null)
                {
                    decks.Remove(deckToRemove);
                }
            }
            return Task.CompletedTask;
        }

        // More methods can be added to manage cards within decks
    }
}