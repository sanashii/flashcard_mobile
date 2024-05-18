using System.Collections.Generic;

namespace flashcard_mobile.Models
{
    public class Deck
    {
        public string DeckName { get; set; }
        public string Category { get; set; }
        public List<Card> Cards { get; set; } = new List<Card>();

        public int CardCount => Cards?.Count ?? 0;
    }
}
