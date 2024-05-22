using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flashcard_mobile.Models
{
    public class Category
    {
        public string Name { get; set; }
        public ObservableCollection<Deck> Decks { get; set; }

        public Category() { 
            Decks = new ObservableCollection<Deck>();
        }
    }

}
