using Microsoft.Maui.Controls;
using CommunityToolkit.Maui.Views;
using flashcard_mobile.Models;

namespace flashcard_mobile.Views
{
    public partial class DeckDetailsPopup : Popup
    {
        public DeckDetailsPopup(Deck deck)
        {
            InitializeComponent();
            BindingContext = deck;
        }
    }
}
