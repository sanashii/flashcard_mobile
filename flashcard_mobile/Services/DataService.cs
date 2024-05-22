using flashcard_mobile.Models;
using System.Collections.ObjectModel;

namespace flashcard_mobile.Services
{
    public class DataService
    {
        private readonly Dictionary<string, User> _usersInSession = new Dictionary<string, User>();
        private readonly Dictionary<string, List<Deck>> _decksByUser = new Dictionary<string, List<Deck>>();
        private readonly List<Deck> _staticDecks = new List<Deck>();
        private readonly List<Category> _categories = new List<Category>();

        public Task<ObservableCollection<Deck>> DecksByUser { get; internal set; }

        public DataService()
        {
            // Generate static data
            GenerateStaticData();
        }

        private void GenerateStaticData()
        {
            AddUserAsync(new User { Name = "Queeny", Email = "q@gmail.com", Password = "qqq" });
            App.SessionService.Login(_usersInSession["q@gmail.com"]);
            _staticDecks.AddRange(new List<Deck>
            {
                new Deck
                {
                    DeckName = "The Big Bang Theory",
                    Category = "TV Shows",
                    Cards = new List<Card>
                    {
                        new Card { Question = "What is Sheldon's favorite spot in the apartment?", Answer = "The spot on the left end of the couch" },
                        new Card { Question = "What is the name of the comic book store owner?", Answer = "Stuart Bloom" },
                        new Card { Question = "Who does Howard end up marrying?", Answer = "Bernadette Rostenkowski" },
                        new Card { Question = "Which character has a twin sister named Missy?", Answer = "Sheldon Cooper" },
                        new Card { Question = "What is Raj's full name?", Answer = "Rajesh Koothrappali" },
                        new Card { Question = "What is Leonard's profession?", Answer = "Experimental physicist" },
                        new Card { Question = "What does Penny aspire to be?", Answer = "An actress" },
                        new Card { Question = "What is the name of Howard's mother?", Answer = "Debbie Wolowitz" },
                        new Card { Question = "What is the name of the university where the main characters work?", Answer = "Caltech (California Institute of Technology)" },
                        new Card { Question = "What musical instrument does Amy play?", Answer = "Harp" },
                        new Card { Question = "What is the name of Sheldon's arch-nemesis?", Answer = "Barry Kripke" },
                        new Card { Question = "What is the name of the group’s favorite online game?", Answer = "World of Warcraft" },
                        new Card { Question = "Who officiates Sheldon and Amy's wedding?", Answer = "Mark Hamill" },
                        new Card { Question = "What kind of car does Leonard drive?", Answer = "Toyota Prius" },
                        new Card { Question = "What is the theme song of the show?", Answer = "The History of Everything by Barenaked Ladies" }
                    },
                    Description = "Big Bang Theory Fun Facks"
                },

                new Deck
                {
                    DeckName = "Spiderman Characters",
                    Category = "Comics",
                    Cards = new List<Card>
                    {
                        new Card { Question = "A beloved character from the Clone Saga", Answer = "Ben Reilly" },
                        new Card { Question = "Peter Parker's best girl", Answer = "Gwen Stacy" },
                        new Card { Question = "The main villain in the movie 'Spiderman: Homecoming'", Answer = "Vulture" },
                        new Card { Question = "A villain who has symbiote powers similar to Venom", Answer = "Carnage" },
                        new Card { Question = "Peter Parker's employer who later becomes a villain", Answer = "Doctor Octopus" },
                        new Card { Question = "The villain with a fishbowl helmet and illusions", Answer = "Mysterio" },
                        new Card { Question = "This villain's real name is Norman Osborn", Answer = "Green Goblin" },
                        new Card { Question = "A villain who can transform into sand", Answer = "Sandman" },
                        new Card { Question = "A villain who controls electricity", Answer = "Electro" },
                        new Card { Question = "The symbiote that initially bonds with Eddie Brock", Answer = "Venom" },
                        new Card { Question = "A villain who uses a special suit and glider", Answer = "Hobgoblin" },
                        new Card { Question = "A villain who has a mechanical tail", Answer = "Scorpion" },
                        new Card { Question = "The villain known for his shape-shifting abilities", Answer = "Chameleon" },
                        new Card { Question = "A villain who is a master of martial arts and once led the Sinister Six", Answer = "Kraven the Hunter" },
                        new Card { Question = "The villain who has a vampire-like appearance", Answer = "Morbius" }
                    },
                    Description = "Do you watch spidey?"

                },

                new Deck
                {
                    DeckName = "Jujutsu Kaisen",
                    Category = "Anime",
                    Cards = new List<Card>
                    {
                        new Card { Question = "Who is the main protagonist of Jujutsu Kaisen?", Answer = "Yuji Itadori" },
                        new Card { Question = "What is the name of the school where Yuji Itadori studies Jujutsu?", Answer = "Tokyo Metropolitan Magic Technical College" },
                        new Card { Question = "Who is Yuji Itadori's mentor?", Answer = "Satoru Gojo" },
                        new Card { Question = "What is the name of the ancient curse that Yuji Itadori becomes a vessel for?", Answer = "Ryomen Sukuna" },
                        new Card { Question = "Which character is known for using the Divergent Fist technique?", Answer = "Yuji Itadori" },
                        new Card { Question = "What is the name of the sorcerer who uses cursed speech?", Answer = "Toge Inumaki" },
                        new Card { Question = "Who is the third-year student famous for his curse tool, Playful Cloud?", Answer = "Aoi Todo" },
                        new Card { Question = "What is the name of the panda-like character in Jujutsu Kaisen?", Answer = "Panda" },
                        new Card { Question = "Which character has the ability to control blood and is a member of the Zenin clan?", Answer = "Maki Zenin" },
                        new Card { Question = "What is Megumi Fushiguro's technique that allows him to summon shikigami?", Answer = "Ten Shadows Technique" },
                        new Card { Question = "What is the name of the special grade cursed object that Sukuna is sealed within?", Answer = "Fingers of Ryomen Sukuna" },
                        new Card { Question = "Who is the head of the Kyoto Metropolitan Magic Technical College?", Answer = "Yoshinobu Gakuganji" },
                        new Card { Question = "What is Nobara Kugisaki's cursed technique?", Answer = "Straw Doll Technique" },
                        new Card { Question = "Which sorcerer is known for using Domain Expansion: Infinite Void?", Answer = "Satoru Gojo" },
                        new Card { Question = "What is the main antagonist group called in Jujutsu Kaisen?", Answer = "The Cursed Spirits" }
                    },
                    Description = "Jujutsu Kaisen faks quizz"
                },
            });
            foreach (var deck in _staticDecks)
            {
                AddDeckToCategory(deck.Category, deck).Wait();
            }
        }

        public Task AddDeckToCategory(string categoryName, Deck deck)
        {
            var category = _categories.FirstOrDefault(c => c.Name == categoryName);

            // If the category exists, add the deck to its Decks collection
            if (category != null)
            {
                category.Decks.Add(deck);
            }
            else
            {
                // Optionally, create a new category if it does not exist
                category = new Category { Name = categoryName };
                category.Decks.Add(deck);
                _categories.Add(category);
            }

            return Task.CompletedTask;
        }

        public Task<IEnumerable<Category>> GetCategoriesByUser(string userEmail, ObservableCollection<Deck> decks)
        {
            var categoryNames = decks.Select(deck => deck.Category).Distinct();
            var categories = categoryNames.Select(categoryName =>
            {
                var category = new Category { Name = categoryName };
                category.Decks = new ObservableCollection<Deck>(decks.Where(deck => deck.Category == categoryName));
                return category;
            });
            return Task.FromResult<IEnumerable<Category>>(categories);
        }
        public Task GetCategories ()
        {
            return Task.FromResult( _categories );
        }

        public Task<IEnumerable<Deck>> GetDecksFromCategory(string categoryName, ObservableCollection<Deck> decks)
        {
            var filteredDecks = decks.Where(deck => deck.Category == categoryName);

            return Task.FromResult<IEnumerable<Deck>>(filteredDecks);
        }

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
            List<Deck> result = new List<Deck>(_staticDecks);

            if (_decksByUser.TryGetValue(userEmail, out List<Deck> userDecks))
            {
                result.AddRange(userDecks);
            }

            return Task.FromResult<IEnumerable<Deck>>(result);
        }

        public Task<IEnumerable<Deck>> GetAllDecksAsync()
        {
            return Task.FromResult<IEnumerable<Deck>>(_staticDecks); 
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
    }
}