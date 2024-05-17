using System.Collections.Generic;
using flashcard_mobile.Services;
using flashcard_mobile.Models;

namespace flashcard_mobile.Models
{
    public class Deck
    {
        public string DeckName { get; set; }
        public string Category { get; set; }
        public List<Card> Cards { get; set; } = new List<Card>();
    }
}
